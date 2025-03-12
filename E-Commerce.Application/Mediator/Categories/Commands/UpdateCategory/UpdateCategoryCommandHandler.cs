using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace E_Commerce.Application.Mediator.Categories.Commands.UpdateCategory;

internal class UpdateCategoryCommandHandler(ICategoryRepository categoryService,
	IMapper mapper,
	IWebHostEnvironment webHostEnvironment,
	IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
		category.Id = request.Id;
		int result = 0;

        var DbCategory = await categoryService.GetByIdAsync(request.Id);
        if (DbCategory is null)
            return new ServerResponse(false, "Category Not Found");
		if (request.Image != null)
		{
			category.ImageUrl = await UploadImageAsync(request.Image);
			DeleteFile(DbCategory.ImageUrl);
				
		}
		else
		{
			category.ImageUrl = DbCategory.ImageUrl;
		}
		result = await categoryService.UpdateAsync(category);

        //sometimes May return negative number
        return (result > 0) ? new ServerResponse(true, "Category Update Successfully") : new ServerResponse(false, "Failed To Update Category");
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

	private bool DeleteFile(string filePath)
	{
		var index = filePath.IndexOf("Images/");
		var localPath = filePath.Substring(index);
		if (File.Exists(localPath))
		{
			File.Delete(localPath);
			return true;
		}
		return false;
	}
}
