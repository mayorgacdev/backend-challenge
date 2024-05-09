namespace Technical.Interview.WebApi.Extensions;

public static class SpecificationExtensions
{
    // Let's assume we want to apply ordering for brands.
    // Conveniently, we can create add an extension method, and use it in any customer spec.
    public static ISpecificationBuilder<MarcasAuto> ApplyOrdering(this ISpecificationBuilder<MarcasAuto> Builder, BaseFilter? Filter = null)
    {
        // If there is no filter apply default ordering;
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        // We want the "asc" to be the default, that's why the condition is reverted.
        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(MarcasAuto.Nombre) => IsAscending ? Builder.OrderBy(Prop => Prop.Nombre) : Builder.OrderByDescending(Prop => Prop.SitioWeb),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    public static ISpecificationBuilder<MarcasAuto> ByName(this ISpecificationBuilder<MarcasAuto> Builder, string? Name)
        => Name is not null ? Builder.Where(Prop => Prop.Nombre.Contains(Name)) : Builder;

    public static ISpecificationBuilder<MarcasAuto> ByOriginCountry(this ISpecificationBuilder<MarcasAuto> Builder, string? OriginCountry)
        => OriginCountry is not null ? Builder.Where(Prop => Prop.PaisOrigen.Contains(OriginCountry)) : Builder;

    public static ISpecificationBuilder<MarcasAuto> ByWebsite(this ISpecificationBuilder<MarcasAuto> Builder, string? Website)
        => Website is not null ? Builder.Where(Prop => Prop.SitioWeb.Contains(Website)) : Builder;

    public static ISpecificationBuilder<MarcasAuto> ById(this ISpecificationBuilder<MarcasAuto> Builder, Guid? Id)
        => Id is not null ? Builder.Where(Prop => Prop.Id.Equals(Id)) : Builder;
}
