using AutoMapper;
using Propelo.DTO;
using Propelo.Models;

namespace Propelo.extensions
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Promoter,PromoterDTO>().ReverseMap();
            CreateMap<Property,PropertyDTO>().ReverseMap();
            CreateMap<PropertyPicture,PropertyPectureDTO>().ReverseMap();
            CreateMap<Apartment,ApartmentDTO>().ReverseMap();
            CreateMap<ApartmentPicture,ApartmentPictureDTO>().ReverseMap();
            CreateMap<ApartmentDocument,ApartmentDocumentDTO>().ReverseMap();
            CreateMap<Area,AreaDTO>().ReverseMap();
            CreateMap<Setting,SettingDTO>().ReverseMap();
        }
    }
}
