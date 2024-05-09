namespace Technical.Interview.WebApi.Entities;

/// <summary>
/// Represents a car brand.
/// </summary>
public class MarcasAuto
{
    /// <summary>
    /// Represent the unique identifier 
    /// </summary>
    public Guid Id { get; private set; } = Guid.Empty;

    /// <summary>
    /// Represents the name of the brand
    /// </summary>
    public string Nombre { get; private set; } = string.Empty;

    /// <summary>
    /// Repsents the country of origin
    /// </summary>
    public string PaisOrigen { get; private set; } = string.Empty;

    /// <summary>
    /// Represents the website of the brand
    /// </summary>
    public string SitioWeb { get; private set; } = string.Empty;

    public static MarcasAuto Create(string Name, string OriginCountry, string Website)
        => new MarcasAuto
        {
            Id = Guid.NewGuid(),
            Nombre = Name,
            PaisOrigen = OriginCountry,
            SitioWeb = Website
        };
}

