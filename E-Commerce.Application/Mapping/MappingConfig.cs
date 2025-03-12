using AutoMapper;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.ProducImage;
using E_Commerce.Application.Mediator.Authentications.CreateUser;
using E_Commerce.Application.Mediator.Authentications.LoginUser;
using E_Commerce.Domain.Models;
using E_Commerce.Domain.Models.Cart;
using E_Commerce.Domain.Models.Identity;


namespace E_Commerce.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {   
            
        //Mapping DTOs
            




			CreateMap<ProductImages, string>() //this will allow us to map directly List<string> Images from
			    .ConvertUsing(productImg => productImg.ImageUrl);//List<ProductImages> Images

            CreateMap<ProductImages, GetProductImage>();



            CreateMap<PaymentMethod, GetPaymentMethod>();

        //Mapping Mediators
            CreateMap<CreateUserCommand, AppUser>()
                .ForMember(appuser=> appuser.UserName, opt => opt.MapFrom(c => c.Email))
                .ForMember(appuser=> appuser.PasswordHash, opt => opt.MapFrom(c => c.Password))
                .ForAllMembers(opt => opt.AllowNull());

            CreateMap<LoginUserCommand, AppUser>()
                .ForMember(appuser => appuser.UserName, opt => opt.MapFrom(c => c.Email))
                .ForMember(appuser => appuser.PasswordHash, opt => opt.MapFrom(c => c.Password))
                .ForAllMembers(opt => opt.AllowNull());

            CreateMap<CreateCheckoutHistory, CheckoutHistory>()
                .ForAllMembers(c => c.AllowNull());
            
            CreateMap<CheckoutHistory, GetCheckoutHistory>()
                .ForAllMembers(c => c.AllowNull());
        }
    }
}
