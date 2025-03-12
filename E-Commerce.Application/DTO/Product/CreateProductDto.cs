﻿using E_Commerce.Application.DTO.Category;
using E_Commerce.Application.DTO.Product.ProductItem;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTO.Product
{
	public class CreateProductDto
	{
		public string Name { get; set; } = default!;
		public string Description { get; set; } = default!;
		public Guid CategoryId { get; set; }
		public string Materials { get; set; } = default!;
		public IFormFile MainImage { get; set; } = default!;
		[Required]
		[MinLength(1)]
		public ICollection<CreateProductItemDto> CreateProductItems { get; set; } = [];
	}
}
