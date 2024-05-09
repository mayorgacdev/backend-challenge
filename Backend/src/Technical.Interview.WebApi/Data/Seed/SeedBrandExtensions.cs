namespace Technical.Interview.WebApi.Data.Seed;

public static class SeedBrandExtensions
{
    public static void SeedBrand(this ModelBuilder ModelBuilder)
    {
        ModelBuilder.Entity<MarcasAuto>().HasData(BrandData.Select(Brand => 
        MarcasAuto.Create(Brand.Name, Brand.OriginCountry, Brand.Website)));
    }

    private static (string Name, string OriginCountry, string Website)[] BrandData
        => [ 
            ("Toyota", "Japan", "https://www.toyota.com/"),
            ("Ford", "United States", "https://www.ford.com/"),
            ("Volkswagen", "Germany", "https://www.vw.com/")
           ];
}
