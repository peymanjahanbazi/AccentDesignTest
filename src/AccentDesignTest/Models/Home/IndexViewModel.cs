using AccentDesignTest.Models.RemoteApi;
using System.Net;

namespace AccentDesignTest.Models.Home;

public class IndexViewModel
{
    public HttpStatusCode StatusCode { get; set; }
    public float GrandTotal { get; set; }

    public List<Property> Properties { get; set; }
}