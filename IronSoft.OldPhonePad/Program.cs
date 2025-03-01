using System;
using System.Collections.Generic;
using System.Diagnostics;
using IronSoft.OldPhonePad;


// Pause 1 second in order to type two characters on the same key.

namespace IronSoft.OldPhonePad
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
            Console.WriteLine("Invalid inputs will be skipped.");
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
                List<KeyValuePair<string, int>> input = new List<KeyValuePair<string, int>>();
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
                    if (IsValidKey(keyPressed))
                    {
                        if (keyPressed == "#")
                        {
                            Console.WriteLine("\nOutput: " + OldPhonePad.GenerateOutput(input));
                            input.Clear();
                        }
                        else
                        {
                            input.Add(new KeyValuePair<string, int>(keyPressed, (int)stopwatch.Elapsed.TotalSeconds));
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

        private static bool IsValidKey(string key)
        {
            // read the list of invalid keys from the OldPhonePad class
            return OldPhonePad.IsValidKey(key);
        }
    }
}
