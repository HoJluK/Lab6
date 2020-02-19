using System;
using System.IO;

namespace Lab6
{
    public class Fourth
    {
    	/*
    	Написать программу, которая создает на одном из разделов жесткого диска директорию Lab6_Temp,
		автоматически копирует в эту директорию ваш файл lab.dat из задания 1
		и создает в ней копию этого файла lab_backup.dat путем побайтового копирования.
		Вывести на консоль информацию о файле lab.dat: размер, время последнего изменения, время последнего доступа.
    	*/
        public static void Execute()
        {
        	string directory = @"C:\Lab6_Temp";
        	string firstFilePath = @"C:\Lab6_1\lab.dat";
        	string copyFilePath = @"C:\Lab6_Temp\lab.dat";
        	string backupFilePath = directory + "\\lab_backup.dat";
        	
        	var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            
            if (File.Exists(copyFilePath))
            {
            	File.Delete(copyFilePath);
            }
            File.Copy(firstFilePath, copyFilePath);
            FileStream originalFile = new FileStream(copyFilePath, FileMode.Open);
            FileStream backupFile = new FileStream(backupFilePath, FileMode.Create);
            originalFile.CopyTo(backupFile);
            
            FileInfo fileInf = new FileInfo(backupFilePath);
            Console.WriteLine("Size of the file: " + fileInf.Length);
            Console.WriteLine("Time of the last changing: " + fileInf.LastWriteTime);
            Console.WriteLine("Time of the last access: " + fileInf.LastAccessTime);
            
            Console.ReadKey();
        }
    }
}
