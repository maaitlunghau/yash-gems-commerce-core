using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Application.Mappings;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        // entity -> dto
        CreateMap<Category, CategoryDto>();
        CreateMap<JewelType, JewelTypeDto>();
        CreateMap<Brand, BrandDto>();
        CreateMap<GoldKarat, GoldKaratDto>();
        CreateMap<Certification, CertificationDto>();

        // dto -> entity
        CreateMap<CategoryDto, Category>();
        CreateMap<JewelTypeDto, JewelType>();
        CreateMap<BrandDto, Brand>();
        CreateMap<GoldKaratDto, GoldKarat>();
        CreateMap<CertificationDto, Certification>();
    }
}
