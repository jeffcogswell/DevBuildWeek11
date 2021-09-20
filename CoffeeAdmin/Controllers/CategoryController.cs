using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAdmin.Models;

namespace CoffeeAdmin.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			List<Category> cats = DAL.GetAllCategories();
			return View(cats);
		}

		public IActionResult DeleteCategory(string catid)
		{
			return Content(catid);
		}

	}
}
