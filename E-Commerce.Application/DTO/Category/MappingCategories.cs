using AutoMapper;
using E_Commerce.Domain.Models;
namespace E_Commerce.Application.DTO.Category
{
	public class MappingCategories : Profile
	{
        public MappingCategories()
        {
			CreateMap<Domain.Models.Category, CreateCategoryDTO>();
			CreateMap<CreateCategoryDTO, Domain.Models.Category>();
			CreateMap<GetCategory, Domain.Models.Category>();
			CreateMap<Domain.Models.Category, GetCategory>();
			CreateMap<UpdateCategoryDTO, Domain.Models.Category>()
				.ForMember(c => c.ImageUrl, opt => opt.AllowNull());

			CreateMap<ProductGender, GetGender>();
			CreateMap<Domain.Models.Category, PCategory>()
				.ForAllMembers(opt => opt.AllowNull());
		}
    }
}
