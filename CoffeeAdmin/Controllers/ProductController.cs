using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAdmin.Models;

namespace CoffeeAdmin.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ListProducts(string catid)
		{
			CategoryProducts prods = DAL.GetAllForCategory(catid);
			return View(prods);
		}

		public IActionResult IncreasePrice(int prodid)
		{
			Product prod = DAL.GetProduct(prodid);
			prod.price++;
			DAL.UpdateProduct(prod);
			// Let's revisit RedirectToAction later!
			// Need to build an anonymous object to set catid.
			//return RedirectToAction()
			return Redirect($"/Product/ListProducts?catid={prod.categoryId}");
		}
	}
}
