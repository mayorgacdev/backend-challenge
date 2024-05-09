namespace Technical.Interview.WebApi;

public static class InterviewExtensions
{
    public static IServiceCollection AddExtensions(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddOutputCache(Options =>
        {
            Options.AddBasePolicy(Builder => Builder.Expire(TimeSpan.FromSeconds(30)));
        });

        Services.AddDbContext<InterviewContext>(Options =>
        {
            Options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]);
        });

        Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        Services.AddScoped<IUnitOfWork, InterviewContext>();
        Services.AddScoped<IBrandService, BrandService>();

        Services.AddScoped(typeof(ISingleResultSpecification<>), typeof(SingleResultSpecification<>));
        Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        return Services;
    }
}