using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating the output directory.
            System.IO.Directory.CreateDirectory("output");
            
            using (Image image = Image.Load("ascii-pineapple.jpg"))
            {
                Console.WriteLine("Height: " + image.Height + "\nWidth: " + image.Width);
            }
        }
    }
}
