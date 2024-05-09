namespace Technical.Interview.WebApi.Data.Configurations.BrandConfigurations;

public class MarcasAutoConfiguration : IEntityTypeConfiguration<MarcasAuto>
{
    public void Configure(EntityTypeBuilder<MarcasAuto> builder)
    {
        builder.Property(Prop => Prop.Id)
            .ValueGeneratedOnAdd();

        builder.Property(Prop => Prop.Nombre).HasMaxLength(100).IsRequired();
        builder.Property(Prop => Prop.PaisOrigen).HasMaxLength(100).IsRequired();
        builder.Property(Prop => Prop.SitioWeb).HasMaxLength(200).IsRequired();
    }
}
