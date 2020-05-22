using System;
using System.Drawing;

namespace AsciiArt
{
    class AsciiRepresentation
    {
        private readonly Bitmap image;
        private readonly Char[,] asciiRepresentation;
        
        public AsciiRepresentation(Bitmap image)
        {
            this.image = image;

            // Initializing the ASCII representation of the image.
            this.asciiRepresentation = InitializeAsciiArray();
        }
        
        private char[,] InitializeAsciiArray()
        {
            // Creating a string that contains 65 characters ordered from thinnest to boldest.
            string asciiChars = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
            
            char[,] asciiArray = new char[image.Height, image.Width];
            
            // Iterating through every pixel in the image.
            for (int x = 0; x < image.Height; x++)
            {
                for (int y = 0; y < image.Width; y++)
                {
                    // Computing the brightness of the pixel as the average of the RBG values.
                    int pixel_brightness = GetBrightness(image.GetPixel(y, x));

                    // Assigning an ASCII character to the pixel based on the brightness.
                    if (pixel_brightness == 0 || (65 / (255 / pixel_brightness)) - 1 == -1)
                    {
                        asciiArray[x, y] = asciiChars[0];
                    }
                    else
                    {
                        asciiArray[x, y] = asciiChars[(65 / (255 / pixel_brightness)) - 1];
                    }
                }
            }
            return asciiArray;
        }

        private int GetBrightness(Color pixel)
        {
            return (pixel.R + pixel.B + pixel.G) / 3;
        }
        
        // Printing the ASCII representation of the image.
        public void PrintAsciiRepresentation()
        {
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
