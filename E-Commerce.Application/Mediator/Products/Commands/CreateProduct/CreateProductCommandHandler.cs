

using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Application.Exceptions;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Mediator.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler(IProductRepository productService, IMapper mapper,
        IWebHostEnvironment webHostEnvironment,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateProductCommand, ServerResponse>
    {
        public async Task<ServerResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
			var mappedProduct = mapper.Map<Product>(request);
			var index = 0;

			foreach (var item in request.CreateProductItems)
			{
				
				var productImage = new List<ProductImages>();
				foreach (var img in item.Images)
				{
					productImage.Add(await UploadImageAsync(img));
				}

				mappedProduct.ProductItems.ElementAt(index).Images = productImage;
				index += 1;
			}

			mappedProduct.MainImageUrl = (await UploadImageAsync(request.MainImage)).ImageUrl;
            
			

            int result = await productService.AddAsync(mappedProduct);

			if (result == 0)
			{
				return new ServerResponse(false, "Failed To Create Product");
			}

			return new ServerResponse(true, "Product Added Successfully");
		}

		private async Task<ProductImages> UploadImageAsync(IFormFile file)
		{
			var image = new ProductImages();

			// Define folder and file paths
			var folderPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images/Products");
			var localPath = Path.Combine(folderPath, file.FileName);

			// Ensure directory exists
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			// Save the file
			using var stream = new FileStream(localPath, FileMode.Create);
			await file.CopyToAsync(stream);

			// Generate URL for accessing the image
			var httpRequest = httpContextAccessor.HttpContext!.Request;
			var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/Products/{file.FileName}";

			// Assign Variables
			image.ImageUrl = urlPath;
			// Use file.FileName instead of file.Name

			return image;
		}

	}
}
