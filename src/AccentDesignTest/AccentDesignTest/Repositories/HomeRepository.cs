using AccentDesignTest.Models.Home;
using AccentDesignTest.Models.RemoteApi;

namespace AccentDesignTest.Repositories;

public class HomeRepository
{
    private static readonly string PropertiesUrl =
        "http://boarderectors-api.accentstaging.co.uk/agents/accountCode/properties";

    private static readonly string AgentUrl =
        "http://boarderectors-api.accentstaging.co.uk/agents/accountCode";

    public async Task<IndexViewModel> getCustomerInfo(string accountCode)
    {
        using var client = new HttpClient();

        var resultProperties = await client.GetAsync(PropertiesUrl.Replace("accountCode", accountCode));
        if (resultProperties.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return new() { StatusCode = resultProperties.StatusCode };
        }
        List<Property>? propertiesList = await resultProperties.Content.ReadFromJsonAsync<List<Property>>();
        IndexViewModel result = new()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Properties = propertiesList ?? new List<Property>(),
        };
        result.GrandTotal = 0.0f;
        result.Properties.ForEach(p =>
        {
            p.totalFeeChargedCalculated = p.erectedBoardType.title switch
            {
                "sold" => p.totalFeeCharged * 1.075f,
                "sale agreed" => p.totalFeeCharged * 1.04f,
                _ => p.totalFeeCharged,
            };
            result.GrandTotal += p.totalFeeChargedCalculated;
        });
        return result;
    }
}