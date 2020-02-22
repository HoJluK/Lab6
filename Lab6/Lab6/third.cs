using System;
using System.IO;

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
                   	
        	string newText = String.Empty;
        	int countOfVoidStrings = 0;

            string[] text = File.ReadAllLines(firstFilePath);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != "")
                    newText += text[i] + "\n";
                else if (text[i+1] != "")
                {
                    newText += "\n" + text[i + 1] + "\n";
                    i++;
                }
                else
                    countOfVoidStrings++;
            }
            
			File.WriteAllLines(secondFilePath, newText.Split('\n'));
            Console.WriteLine();
			Console.WriteLine("Count of void strings: " + countOfVoidStrings);
            Console.ReadLine();
        }
    }
}
