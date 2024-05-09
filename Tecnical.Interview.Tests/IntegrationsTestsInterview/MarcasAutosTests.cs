using Moq;
using System.Net.Http.Headers;
using System.Net;
using Technical.Interview.WebApi.Controllers;
using Technical.Interview.WebApi.Responses;
using Technical.Interview.WebApi.Services;
using Technical.Interview.WebApi.Common;
using System.Text.Json;

namespace Tecnical.Interview.Tests.IntegrationsTestsInterview;

public class MarcasAutosControllerTests
{
    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse()
    {
        // Arrange
        var brandServiceMock = new Mock<IBrandService>();
        brandServiceMock.Setup(s => s.FetchBrandsAsync(It.IsAny<BrandFilter>()))
           .ReturnsAsync(new PagedResponse<BrandInfo>(
               [
                       new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 1", PaisOrigen = "Country 1", Fundacion = DateTime.Now, SitioWeb = "https://brand1.com" },
                       new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 2", PaisOrigen = "Country 2", Fundacion = DateTime.Now, SitioWeb = "https://brand2.com" }
               ],
               new Pagination(2, 1, 10, 1, 1, 2, false, false)
           ));

        var controller = new MarcasAutosController(brandServiceMock.Object);

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:8080");

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await httpClient.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var pagedResponse = JsonSerializer.Deserialize<PagedResponse<BrandInfo>>(responseBody);
        Assert.NotNull(pagedResponse);
        Assert.Equal(2, pagedResponse.Data.Count);
    }

    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse_WhenFilterIsNull()
    {
        // Arrange
        var brandServiceMock = new Mock<IBrandService>();
        var controller = new MarcasAutosController(brandServiceMock.Object);

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:8080");

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await httpClient.SendAsync(request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse_WhenFilterIsNotNull()
    {
        // Arrange
        var brandServiceMock = new Mock<IBrandService>();
        brandServiceMock.Setup(s => s.FetchBrandsAsync(It.IsAny<BrandFilter>()))
           .ReturnsAsync(new PagedResponse<BrandInfo>(
               [
                       new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 1", PaisOrigen = "Country 1", Fundacion = DateTime.Now, SitioWeb = "https://brand1.com" },
                       new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 2", PaisOrigen = "Country 2", Fundacion = DateTime.Now, SitioWeb = "https://brand2.com" }
               ],
               new Pagination(2, 1, 10, 1, 1, 2, false, false))
           );

        var controller = new MarcasAutosController(brandServiceMock.Object);

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:8080");

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos?nombre=Brand 1");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await httpClient.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var pagedResponse = JsonSerializer.Deserialize<PagedResponse<BrandInfo>>(responseBody);
        Assert.NotNull(pagedResponse);
        Assert.Single(pagedResponse.Data);
    }

    [Fact]
    public async Task FetchBrandsAsync_ReturnsOkResponse_WhenPageIsTwo()
    {
        // Arrange
        var brandServiceMock = new Mock<IBrandService>();
        brandServiceMock.Setup(s => s.FetchBrandsAsync(It.IsAny<BrandFilter>()))
           .ReturnsAsync(new PagedResponse<BrandInfo>(
            [
                new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 1", PaisOrigen = "Country 1", Fundacion = DateTime.Now, SitioWeb = "https://brand1.com" },
                new BrandInfo { Id = Guid.NewGuid(), Nombre = "Brand 2", PaisOrigen = "Country 2", Fundacion = DateTime.Now, SitioWeb = "https://brand2.com" }
           ],
            new Pagination(2, 2, 10, 1, 1, 2, false, false)));

        var controller = new MarcasAutosController(brandServiceMock.Object);

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:8080");

        var request = new HttpRequestMessage(HttpMethod.Get, "api/MarcasAutos?page=2");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Act
        var response = await httpClient.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var pagedResponse = JsonSerializer.Deserialize<PagedResponse<BrandInfo>>(responseBody);
        Assert.NotNull(pagedResponse);
        Assert.Equal(2, pagedResponse.Data.Count);
    }



}
