namespace Technical.Interview.WebApi.Controllers;

public class MarcasAutosController(IBrandService BrandService) : InterviewControllerBase
{
    [HttpGet(Name = "FetchBrands")]
    [ProducesResponseType(typeof(PagedResponse<BrandInfo>), StatusCodes.Status200OK)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<BrandInfo>>> FetchCustomersAsync([FromQuery] BrandFilter Filter)
    {
        return await BrandService.FetchBrandsAsync(Filter);
    }
}
