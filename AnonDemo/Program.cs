using System;

namespace AnonDemo
{

	//class Rectangle
	//{
	//	public int length;
	//	public int height;
	//}

	class Program
	{
		static void Main(string[] args)
		{
			var myrect = new { length = 10, height = 20 , name = "Fred" };
			Console.WriteLine(myrect.length);
			Console.WriteLine(myrect.height);
			Console.WriteLine(myrect.name);
		}
	}
}
