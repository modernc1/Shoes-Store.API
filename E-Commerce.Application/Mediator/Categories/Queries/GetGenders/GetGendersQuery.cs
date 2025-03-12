using E_Commerce.Application.DTO.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Mediator.Categories.Queries.GetGenders
{
	public class GetGendersQuery : IRequest<IEnumerable<GetGender>>
	{
		public bool Loaded { get; set; } = true;
	}
}
