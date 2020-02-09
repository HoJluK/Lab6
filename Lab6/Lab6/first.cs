using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab6
{
	/*
    Дополнить код лабораторной работы №5, организовав хранение данных
	предметной области в бинарном ( четные варианты ) или текстовом ( нечетные
	варианты ) файле lab.dat. Данные должны считываться из файла при запуске
	программы и записываться в файл при закрытии программы.
	*/
    public class First
    {
    	enum Pos
        {
        	П,
        	С,
        	А
        }
        
        struct Worker
        {
            public string surname;
            public Pos position;
            public int year;
            public decimal salary;

            public void showTable()
            {
            	Console.WriteLine("Surname{0, -13} Position{0, -12} Birth year{0, -10} Salary{0, -14}", " ");
                Console.WriteLine("{0, -20} {1, -20} {2, -20} {3, -20}", surname, position, year, salary);
                Console.WriteLine();
            }
        }
        
        struct Log 
		{
			public DateTime time;
			public string operation;
			public string name;

			public void logOutput() 
			{
				Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
			}
		}
        public static void Execute()
        {
        	var table = new List<Worker>();
        	
        	string directory = @"C:\Lab6_1";
        	var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string path = directory + "\\lab.dat";
            StreamReader readFile = new StreamReader(path);
            using (readFile)
        	{
            	while (readFile.Peek() != -1)
                {
                    string surname = readFile.ReadLine();
					string pos = readFile.ReadLine();
					var position = Pos.А;
					if (pos == "П")
							{
								position = Pos.П;
							}
							else if (pos == "С")
							{
								position = Pos.С;
							}
							else if (pos == "А")
							{
								position = Pos.А;
							}
					int year = int.Parse(readFile.ReadLine());
					decimal salary = decimal.Parse(readFile.ReadLine());
					Worker newWorker;
					newWorker.surname = surname;
					newWorker.position = position;
					newWorker.year = year;
					newWorker.salary = salary;
					table.Add(newWorker);
                }
        	}
        	
			var logOfSession = new List<Log>(50);			
			DateTime firstTime = DateTime.Now;
			DateTime secondTime = DateTime.Now;
			TimeSpan downtime = secondTime - firstTime;
			
			bool working = true;
			bool error = true;
			do
			{
				Console.WriteLine("Select an action:");
				Console.WriteLine("1 - View the table");
				Console.WriteLine("2 - Add a record");
				Console.WriteLine("3 - Delete a record");
				Console.WriteLine("4 - Update a record");
				Console.WriteLine("5 - Search a record");
				Console.WriteLine("6 - Show log");
				Console.WriteLine("7 - Exit");
				int selector = int.Parse(Console.ReadLine());
				if (selector == 1)
				{
					for (int i = 0; i < table.Count; i++)
					{
						table[i].showTable();
					}
					Console.WriteLine();
				}
				if (selector == 2)
				{
					Console.Write("Enter the surname: ");
					string surname = Console.ReadLine();
					var position = Pos.А;
					int year = 0;
					decimal salary = 0;
					do
					{
						Console.Write("Enter the position in Russian (П, С, А): ");
						string pos = Console.ReadLine();
							if (pos == "П")
							{
								position = Pos.П;
								error = false;
							}
							else if (pos == "С")
							{
								position = Pos.С;
								error = false;
							}
							else if (pos == "А")
							{
								position = Pos.А;
								error = false;
							}
							else
							{
								Console.WriteLine("Enter the correct position!");
								Console.WriteLine();
							}
					}
					while (error);
					error = true;
					do
					{
						Console.Write("Enter the year of birth: ");
						try
						{
							year = int.Parse(Console.ReadLine());
							error = false;
						}
						catch (FormatException)
						{
							year = 0;
							Console.WriteLine("Enter the correct year!");
						}
					}
					while (error);
					error = true;
					do
					{
						Console.Write("Enter the salary: ");
						try
						{
							salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
							error = false;
						}
						catch (FormatException)
						{
							salary = 0;
							Console.WriteLine("Enter the correct salary!");
						}
					}
					while (error);
					error = true;
					
					Worker newWorker;
					newWorker.surname = surname;
					newWorker.position = position;
					newWorker.year = year;
					newWorker.salary = salary;
					table.Add(newWorker);
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record added";
					newLog.name = surname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 3)
				{
					int number = 0;
					string surname = string.Empty;
					do
					{
						Console.WriteLine("Choose the number of row to delete: ");
						number = int.Parse(Console.ReadLine());
						if (number > 0 && number <= table.Count)
						{
							surname = table[number-1].surname;
							table.RemoveAt(number - 1);
							error = false;
						}
						else
						{
							Console.WriteLine("Enter the correct number!");
						}
					}
					while (error);
					error = true;
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record deleted";
					newLog.name = surname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 4)
				{
					string oldSurname = string.Empty;
					string surname = string.Empty;
					var position = Pos.А;
					int year = 0;
					decimal salary = 0;
					int number = 0;
					do
					{
						Console.WriteLine("Choose the number of row to update: ");
						number = int.Parse(Console.ReadLine());
						if (number > 0 && number <= table.Count)
						{
							oldSurname = table[number - 1].surname;
							Console.Write("Enter the surname: ");
							surname = Console.ReadLine();
							do
							{
								Console.Write("Enter the position in Russian (П, С, А): ");
								string pos = Console.ReadLine();
								if (pos == "П")
								{
									position = Pos.П;
									error = false;
								}
								else if (pos == "С")
								{
									position = Pos.С;
									error = false;
								}
								else if (pos == "А")
								{
									position = Pos.А;
									error = false;
								}
								else
								{
									Console.WriteLine("Enter the correct position!");
									Console.WriteLine();
								}
							}
							while (error);
							error = true;
							do
							{
								Console.Write("Enter the year of birth: ");
								try
								{
									year = int.Parse(Console.ReadLine());
									error = false;
								}
								catch (FormatException)
								{
									year = 0;
									Console.WriteLine("Enter the correct year!");
								}
							}
							while (error);
							error = true;
							do
							{
								Console.Write("Enter the salary: ");
								try
								{
									salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
									error = false;
								}
								catch (FormatException)
								{
									salary = 0;
									Console.WriteLine("Enter the correct salary!");
								}
							}
							while (error);
						}
						else
						{
							Console.WriteLine("Enter the correct number!");
						}
					}
					while (error);
					error = true;
					
					Worker editWorker;
					editWorker.surname = surname;
					editWorker.position = position;
					editWorker.year = year;
					editWorker.salary = salary;
					table.Insert(number - 1, editWorker);
					table.Remove(table[number]);
					
					Log newLog;
					newLog.time = DateTime.Now;
					newLog.operation = "Record updated";
					newLog.name = oldSurname + " --> " + surname;
					logOfSession.Add(newLog);
					
					firstTime = newLog.time;
					TimeSpan secondDowntime = firstTime - secondTime;
					if(downtime < secondDowntime)
					{
						downtime = secondDowntime;
					}
					secondTime = newLog.time;
					Console.WriteLine();
				}
				if (selector == 5)
				{
					var pos = Pos.П;
					do
					{
						Console.WriteLine("П - teachers");
						Console.WriteLine("С - students");
						Console.WriteLine("А - graduate students");
						Console.WriteLine("Enter who you want to find (russian letter): ");
						string select = Console.ReadLine();
						Console.WriteLine();
						if (select == "П" || select == "С" || select == "А")
						{
							if (select == "П")
								pos = Pos.П;
							if (select == "С")
								pos = Pos.С;
							if (select == "А")
								pos = Pos.А;
							for (int i = 0; i < table.Count; i++)
							{
								if (table[i].position == pos)
								{
									table[i].showTable();
								}
							}
							error = false;
						}
						else
						{
							Console.WriteLine("Enter in the correct form!");
						}
					}
					while (error);
					error = true;
					Console.WriteLine();
				}
				if (selector == 6)
				{
					for (int i = 0; i < logOfSession.Count; i++)
					{
						logOfSession[i].logOutput();
					}
					Console.WriteLine();
					Console.WriteLine(downtime + " - the largest downtime");
					Console.WriteLine();
				}
				if (selector == 7)
				{
					using (StreamWriter newText =  new StreamWriter(path, false))
					{
						for (int i = 0; i < table.Count; i++)
						{
							newText.WriteLine("{0}\n{1}\n{2}\n{3}", table[i].surname, table[i].position, table[i].year, table[i].salary);
						}
					}
					working = false;
				}
				if (selector < 1 || selector > 7)
				{
					Console.WriteLine("Choose the correct action!");
					Console.WriteLine();
				}
			}
			while (working);
			Console.WriteLine();
        }
    }
}
