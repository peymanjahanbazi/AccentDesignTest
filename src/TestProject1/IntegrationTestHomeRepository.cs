using AccentDesignTest.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1;

public class IntegrationTestHomeRepository
{
    [Fact]
    public async Task UrlTestAsync()
    {
        HomeRepository repository = new HomeRepository();

        var result = await repository.getCustomerInfo("ACC001");
        Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public async Task InvalidIdTestAsync()
    {
        HomeRepository repository = new HomeRepository();

        var result = await repository.getCustomerInfo("XXXXXXXX");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
    }
}