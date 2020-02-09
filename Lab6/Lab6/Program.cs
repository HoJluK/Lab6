using System;
using System.IO;

namespace Lab6
{
	class Program
	{
		static void Main(string[] args)
		{
			int select;
			Console.Write("Choose the task from 1 to 5: ");
			select = int.Parse(Console.ReadLine());
			Console.WriteLine();
			switch (select) {
				case 1:
					Console.WriteLine("The first task: \n");
					First.Execute();
					break;
				case 2:
					Console.WriteLine("The second task: \n");
					Second.Execute();
					break;
				case 3:
					Console.WriteLine("The third task: \n");
					Third.Execute();
					break;
				case 4:
					Console.WriteLine("The fourth task: \n");
					Fourth.Execute();
					break;
				case 5:
					Console.WriteLine("The fifth task: \n");
					Fifth.Execute();
					break;
				default:
					break;
			}
		}
	}
}