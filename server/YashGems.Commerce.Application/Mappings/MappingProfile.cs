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

            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.Name : null))
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : null))
                .ForMember(d => d.JewelTypeName, opt => opt.MapFrom(s => s.JewelType != null ? s.JewelType.Name : null))
                .ForMember(d => d.CertificationName, opt => opt.MapFrom(s => s.Certification != null ? s.Certification.Name : null))
                .ForMember(d => d.GoldKaratName, opt => opt.MapFrom(s => s.GoldKarat != null ? s.GoldKarat.Name : null))
                .ForMember(d => d.DiamondColorName, opt => opt.MapFrom(s => s.DiamondColor != null ? s.DiamondColor.Name : null))
                .ForMember(d => d.DiamondClarityName, opt => opt.MapFrom(s => s.DiamondClarity != null ? s.DiamondClarity.Name : null))
                .ForMember(d => d.DiamondCutName, opt => opt.MapFrom(s => s.DiamondCut != null ? s.DiamondCut.Name : null))
                .ForMember(d => d.GemstoneTypeName, opt => opt.MapFrom(s => s.GemstoneType != null ? s.GemstoneType.Name : null))
                .ForMember(d => d.StoneQualityName, opt => opt.MapFrom(s => s.StoneQuality != null ? s.StoneQuality.Name : null));

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember == null) return false;
                    if (srcMember is string str && string.IsNullOrWhiteSpace(str)) return false;
                    return true;
                }));

            CreateMap<ProductImage, ProductImageDto>();
        }
    }
}
