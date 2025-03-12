using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Secrets
{
	public class TapConfiguration
	{
		public string SecretKey { get; set; } = default!;
		public string PublicKey {get; set; } = default!;
		public string BaseUrl {get; set; } = default!;
		public string Currency {get; set; } = default!;
		public string WebhookUrl {get; set; } = default!;

		//add it in service extension to automaticaly load data from json file when inject it inside service as IOptions<TapConfiguration>
	}
}
