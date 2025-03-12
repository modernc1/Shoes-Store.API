using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Mediator.Categories.Commands.CreateCategory;

internal class CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
	IMapper mapper,
	IWebHostEnvironment webHostEnvironment,
	IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
		var mappedCategory = mapper.Map<Category>(request);
		mappedCategory.ImageUrl = await UploadImageAsync(request.Image);
        int result = await categoryRepository.AddAsync(mappedCategory);

        if(result == 0)
        {
            return new ServerResponse(false, "Failed To Create Category");
        }

        return new ServerResponse(true, "Product Added Successfully");
	}

    private async Task<string> UploadImageAsync(IFormFile file)
	{
		// Define folder and file paths
		var folderPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images/Categories");
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
		var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/Categories/{file.FileName}";

		return urlPath;
	}
}
