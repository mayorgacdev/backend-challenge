using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Technical.Interview.WebApi.Entities;
using Technical.Interview.WebApi;
using Technical.Interview.WebApi.Data;

namespace Tecnical.Interview.Tests.UnitInterviewContexTests;

public class InterviewContextTests
{
    [Fact]
    public void Constructor_OptionsAndMapper_ThrowsArgumentNullException()
    {
        // Arrange
        DbContextOptions<InterviewContext> options = null!;
        IMapper mapper = null!;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new InterviewContext(options, mapper));
    }

    [Fact]
    public void Constructor_OptionsAndMapper_Succeeds()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<InterviewContext>().Options;
        var mapper = new Mock<IMapper>().Object;

        // Act
        var context = new InterviewContext(options, mapper);

        // Assert
        Assert.NotNull(context);
    }

    [Fact]
    public void MarcasAutos_Property_ReturnsDbSet()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<InterviewContext>();
            optionsBuilder.UseInMemoryDatabase("MarcasAutosDb");
        
        var options = optionsBuilder.Options;
        var mapper = new Mock<IMapper>().Object;
        var context = new InterviewContext(options, mapper);

        // Act
        var marcasAutos = context.MarcasAutos;

        // Assert
        Assert.NotNull(marcasAutos);
        Assert.IsAssignableFrom<DbSet<MarcasAuto>>(marcasAutos);
    }

    [Fact]
    public void BrandRepository_Property_ReturnsIRepository()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<InterviewContext>().Options;
        var mapper = new Mock<IMapper>().Object;
        var context = new InterviewContext(options, mapper);

        // Act
        var brandRepository = context.BrandRepository;

        // Assert
        Assert.NotNull(brandRepository);
        Assert.IsAssignableFrom<IRepository<MarcasAuto>>(brandRepository);
    }

    [Fact]
    public void BrandReadRepository_Property_ReturnsIReadRepository()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<InterviewContext>().Options;
        var mapper = new Mock<IMapper>().Object;
        var context = new InterviewContext(options, mapper);

        // Act
        var brandReadRepository = context.BrandReadRepository;

        // Assert
        Assert.NotNull(brandReadRepository);
        Assert.IsAssignableFrom<IReadRepository<MarcasAuto>>(brandReadRepository);
    }
}

