namespace Technical.Interview.WebApi.Data;

public class InterviewContext(DbContextOptions<InterviewContext> Options, IMapper Mapper) : DbContext(Options), IUnitOfWork
{
    /// <summary>
    /// Represent the dbSet 
    /// </summary>
    public DbSet<MarcasAuto> MarcasAutos => base.Set<MarcasAuto>();

    /// <summary>
    /// Brand reposiroty for creation, update and delete operations
    /// </summary>
    public IRepository<MarcasAuto> BrandRepository => new Repository<MarcasAuto>(this, Mapper);

    /// <summary>
    /// Brand Repository just for read operations
    /// </summary>
    public IReadRepository<MarcasAuto> BrandReadRepository => new ReadRepository<MarcasAuto>(this, Mapper);

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        ModelBuilder.SeedBrand();

        base.OnModelCreating(ModelBuilder);
    }
}
