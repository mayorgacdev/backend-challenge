namespace Technical.Interview.WebApi;

public interface IUnitOfWork
{
    IRepository<MarcasAuto> BrandRepository { get; }
    IReadRepository<MarcasAuto> BrandReadRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}