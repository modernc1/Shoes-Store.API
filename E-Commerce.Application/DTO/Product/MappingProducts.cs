using AutoMapper;
using E_Commerce.Application.DTO.Product.ProductItem;
using E_Commerce.Application.DTO.Product.ProductItem.ProductVariation;
using E_Commerce.Domain.Models;

namespace E_Commerce.Application.DTO.Product
{
	public class MappingProducts : Profile
	{
        public MappingProducts()
        {
            CreateMap<CreateProductDto, Domain.Models.Product>()
                .ForMember(p=> p.MainImageUrl, opt => opt.AllowNull())
                .ForMember(p => p.ProductItems, opt => opt.MapFrom(cp => cp.CreateProductItems));
            CreateMap<Domain.Models.Product, GetProduct>();

			//mapping productItem and variation
			CreateMap<CreateProductVariation, ProductVariation>()
				.ForMember(pv => pv.SizeOptionId, opt => opt.MapFrom(cpv => cpv.SizeOptionId))
				.ForMember(pv => pv.QuantityInStock, opt => opt.MapFrom(cpv => cpv.QuantityInStock))
				.ForAllMembers(opt => opt.AllowNull());

			CreateMap<CreateProductItemDto, Domain.Models.ProductItem>()
                .ForMember(pi => pi.Images, opt => opt.Ignore())
                .ForMember(pi => pi.ProductVariations, opt => opt.MapFrom(cpi => cpi.ProductVariations))
                .ForAllMembers(p => p.AllowNull());

            CreateMap<SizeOption, GetSizeOption>()
                .ForAllMembers(opt => opt.AllowNull());

            CreateMap<ProductVariation, GetProductVariation>()
                .ForMember(gpv => gpv.SizeOption, opt => opt.MapFrom(pv => pv.SizeOption))
                .ForAllMembers(opt => opt.AllowNull());
            

            CreateMap<Domain.Models.ProductItem, GetProductItem>()
                .ForMember(gpi => gpi.ImagesUrl, opt => opt.MapFrom(pi => pi.Images))
                .ForAllMembers(opt => opt.AllowNull());

                
        }
    }
}
