ASCII Art Generator

Overview
This ASCII Art Generator is a console application written in C# that converts images into ASCII art. ASCII art is a graphic design technique that uses printable characters from the ASCII standard to create images. This program maps the brightness of the pixels in an image to a set of characters, with darker pixels represented by characters that have more visual weight and lighter pixels by those that are more sparse.

Features
Image to ASCII Conversion: Converts images (.bmp, .png, .jpg, .JPEG formats supported) into ASCII art by mapping the pixel brightness to a predefined set of ASCII characters.
Grayscale Conversion: Transforms the original image into grayscale to enhance the ASCII art representation by focusing on brightness rather than color.
Image Resizing: Automatically resizes images to a maximum width of 800 pixels to ensure the ASCII art fits comfortably in standard console windows and to maintain aspect ratio.
Export ASCII Art: The generated ASCII art is displayed in the console window and also saved to a text file (image.txt), allowing for easy sharing and viewing.

How to Use
1) Compile and Run the Program: Start the application by compiling and running the Program.cs file in a C# compatible IDE or compiler.
2) Initiate Image Selection: After the program starts, press Enter to open the file dialog for image selection.
3) Select an Image: The program will prompt you to select an image file through a file dialog. You can choose any image in supported formats (.bmp, .png, .jpg, .JPEG).
4) View ASCII Art: After selecting an image, the program will process it and display the resulting ASCII art in the console window.
5) Export: The ASCII art is automatically saved to image.txt in the application's running directory. You can open this file to view the ASCII art or share it.

Requirements
.NET Framework or .NET Core compatible environment to compile and run the C# application.
A console or terminal that supports C# console applications.
Customization
The ASCII art mapping can be customized by modifying the _asciiTable array in BitmapToASCIIConverter.cs. This array defines the characters used for different brightness levels, with the first character representing the darkest pixel and the last character representing the lightest pixel.

Enjoy creating unique ASCII representations of your favorite images with this simple yet powerful ASCII Art Generator!
 
![image](https://github.com/Kirikulus/ASCIIart/assets/64729961/7ad14dff-6075-4611-b4b9-f951742df49c)
![image](https://github.com/Kirikulus/ASCIIart/assets/64729961/2f246493-b164-47f8-9c02-047be6db0142)
![image](https://github.com/Kirikulus/ASCIIart/assets/64729961/c8e72a28-a90e-421d-8527-c1d7bb3dcbdc)

