using Microsoft.AspNetCore.Mvc.RazorPages;
using Technical.Interview.WebApi.Common;

namespace Tecnical.Interview.Tests.Fakers;

public class BrandFilterFaker
{
    public static BrandFilter MakeBrandFilter(string id)
        => new(id, "Country 1", "https://brand1.com");

    public static BrandFilter brandFilter => new("1", "Country 1",null,  "https://brand1.com");
}
