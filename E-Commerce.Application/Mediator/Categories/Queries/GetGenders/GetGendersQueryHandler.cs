using AutoMapper;
using E_Commerce.Application.DTO.Category;
using E_Commerce.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Categories.Queries.GetGenders
{
	internal class GetGendersQueryHandler(ICategoryRepository categoryRepository,
		IMapper mapper) : IRequestHandler<GetGendersQuery, IEnumerable<GetGender>>
	{
		public async Task<IEnumerable<GetGender>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
		{
			var genders = await categoryRepository.GetGenders(request.Loaded);

			var mappedGenders = mapper.Map<IEnumerable<GetGender>>(genders);

			return mappedGenders;
		}
	}
}
