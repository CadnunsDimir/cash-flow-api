using CashFlowApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace CashFlowApi.Tests;

public class CashFlowApiTests
{
    [Fact]
    public async Task GetEntriesTest()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetAsync("/api/cash-flow");
    
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PostEntry()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var entry = new EntryViewModel(null, "new produtcs", -200);

        var response = await client.PostAsJsonAsync("/api/cash-flow", entry);
    
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetReportTest()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetAsync("/api/cash-flow/report");
    
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}