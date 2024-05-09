namespace Technical.Interview.WebApi.Services;

[GenerateAutomaticInterface]
public class BrandService(IUnitOfWork UnitOfWork, ISingleResultSpecification<MarcasAuto> SingleSpecification): IBrandService
{
    public Task<PagedResponse<BrandInfo>> FetchBrandsAsync(BrandFilter Filter)
    {
        SingleSpecification.Query
            .ById(Filter.Id)
            .ByName(Filter.Name)
            .ByOriginCountry(Filter.OriginCountry)
            .ByWebsite(Filter.Website)
            .ApplyOrdering();

        return UnitOfWork.BrandReadRepository.ProjectToListAsync<BrandInfo>(SingleSpecification, Filter, default);
    }
}
