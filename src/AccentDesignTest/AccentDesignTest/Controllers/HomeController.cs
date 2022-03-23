using AccentDesignTest.Models;
using AccentDesignTest.Models.Home;
using AccentDesignTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccentDesignTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HomeRepository _homeRepository;

    public HomeController(ILogger<HomeController> logger, HomeRepository homeRepository)
    {
        _logger = logger;
        _homeRepository = homeRepository;
    }

    public async Task<IActionResult> Index(string customerCode = "")
    {
        if (string.IsNullOrWhiteSpace(customerCode))
        {
            var noParamModel = new IndexNoParamViewModel
            {
                Message = "You should provide \"customerCode\" in the URL",
                Default = "ACC001"
            };
            return View("IndexNoParam", noParamModel);
        }

        var model = await _homeRepository.getCustomerInfo(customerCode);

        if (model.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var invalidParamModel = new IndexNoParamViewModel
            {
                Message = "The customer was not found",
                Default = "ACC001"
            };
            return View("IndexNoParam", invalidParamModel);
        }
        if (model.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var invalidParamModel = new IndexNoParamViewModel
            {
                Message = "Can not access server",
                Default = "ACC001"
            };
            return View("IndexNoParam", invalidParamModel);
        }
        if (!model.Properties.Any())
        {
            var invalidParamModel = new IndexNoParamViewModel
            {
                Message = "There is not any property",
                Default = "ACC001"
            };
            return View("IndexNoParam", invalidParamModel);
        }
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}