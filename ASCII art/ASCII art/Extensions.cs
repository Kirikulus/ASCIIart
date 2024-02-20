using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ASCII_art
{
    public static class Extensions
    {
        public static void ToGrayScaleFast(this Bitmap bitmap)
        {
            // Using LockBits for fast grayscale conversion
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytesPerPixel = Image.GetPixelFormatSize(PixelFormat.Format24bppRgb) / 8;
            int byteCount = bitmapData.Stride * bitmap.Height;
            byte[] pixels = new byte[byteCount];

            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            for (int y = 0; y < heightInPixels; y++)
            {
                int currentLine = y * bitmapData.Stride;
                for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                {
                    int avg = (pixels[currentLine + x] + pixels[currentLine + x + 1] + pixels[currentLine + x + 2]) / 3;
                    for (int color = 0; color < 3; color++) // Set each color component to the average
                    {
                        pixels[currentLine + x + color] = (byte)avg;
                    }
                }
            }

            Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
            bitmap.UnlockBits(bitmapData);
        }
    }
}

