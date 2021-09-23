using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DepInjDemo.Models
{
	[Table("product")]
	public class Product
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public decimal price { get; set; }
		public string categoryId { get; set; }
		public string username { get; set; }
	}
}
