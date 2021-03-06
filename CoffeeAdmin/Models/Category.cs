using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace CoffeeAdmin.Models
{
	[Table("category")]
	public class Category
	{
		[ExplicitKey]
		public string id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string username { get; set; }
	}
}
