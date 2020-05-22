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

            AsciiRepresentation asciiRepresentation = new AsciiRepresentation(image);

            asciiRepresentation.PrintAsciiRepresentation();
        }
    }
}
