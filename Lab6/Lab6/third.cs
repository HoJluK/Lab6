using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab6
{
    public class Third
    {
    	/*
    	Написать программу для работы с текстовыми файлами, в соответствии с вариантом:
    	Считать текстовый файл, сформировать новый файл, в котором несколько подряд идущих пустых
		строк заменены одной. Вывести на консоль количество удаленных строк.
    	*/
        public static void Execute()
        {
        	string directory = @"C:\Lab6_3";
        	
        	string firstFilePath = directory + "\\lab.txt";
        	string secondFilePath = directory + "\\lab2.txt";
                   	
            string textFromFile = String.Empty;
        	string newText = String.Empty;
        	int countOfVoidStrings = 0;
        	
            using (StreamReader readFromTheFirstFile = new StreamReader(new FileStream(firstFilePath, FileMode.Open)))
        	{
				while (!readFromTheFirstFile.EndOfStream)
				{
					string line = readFromTheFirstFile.ReadLine();
					if (!String.IsNullOrWhiteSpace(line))
					{
						newText += line + "\n";
					}
					else
					{
						line = readFromTheFirstFile.ReadLine();
						if (!String.IsNullOrWhiteSpace(line))
						{
							newText += "\n" + line + "\n";
						}
						countOfVoidStrings++;
					}
				}
        		Console.WriteLine("The text is read");
	        	readFromTheFirstFile.Close();
        	}
            
			File.WriteAllLines(secondFilePath, newText.Split('\n'));
            Console.WriteLine();
			Console.WriteLine("Count of void strings: " + countOfVoidStrings);
            Console.ReadLine();
        }
    }
}
