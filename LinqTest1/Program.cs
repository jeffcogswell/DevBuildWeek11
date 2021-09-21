using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqTest1
{
	class Program
	{
		// Delegate concepts

		public delegate int Del(int x, int y); // This behaves like a TYPE not a variable!

		public static int Sum(int x, int y)
		{
			return x + y;
		}

		static void delDemo1()
		{
			Del mydel = Sum;
			int result = mydel(3, 4);
			Console.WriteLine(result);
		}

		static void delDemo2()
		{
			Del mydel = Sum;
			Del mydel2 = Sum;
			Del mydel3 = mydel2;

			int result = mydel(3, 4);
			Console.WriteLine(result);

			result = mydel2(5, 5);
			Console.WriteLine(result);

			result = mydel3(10, 10);
			Console.WriteLine(result);
		}
		// LINQ buildup

		static void demo1()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(str => {
				if (str[0] == 'S')
				{
					return true;
				}
				else
				{
					return false;
				}
			}).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void demo2()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(str => {
				return str[0] == 'S';
			}).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void demo3()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(
				str => str[0] == 'S'
			).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void demo4()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(str => str[0] == 'S').ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void demo5()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			IEnumerable<string> s_names = names.Where(str => str[0] == 'S');

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void demo6()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			// This is where people like to use var!
			//     var s_names = from str in names where str[0] == 'S' select str;
			IEnumerable<string> s_names = from str in names where str[0] == 'S' select str;

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void Main(string[] args)
		{
			delDemo2();
		}
	}
}
