using System;
using System.Drawing;

namespace AsciiArt
{
    public enum MappingMethod
    {
        Average,
        MinMax,
        Luminosity
    }

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
                    int pixel_brightness = GetBrightness(image.GetPixel(y, x), MappingMethod.Average);

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

        // Maps the RGB value of the pixel to a single brightness value based on the given mapping method. The value is inverted if invert is true. 
        private int GetBrightness(Color pixel, MappingMethod mappingMethod, bool invert = false)
        {
            int brightness;

            if (mappingMethod.Equals(MappingMethod.Luminosity))
            {
                brightness = (int)(0.21 * pixel.R + 0.72 * pixel.G + 0.07 * pixel.B);
            }
            else if (mappingMethod.Equals(MappingMethod.MinMax))
            {
                brightness = (Math.Max(pixel.R, Math.Max(pixel.B, pixel.G)) + Math.Min(pixel.R, Math.Min(pixel.B, pixel.G))) / 2;
            }
            else
            {
                brightness = (pixel.R + pixel.B + pixel.G) / 3;
            }

            if (invert)
            {
                brightness = Math.Abs(brightness - 255);
            }
            return brightness;
        }

        // Printing the ASCII representation of the image.
        public void PrintAsciiRepresentation()
        {
            for (int i = 0; i < asciiRepresentation.GetLength(0); i++)
            {
                for (int j = 0; j < asciiRepresentation.GetLength(1); j++)
                {
                    // Printing each character 3 times to avoid the ASCII representation looking squashed.
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write(asciiRepresentation[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
