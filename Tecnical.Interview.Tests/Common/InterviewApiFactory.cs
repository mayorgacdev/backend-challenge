namespace Tecnical.Interview.Tests.Common;

using Ardalis.Specification;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Technical.Interview.WebApi;
using Technical.Interview.WebApi.Entities;
using Tecnical.Interview.Tests.Fixtures;

internal class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly ApplicationFixture _applicationFixture;

    public ApiWebApplicationFactory(ApplicationFixture applicationFixture)
    {
        _applicationFixture = applicationFixture;
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Configurar servicios de la aplicación
        builder.ConfigureServices(services =>
        {
            AddInfrastructureServices(services, _applicationFixture);
        });

        builder.ConfigureAppConfiguration(config =>
        {
            config.Sources.Clear();
            config.AddConfiguration(configuration);
        });
    }

    private static void AddInfrastructureServices(IServiceCollection services, ApplicationFixture applicationFixture)
    {
        // Remover todos los servicios inyectados en AddInfrastructureServices
        services.RemoveAll<IUnitOfWork>();
        services.RemoveAll<IReadRepository<MarcasAuto>>();
        services.RemoveAll<IRepository<MarcasAuto>>();
        services.RemoveAll(typeof(ISingleResultSpecification<>));
        services.RemoveAll(typeof(IRepositoryBase<>));

        // Mock de DbContext y UnitOfWork si es necesario
        services.AddScoped(_ => applicationFixture._unitOfWorkMock.Object);

        // Mock de Repositories
        services.AddScoped(_ => applicationFixture._marcasAutoRepository.Object);
        services.AddScoped(_ => applicationFixture._readMarcasAuto.Object);

    }
}