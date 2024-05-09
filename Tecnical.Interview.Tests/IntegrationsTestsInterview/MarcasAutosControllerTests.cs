using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tecnical.Interview.Tests.Common;
using Tecnical.Interview.Tests.Fakers;
using Tecnical.Interview.Tests.Fixtures;

namespace Tecnical.Interview.Tests.IntegrationsTestsInterview;

public class ReimbursementEndpointTest
{
    #region Public Methods

    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var filter = BrandFilterFaker.MakeBrandFilter(id);

        var applicationFixture = new ApplicationFixture();
        await using var application = new ApiWebApplicationFactory(applicationFixture);

        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    //    FetchBrandsAsync Returns Ok Response When Filter Is NotNull()
    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse_WhenFilterIsNotNull()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var filter = BrandFilterFaker.MakeBrandFilter(id);

        var applicationFixture = new ApplicationFixture();
        await using var application = new ApiWebApplicationFactory(applicationFixture);

        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    // Fetch Brands Async Returns Ok Response When Page Is Two
    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse_WhenPageIsTwo()
    {
        // Arrange
        var id = Guid.NewGuid().ToString();
        var filter = BrandFilterFaker.MakeBrandFilter(id);

        var applicationFixture = new ApplicationFixture();
        await using var application = new ApiWebApplicationFactory(applicationFixture);

        using var client = application.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos?page=2");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    #endregion Public Methods
}



