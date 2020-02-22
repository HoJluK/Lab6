using System;
using System.IO;

namespace Lab6
{
    public class Fifth
    {
    	/*
    	Написать программу, которая позволяет ввести имя bmp-файла, считать его
		заголовки и вывести на консоль информацию о размере файла, ширине и
		высоте в пикселях, количестве бит на пиксель, разрешении горизонтальном
		и вертикальном (количестве пикселей на метр), типе сжатия ( без сжатия / 4бит
		RLE / 8бит RLE ). Подготовьте несколько файлов изображений и проверьте на
		них Вашу программу. Структура bmp-файла приведена в приложении В.
    	*/
        public static void Execute()
        {
        	Console.WriteLine("Choose picture to recieve its information (1, 2, 3): ");
        	string choosenPicture = Console.ReadLine();
        	string firstPicturePath = @"C:\Lab6_5\1.bmp";
        	string secondPicturePath = @"C:\Lab6_5\2.bmp";
        	string thirdPicturePath = @"C:\Lab6_5\3.bmp";
        	if (choosenPicture == "1")
        		choosenPicture = firstPicturePath;
        	if (choosenPicture == "2")
        		choosenPicture = secondPicturePath;
        	if (choosenPicture == "3")
        		choosenPicture = thirdPicturePath;
        	BinaryReader picture = new BinaryReader(new FileStream(choosenPicture, FileMode.Open));
			picture.ReadChars(2);
        	int size = picture.ReadInt32();
        	Console.WriteLine("Size: {0} byte", size);
        	picture.ReadInt16();
        	picture.ReadInt16();
        	picture.ReadInt32();
        	picture.ReadInt32();
        	int width = picture.ReadInt32();
        	Console.WriteLine("Width in pixels: {0} pixels", width);
        	int height = picture.ReadInt32();
        	Console.WriteLine("Height in pixels: {0} pixels", height);
        	picture.ReadInt16();
        	short bitPerPixel = picture.ReadInt16();
        	Console.Write("Bit/pixel: {0}, ", bitPerPixel);
        	if (bitPerPixel == 1)
        		Console.WriteLine("monochrome palette, 2 colours");
        	if (bitPerPixel == 4)
        		Console.WriteLine("4bit palletized, 16 colours");
        	if (bitPerPixel == 8)
        		Console.WriteLine("8bit palletized, 256 colours");
        	if (bitPerPixel == 16)
        		Console.WriteLine("16bit RGB, 65536 colours");
        	if (bitPerPixel == 24)
        		Console.WriteLine("24bit RGB, 16M colours");
        	int compressionType = picture.ReadInt32();
        	if (compressionType == 0)
        		Console.WriteLine("Compression type: without compression");
        	if (compressionType == 1)
        		Console.WriteLine("Compression type: 8 bit RLE compression");
        	if (compressionType == 2)
        		Console.WriteLine("Compression type: 4 bit RLE compression");
        	picture.ReadInt32();
        	int gorizontalResolution = picture.ReadInt32();
        	Console.WriteLine("Gorizontal resolution: {0} pixels/m", gorizontalResolution);
        	int verticalResolution = picture.ReadInt32();
        	Console.WriteLine("Vertical resolution: {0} pixels/m", verticalResolution);
        	Console.ReadKey();
        }
    }
}
