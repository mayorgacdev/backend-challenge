namespace Technical.Interview.WebApi.Common;

public record BrandFilter(
    string? Id = null, 
    string? Name = null, 
    string? OriginCountry = null, 
    string? Website = null) : BaseFilter();