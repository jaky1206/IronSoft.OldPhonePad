using System;
using System.Diagnostics;

namespace IronSoft.OldPhonePad.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Old feature phone keypad simulator.");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Allowed inputs: 0-9, *, #");
            Console.WriteLine("Invalid inputs will be ignored.");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Key Mappings:");
            Console.WriteLine("1 --> & ' ( ) ");
            Console.WriteLine("2 --> A B C ");
            Console.WriteLine("3 --> D E F ");
            Console.WriteLine("4 --> G H I ");
            Console.WriteLine("5 --> J K L ");
            Console.WriteLine("6 --> M N O ");
            Console.WriteLine("7 --> P Q R S ");
            Console.WriteLine("8 --> T U V ");
            Console.WriteLine("9 --> W X Y Z ");
            Console.WriteLine("* --> Backspace ");
            Console.WriteLine("0 --> Space ");
            Console.WriteLine("# --> Send ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Press enter to exit.");
            Console.WriteLine("---------------------------------------------");

            while (true)
            {
                List<KeyValuePair<char, int>> input = new List<KeyValuePair<char, int>>();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    string keyPressed = key.KeyChar.ToString();
                    if (OldPhonePad.IsValidKey(keyPressed))
                    {
                        if (keyPressed == "#")
                        {
                            Console.WriteLine("\nOutput: " + OldPhonePad.GenerateOutput(input));
                            input.Clear();
                        }
                        else
                        {
                            input.Add(
                                new KeyValuePair<char, int>(
                                    keyPressed[0],
                                    (int)stopwatch.Elapsed.TotalSeconds
                                )
                            );
                            stopwatch.Restart();
                        }
                    }
                    else
                    {
                        Console.Beep();
                        continue; // Skip adding the invalid key to the input
                    }
                }
            }
        }
    }
}
