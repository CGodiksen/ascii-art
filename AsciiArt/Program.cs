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
                // Creating a 2d array that will contain the brightness for each pixel in the image.
                int[,] brightness = new int[image.Height, image.Width];

                Console.WriteLine("Height: " + image.Height + "\nWidth: " + image.Width);
                for (int x = 0; x < image.Height; x++)
                {
                    for (int y = 0; y < image.Width; y++)
                    {
                        // Computing the brightness of the pixel as the average of the RBG values.
                        Color pixel = image.GetPixel(y, x);
                        brightness[x, y] = (pixel.R + pixel.B + pixel.G) / 3;
                        
                    }
                }
                // Iterating through the 2d brightness array and printing each pixels brightness.
                for (int i = 0; i < brightness.GetLength(0); i++)
                {
                    for (int j = 0; j < brightness.GetLength(1); j++)
                    {
                        Console.WriteLine(brightness[i, j]);
                    }
                }
            }
        }
    }
}
