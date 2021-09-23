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
			if (DAL.CurrentUser == null)
			{
				return Redirect("/");
			}
			List<Category> cats = DAL.GetAllCategories();
			return View(cats);
		}

		public IActionResult DeleteCategory(string catid)
		{
			return Content(catid);
		}

		public IActionResult AddCategoryForm()
		{
			if (DAL.CurrentUser == null)
			{
				return Redirect("/");
			}
			// This action repsents the user with a form for adding a new category
			return View();
		}

		[HttpPost]
		public IActionResult SaveCategory(Category cat)
		{
			if (DAL.CurrentUser == null)
			{
				return Redirect("/");
			}
			// This action saves the category after a user filled in the form from AddCategoryForm
			DAL.InsertCategory(cat);
			return Redirect("/Category");
		}

		public IActionResult EditCategoryForm(string catID)
		{
			if (DAL.CurrentUser == null)
			{
				return Redirect("/");
			}
			// Load the item that the user wants to edit so we can prepopulate the form with the existing data.
			Category cat = DAL.GetCategory(catID);
			// Make sure the user is allowed to edit this category. Either the username is admin, or the username matches what's in the category
			// But to do this, make sure we actually found a category by making sure it isn't null.
			// Pay close attention to the parentheses in my and's and or's!
			if (cat != null && (DAL.CurrentUser == "admin" || DAL.CurrentUser == cat.username))
			{
				// Allowed
				return View(cat);
			}
			else
			{
				// Not allowed
				return View(null);
			}
		}

		[HttpPost]
		public IActionResult UpdateCategory(Category cat)
		{
			// The DAL itself will check if the user is authorized to save it.
			DAL.UpdateCategory(cat);
			return Redirect("/Category");
		}

	}
}
