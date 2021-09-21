using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
	class Program
	{

		public static int Sum(int x, int y)
		{
			return x + y;
		}

		public static int Square(int x)
		{
			return x * x;
		}

		public static int Cube(int x)
		{
			return x * x * x;
		}

		delegate int TwoInts(int x, int y); // Think of this as a type for a variable that can "hold a function"

		delegate int OneInt(int x); // This is a type for variables that take a single int as a parameter and return a single int

		static void test(OneInt func)
		{
			int res = func(3);
			Console.WriteLine("Inside the test function. Result is:");
			Console.WriteLine(res);
		}

		static void LinqDemo1()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(
				str =>
				{
					if (str[0] == 'S')
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void LinqDemo2()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			List<string> s_names = names.Where(
				str =>
				{
					return str[0] == 'S';
				}
			).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void LinqDemo3()
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

		static void LinqDemo4()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };
			IEnumerable<string> s_names = names.Where(str => str[0] == 'S'); // Apply this function to each member in the list.
			// I'm returning each item in the list where its first letter is S. It's like a WHERE clause in SQL.
			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void LinqDemo5()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };
			IEnumerable<string> s_names = 
				from str in names where str[0] == 'S' select str;
			// This works just like a SQL statement, just rearranged.

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void Main(string[] args)
		{
			// Delegate Demos

			//int result = Sum(5, 6);
			//Console.WriteLine(result);

			//TwoInts AnotherFunc = Sum;
			//int result2 = AnotherFunc(5, 6);
			//Console.WriteLine(result2);

			//TwoInts YetAnother = AnotherFunc;
			//int result3 = YetAnother(5, 6);
			//Console.WriteLine(result3);

			//OneInt myfunc = Square;
			//int result4 = myfunc(4);
			//Console.WriteLine(result4);

			//myfunc = Cube;
			//int result5 = myfunc(4);
			//Console.WriteLine(result5);

			//test(Square);
			//test(Cube);

			// Lambda demos

			//test(
			//	// Let's pass in a statement lambda
			//	(x) =>
			//	{
			//		Console.WriteLine("We are inside an anonymous function");
			//		return x + x + x + x;
			//	}
			//);

			//// Let's pass in a lambda expression
			//test(
			//	(x) =>
			//		x + x + x + x + x
			//);

			//// Let's pass in another lambda expression
			//test(
			//	x => x + 2
			//);

			// Linq Demos
			LinqDemo5();
		}
	}
}
