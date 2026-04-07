using AutoMapper;
using YashGems.Commerce.Application.DTOs;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> DTO
            CreateMap<Category, CategoryDto>();
            CreateMap<JewelType, JewelTypeDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<GoldKarat, GoldKaratDto>();
            CreateMap<Certification, CertificationDto>();

            // DTO -> Entity
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;

                    return true;
                }));

            CreateMap<JewelTypeDto, JewelType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;

                    return true;
                }));

            CreateMap<BrandDto, Brand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;

                    return true;
                }));

            CreateMap<GoldKaratDto, GoldKarat>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;

                    return true;
                }));

            CreateMap<CertificationDto, Certification>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;

                    return true;
                }));

            CreateMap<DiamondColor, DiamondColorDto>();
            CreateMap<DiamondColorDto, DiamondColor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));

            CreateMap<DiamondClarity, DiamondClarityDto>();
            CreateMap<DiamondClarityDto, DiamondClarity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));

            CreateMap<DiamondCut, DiamondCutDto>();
            CreateMap<DiamondCutDto, DiamondCut>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));

            CreateMap<GemstoneType, GemstoneTypeDto>();
            CreateMap<GemstoneTypeDto, GemstoneType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));

            CreateMap<StoneQuality, StoneQualityDto>();
            CreateMap<StoneQualityDto, StoneQuality>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));
        }
    }
}
