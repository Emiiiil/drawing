using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int x = 10, y = 10;
        char currentChar = '█';
        ConsoleColor currentColor = ConsoleColor.White;
        ConsoleKey key;
        List<(int, int, char, ConsoleColor)> drawings = new List<(int, int, char, ConsoleColor)>();

        while (true)
        {
            Console.Clear();

            foreach (var drawing in drawings)
            {
                Console.SetCursorPosition(drawing.Item1, drawing.Item2);
                Console.ForegroundColor = drawing.Item4;
                Console.Write(drawing.Item3);
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Aktív telítettség: {currentChar} | Aktív szín: {currentColor}");

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = currentColor;
            Console.Write(currentChar);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && y > 0)
                y--;
            else if (key == ConsoleKey.DownArrow && y < Console.WindowHeight - 1)
                y++;
            else if (key == ConsoleKey.LeftArrow && x > 0)
                x--;
            else if (key == ConsoleKey.RightArrow && x < Console.WindowWidth - 1)
                x++;
            else if (key == ConsoleKey.Spacebar)
                drawings.Add((x, y, currentChar, currentColor));
            else if (key >= ConsoleKey.D0 && key <= ConsoleKey.D9)
                currentColor = (ConsoleColor)((key - ConsoleKey.D0) % 16);
            else if (key == ConsoleKey.NumPad0)
                currentChar = '█';
            else if (key == ConsoleKey.NumPad1)
                currentChar = '▓';
            else if (key == ConsoleKey.NumPad2)
                currentChar = '▒';
            else if (key == ConsoleKey.NumPad3)
                currentChar = '░';
        }
    }
}
