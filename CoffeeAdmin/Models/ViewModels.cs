using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeAdmin.Models
{
	public class CategoryProducts
	{
		public Category cat { get; set; }
		public List<Product> prods { get; set; }
	}
}
