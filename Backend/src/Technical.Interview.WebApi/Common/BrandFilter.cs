namespace Technical.Interview.WebApi.Common;

public record BrandFilter(
    Guid? Id = null, 
    string? Name = null, 
    string? OriginCountry = null, 
    string? Foundation = null, string? Website = null) : BaseFilter;