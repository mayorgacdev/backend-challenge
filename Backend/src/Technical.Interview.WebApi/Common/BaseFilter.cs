namespace Technical.Interview.WebApi.Common;

public record BaseFilter(
    int? Page = null, 
    int? PageSize = null, 
    string? SortBy = null, 
    string? OrderBy = null);