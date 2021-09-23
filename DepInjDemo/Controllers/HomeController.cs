using DepInjDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using Dapper;

namespace DepInjDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private MySqlConnection DB;

		public HomeController(ILogger<HomeController> logger, MySqlConnection injectDB)
		{
			_logger = logger;
			DB = injectDB;
		}

		public IActionResult Index()
		{
			// Let's use the DB connection we received via injection
			//IEnumerable<Product> prods = DB.GetAll<Product>();

			IEnumerable<Product> prods = DB.Query<Product>("call GetProdsInCat('COFF')");

			return View(prods);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
