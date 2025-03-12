using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Mediator.Products.Commands.UpdateProduct;

internal class UpdateProductCommandHandler(IProductRepository productService,
	IWebHostEnvironment webHostEnvironment,
	IHttpContextAccessor httpContextAccessor,
	IMapper mapper) : IRequestHandler<UpdateProductCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {        
  //      var DbProduct = await productService.GetByIdAsync(request.Id);
  //      if (DbProduct is null) return new ServerResponse(false, "Product Not Found");

		//DbProduct = mapper.Map<Product>(request);
		////
		//if(request.Images != null)
		//{
		//	foreach (var image in request.Images!)
		//	{
		//		DbProduct.Images!.Add(await UploadImageAsync(image, request.Name));
		//	}
		//}


  //      var result = await productService.UpdateAsync(DbProduct);

        //some times result may equal negative number
        return (-1 > 0) ? new ServerResponse(true, "Product Update Successfully") : 
            new ServerResponse(false, "Failed To Update Product");
    }

	//private async Task<ProductImages> UploadImageAsync(IFormFile file, string foldername)
	//{
	//	var image = new ProductImages();

	//	// Define folder and file paths
	//	var folderPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", foldername);
	//	var localPath = Path.Combine(folderPath, file.FileName);

	//	// Ensure directory exists
	//	if (!Directory.Exists(folderPath))
	//	{
	//		Directory.CreateDirectory(folderPath);
	//	}

	//	// Save the file
	//	using var stream = new FileStream(localPath, FileMode.Create);
	//	await file.CopyToAsync(stream);

	//	// Generate URL for accessing the image
	//	var httpRequest = httpContextAccessor.HttpContext!.Request;
	//	var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{foldername}/{file.FileName}";

	//	// Assign Variables
	//	image.ImageUrl = urlPath;
	//	image.Name = file.FileName; // Use file.FileName instead of file.Name

	//	return image;
	//}

	
}
