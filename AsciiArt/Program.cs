using System;
using System.Drawing;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Resizing the image.
            Bitmap original = (Bitmap)Image.FromFile("ascii-pineapple.jpg");
            Bitmap image = new Bitmap(original, new Size(original.Width / 3, original.Height / 3));
                
            // Creating a string that contains 65 characters ordered from thinnest to boldest.
            string asciiChars = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
                
            // Creating a 2d array that will contain the ASCII representation of the image.
            char[,] asciiRepresentation = new char[image.Height, image.Width];

            // Iterating through every pixel in the image.
            for (int x = 0; x < image.Height; x++)
            {
                for (int y = 0; y < image.Width; y++)
                {
                    // Computing the brightness of the pixel as the average of the RBG values.
                    Color pixel = image.GetPixel(y, x);
                    int pixel_brightness = (pixel.R + pixel.B + pixel.G) / 3;

                    // Assigning an ASCII character to the pixel based on the brightness.
                    if (pixel_brightness == 0 || (65 / (255 / pixel_brightness)) - 1 == -1)
                    {
                        asciiRepresentation[x, y] = asciiChars[0];
                    }
                    else
                    {
                        asciiRepresentation[x, y] = asciiChars[(65 / (255 / pixel_brightness)) - 1];
                    }
                }
            }
            // Printing the ASCII representation of the image.
            for (int i = 0; i < asciiRepresentation.GetLength(0); i++)
            {
                for (int j = 0; j < asciiRepresentation.GetLength(1); j++)
                {   
                    Console.Write(asciiRepresentation[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
