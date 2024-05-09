namespace Technical.Interview.WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MarcasAuto, BrandInfo>()
            .ForMember(Prop => Prop.Id, Opt => Opt.MapFrom(Prop => Prop.Id))
            .ForMember(Prop => Prop.Nombre, Opt => Opt.MapFrom(Prop => Prop.Nombre))
            .ForMember(Prop => Prop.SitioWeb, Opt => Opt.MapFrom(Prop => Prop.SitioWeb))
            .ForMember(Prop => Prop.PaisOrigen, Opt => Opt.MapFrom(Prop => Prop.PaisOrigen));
    }
}
