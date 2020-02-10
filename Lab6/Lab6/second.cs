using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab6
{
	/*
	Написать программу для работы с бинарными файлами, в соответствии с вариантом:
	Программно записать в бинарный файл набор пар «N – 2^N » для N от 1 до 100. Написать функцию,
	которая считывает из этого файла все вторые числа из каждой пары и записывает во второй файл.
	*/
    public class Second
    {
        public static void Execute()
        {
        	string directory = @"C:\Lab6_2";
        	
        	string firstFilePath = directory + "\\lab.dat";
        	string secondFilePath = directory + "\\lab2.dat";
        	
            string setOfCouples = String.Empty;
            string startWriting = String.Empty;	
            string startFinding = String.Empty;
        	string secondNumbers = String.Empty;        	
        	string startWritingSecondFile = String.Empty;
        	string textFromFile = String.Empty;
        	
			var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        	
        	using (BinaryWriter writeToTheFirstFile = new BinaryWriter(new FileStream(firstFilePath, FileMode.OpenOrCreate)))
        	{
        		while (startWriting != "1")
	            {
		            Console.Write("Enter \"1\" to write set of couples in the first file: ");
		            startWriting = Console.ReadLine();
	            }
	            for (int N = 1; N <= 100; N++)
	            {
	            	setOfCouples += N + " - 2^" + N + "\n";
	            }
				writeToTheFirstFile.Write(setOfCouples);
        		Console.WriteLine("The set is written to file");
        		writeToTheFirstFile.Close();
        	}
        	
        	using (BinaryReader readFromTheFirstFile = new BinaryReader(new FileStream(firstFilePath, FileMode.Open)))
        	{
        		while (startFinding != "2")
	            {
		            Console.Write("Enter \"2\" to find second numbers in the first file: ");
		            startFinding = Console.ReadLine();
	            }
				textFromFile = readFromTheFirstFile.ReadString();
        		Regex numbers = new Regex(@"(\b2)(\^)(\d*\b)");
	        	MatchCollection matches = numbers.Matches(textFromFile);
	        	foreach (Match match in matches)
				{
	        		secondNumbers += match.Value + "\n";
				}
	        	Console.WriteLine("The numbers are found");
	        	readFromTheFirstFile.Close();
        	}
        	
        	using (BinaryWriter writeToTheSecondFile = new BinaryWriter(new FileStream(secondFilePath, FileMode.Create)))
        	{
	        	while (startWritingSecondFile != "3")
	            {
		            Console.Write("Enter \"3\" to write second numbers to the second file: ");
		            startWritingSecondFile = Console.ReadLine();
	            }
				writeToTheSecondFile.Write(secondNumbers);
        		Console.WriteLine("The numbers are written to file");
        		writeToTheSecondFile.Close();
        	}
        	Console.ReadKey();
        }
    }
}
