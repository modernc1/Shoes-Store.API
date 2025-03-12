
using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.Cart;
using E_Commerce.Domain.Models.Cart;
using E_Commerce.Domain.Models.TapModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.Mediator.Cart.Commands.CreateCheckout
{
    public class CreateCheckoutCommand : IRequest<TapCreateChargeResponse?>
    {
        [Required]
        public required string PaymentMethod { get; set; } = default!;
        [Required]
        public required IEnumerable<ProcessCart> CartItems { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
