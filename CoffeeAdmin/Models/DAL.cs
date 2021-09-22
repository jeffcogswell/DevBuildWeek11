using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace CoffeeAdmin.Models
{
	public class DAL
	{
		public static string CurrentUser = null;
		public static MySqlConnection DB;

		// Category Table

		// "R" Read all, read one

		public static List<Category> GetAllCategories()
		{
			return DB.GetAll<Category>().ToList();
		}

		public static Category GetCategory(string id)
		{
			return DB.Get<Category>(id);
		}

		// "C" Create (Insert) into category table

		public static void InsertCategory(Category cat)
		{
			cat.username = DAL.CurrentUser;
			DB.Insert(cat);
		}

		// "U" Update in category table
		// Do we even need this one? Yeah probably
		public static void UpdateCategory(Category cat)
		{
			//
			// Category { id = "COFF", description = "New description" }
			//
			//
			cat.username = DAL.CurrentUser;
			DB.Update(cat);
		} 

		// "D" Delete from category table
		public static void DeleteCategory(string id)
		{
			Category cat = new Category() { id = id };
			DB.Delete(cat);
		}

		// Product Table

		// Example of where we would operate on more than one table
		public static void AddProductAndCategory(Product prod, Category cat)
		{
			cat.username = DAL.CurrentUser;
			prod.username = DAL.CurrentUser;
			DB.Insert(cat);
			DB.Insert(prod);
		}

		public static CategoryProducts GetAllForCategory(string theCatId)
		{
			// We're going to build an SQL query that looks like this:
			//    select * from product where categoryId = 'COFF' (for example)
			// We need a key-value pair of some name, we'll say catId
			// and its value will be the category such as COFF.
			//    e.g.   catId = "COFF"
			// Then we'll let dapper build our query SQL for us,
			// replacing our key with the value e.g.:
			//    select * from product where categoryId = @catId
			// And what will happen is the @catId will get replaced with COFF

			// Let's make our "key value pair list" first. We'll use
			// an anonymous object.

			var keyvalues = new { catId = theCatId };

			string sql = "select * from product where categoryId = @catId";  // Code in another language, stored in a string!
			// Dapper will replace @catId with the value in our keyvalues object
			// e.g.       select * from product where categoryId = 'COFF'
			// It will handle the single quotes for us so we don't have to.
			// We hand over to dapper our starter SQL string and our keyvalue list.

			CategoryProducts cp = new CategoryProducts();
			cp.prods = DB.Query<Product>(sql, keyvalues).ToList();
			cp.cat = DAL.GetCategory(theCatId);
			return cp;
		}

		public static Product GetProduct(int prodId)
		{
			return DB.Get<Product>(prodId);
		}


		// "C" Create (Insert) into product table

		public static void InsertProduct(Product prod)
		{
			prod.username = DAL.CurrentUser;
			DB.Insert(prod);
		}

		// "U" Update in product table
		// Do we even need this one? Yeah probably
		public static void UpdateProduct(Product prod)
		{
			prod.username = DAL.CurrentUser;
			// Need to test fields left out!
			DB.Update(prod);
		}

		// "D" Delete from product table
		public static void DeleteProduct(int id)
		{
			Product prod = new Product() { id = id };
			DB.Delete(prod);
		}

		public static List<Product> SearchProduct(string str)
		{
			// Build a SQL string like this:
			//    select * from product where description like '%En%' or name like '%En%';
			var keyvaluepair = new { search = $"%{str}%" };
			string sql = "select * from product where description like @search or name like @search";
			return DB.Query<Product>(sql, keyvaluepair).ToList();
		}


	}
}
