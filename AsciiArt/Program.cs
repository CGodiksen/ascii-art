using System;
using System.Drawing;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating the output directory.
            System.IO.Directory.CreateDirectory("output");

            using (Bitmap image = new Bitmap("ascii-pineapple.jpg"))
            {
                Console.WriteLine("Height: " + image.Height + "\nWidth: " + image.Width);
                for (int x = 0; x < image.Height; x++)
                {
                    for (int y = 0; y < image.Width; y++)
                    {
                        Console.WriteLine($"{x} x {y}: {image.GetPixel(y, x)}");
                    }
                }
            }
        }
    }
}
