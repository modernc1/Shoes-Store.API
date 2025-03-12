using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.TapModels
{

	public class TapCreateChargeRequest
	{
		public required decimal amount { get; set; }
		public required string currency { get; set; }

		//This parameter determines whether the charge was initiated by customer or not
		public bool customer_initiated { get; set; }
		public bool threeDSecure { get; set; }
		public bool save_card { get; set; } = false;
		public string? description { get; set; }
		public Metadata metadata { get; set; } = default!;
		//public Receipt receipt { get; set; } //no longer supported
		public Reference reference { get; set; } = default!;
		public required Customer customer { get; set; }
		public Merchant merchant { get; set; } = default!;
		public required Source source { get; set; }
		public Post post { get; set; }
		public required Redirect redirect { get; set; }
	}

	//public class Receipt
	//{
	//	public bool email { get; set; }
	//	public bool sms { get; set; }
	//}

}
