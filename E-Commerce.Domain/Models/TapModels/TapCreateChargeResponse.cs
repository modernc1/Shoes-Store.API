namespace E_Commerce.Domain.Models.TapModels
{

	public class TapCreateChargeResponse
	{
		public string id { get; set; }
		public string _object { get; set; }
		public bool live_mode { get; set; }
		public bool customer_initiated { get; set; }
		public string api_version { get; set; }
		public string method { get; set; }
		public string status { get; set; }
		public int amount { get; set; }
		public string currency { get; set; }
		public bool threeDSecure { get; set; }
		public bool card_threeDSecure { get; set; }
		public bool save_card { get; set; }
		public string product { get; set; }
		public string description { get; set; }
		public Metadata metadata { get; set; }
		public Order order { get; set; }
		public Transaction transaction { get; set; }
		public Reference reference { get; set; }
		public Response response { get; set; }
		public Receipt receipt { get; set; }
		public Customer customer { get; set; }
		public Merchant merchant { get; set; }
		public Source source { get; set; }
		public Redirect redirect { get; set; }
		public Post post { get; set; }
		public Activity[] activities { get; set; }
		public bool auto_reversed { get; set; }
	}

	public class Metadata
	{
		public string udf1 { get; set; }
	}

	public class Order
	{
	}

	public class Transaction
	{
		public string timezone { get; set; }
		public string created { get; set; }
		public string url { get; set; }
		public Expiry expiry { get; set; }
		public bool asynchronous { get; set; }
		public int amount { get; set; }
		public string currency { get; set; }
		public Date date { get; set; }
	}

	public class Expiry
	{
		public int period { get; set; }
		public string type { get; set; }
	}

	public class Date
	{
		public long created { get; set; }
		public long transaction { get; set; }
	}

	public class Reference
	{
		public string transaction { get; set; }
		public string order { get; set; }
	}

	public class Response
	{
		public string code { get; set; }
		public string message { get; set; }
	}

	public class Receipt
	{
		public bool email { get; set; }
		public bool sms { get; set; }
	}

	public class Customer
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public Phone phone { get; set; }
	}

	public class Phone
	{
		public string country_code { get; set; }
		public string number { get; set; }
	}

	public class Merchant
	{
		public string country { get; set; }
		public string currency { get; set; }
		public string id { get; set; }
	}

	public class Source
	{
		public string _object { get; set; }
		public string type { get; set; }
		public string payment_type { get; set; }
		public string channel { get; set; }
		public string id { get; set; }
		public bool on_file { get; set; }
		public string payment_method { get; set; }
	}

	public class Redirect
	{
		public string status { get; set; }
		public string url { get; set; }
	}

	public class Post
	{
		public string status { get; set; }
		public string url { get; set; }
	}

	public class Activity
	{
		public string id { get; set; }
		public string _object { get; set; }
		public long created { get; set; }
		public string status { get; set; }
		public string currency { get; set; }
		public int amount { get; set; }
		public string remarks { get; set; }
		public string txn_id { get; set; }
	}

}
