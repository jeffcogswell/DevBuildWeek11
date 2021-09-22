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

		public static int Double(int x)
		{
			return x * 2;
		}

		delegate int TwoInts(int x, int y); // Think of this as a type for a variable that can "hold a function"

		delegate int OneInt(int x); // This is a type for variables that take a single int as a parameter and return a single int

		static void ReceiveFunction(OneInt func)
		{
			int res = func(3);
			Console.WriteLine("Inside the test function. Result is:");
			Console.WriteLine(res);
		}

		static void NonLinq()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };
			List<string> s_names = new List<string>();
			foreach (string name in names)
			{
				if (name[0] == 'S')
				{
					s_names.Add(name);
				}
			}

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}

		}


		/*
		 * COMMENTS REGARDING THE BELOW FUNCTION CALLED CheckFirstLetter
		if (name[0] == 'S')
		{
			// the expression evaluated to true. So return true (i.e. the same value as the expression)
			return true;
		}
		else
		{
			// The expression evaluated to false. So return false (i.e. the same value as the expression)
			return false;
		}
		*/
		// The above code is identical to the below code.
		// Just return the value of the expression itself
		static bool CheckFirstLetter(string name)
		{
			return name[0] == 'S';
		}

		static void NonLinq2()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };
			List<string> s_names = new List<string>();
			foreach (string name in names)
			{
				if (CheckFirstLetter(name))
				{
					s_names.Add(name);
				}
			}

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}

		}

		static bool anothertest(string x)
		{
			return true;
		}

		static void LinqDemo0()
		{
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };

			// "Where" calls the function on every item in the list. (It "applies" the function to each item.)
			// If the function returns true, Where adds the item to the result list.
			// You can see why C# needed the ability to pass a function as a parameter in order to make this work.
			// As an exercise, try passing in different functions into Where.
			List<string> s_names = names.Where(CheckFirstLetter).ToList();

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
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
			// Self study: look up IEnumerable in the docs
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

			// Exercise: What will the following produce:
			//IEnumerable<string> s_names =
			//	from str in names where true select str;

			// This works just like a SQL statement, just rearranged.
			// We're doing a query right inside the C# language itself.
			// This is a "language-integrated query".
			// LINQ = Langing INtegrated Query

			foreach (string name in s_names)
			{
				Console.WriteLine(name);
			}
		}

		static void LinqDemo6()
		{
			// Final piece of Linq: The var "type".
			List<string> names = new List<string>() { "Sam", "Julia", "Fred", "Sally" };
			var s_names = from str in names where str[0] == 'S' select str;
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

			//ReceiveFunction(Square);
			//ReceiveFunction(Cube);
			//ReceiveFunction(Double);
			//ReceiveFunction(Sum); // Error! Signature doesn't match

			// Lambda demos
			Console.WriteLine("Break!");
			//ReceiveFunction(
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
			//ReceiveFunction(
			//	x => x + 2
			//);

			// This line is an entire function:
			//      x => x + 2
			// How does the compiler know the types??? We don't have "int" before the x.
			// It knows the type based on how we're using the lambda function.
			// The ReceiveFunction function takes only functions of a particular signature.
			// So the compiler uses *that* signature to figure out the types.

			// Linq Demos
			LinqDemo5();

			//bool tf = (5 == 10);
			//Console.WriteLine(tf);

		}
	}
}
