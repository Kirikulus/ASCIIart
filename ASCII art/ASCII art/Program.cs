using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ASCII_art
{
    internal class Program
    {
        private const double WIDTH_OFFSET = 2.0;
        private const int MAX_WIDTH = 1000;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
                };

                while (true)
                {
                    Console.WriteLine("Press Enter to select an image...");
                    Console.ReadLine();

                    if (openFileDialog.ShowDialog() != DialogResult.OK) continue;

                    Console.Clear();

                    using (var bitmap = new Bitmap(openFileDialog.FileName))
                    {
                        var resizedBitmap = ResizeBitmap(bitmap);
                        resizedBitmap.ToGrayScaleFast();

                        var converter = new BitmapToASCIIConverter(resizedBitmap);
                        var rows = converter.Convert();

                        foreach (var row in rows)
                            Console.WriteLine(row);

                        File.WriteAllLines("image.txt", rows.Select(r => new string(r)));

                        Console.SetCursorPosition(0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
            {
                return new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
            }

            return bitmap;
        }
    }
}
