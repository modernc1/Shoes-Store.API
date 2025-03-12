using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
