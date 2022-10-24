using AutoMapper;
using WineCollection.Entities;
using WineCollection.Models;

namespace WineCollection
{
    public class WineCollectionMappingProfile : Profile
    {

        public WineCollectionMappingProfile()
        {
            //wines
            CreateMap<Wine, WineDto>()
            .ForMember(m => m.Color, c => c.MapFrom(s => s.Color.ColorName))
            .ForMember(m => m.GrapeVariety, c => c.MapFrom(s => s.GrapeVariety.GrapeVarietyName))
            .ForMember(m => m.Vineyard, c => c.MapFrom(s => s.Vineyard.Name))
            .ForMember(m => m.Region, c => c.MapFrom(s => s.Vineyard.Region))
            .ForMember(m => m.Country, c => c.MapFrom(s => s.Vineyard.Country.Name));


            CreateMap<CreateWineDto, Wine>()
             .ForMember(w => w.GrapeVariety, c => c.MapFrom(dto => new GrapeVariety()
             { GrapeVarietyName = dto.GrapeVariety }))
             .ForMember(w => w.Vineyard, c => c.MapFrom(dto => new Vineyard()
             { Name = dto.Vineyard, Region = dto.Region, Country = new Country { Name = dto.Country } }));

            CreateMap<UpdateWineDto, Wine>()
                .ForMember(w => w.GrapeVariety, c => c.MapFrom(dto => new GrapeVariety()
                { GrapeVarietyName = dto.GrapeVariety }))
             .ForMember(w => w.Vineyard, c => c.MapFrom(dto => new Vineyard()
             { Name = dto.Vineyard, Region = dto.Region, Country = new Country { Name = dto.Country } }));

            //cellars
            CreateMap<CreateCellarDto, WineCellar>();
            CreateMap<WineCellar, CellarDto>();


        }



    }
}
