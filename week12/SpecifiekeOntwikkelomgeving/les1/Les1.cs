using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace les1
{
    class Program
    {
        static public List<string> lines;

        static void Main(string[] args)
        {
            lines = new List<string> {};
            try
            {
                lines = File.ReadAllLines("test.txt").ToList();
            }
                catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string input = "";

            while (input != "q") {
                Console.Clear();
                Console.WriteLine("TODOLIST");
                Console.WriteLine("--------");
                PrintLines();
                
                input = AskInput();

                if (input == "a") {
                    AddItem();
                    File.WriteAllLines("test.txt", lines);
                } else if (input == "r") {
                    RemoveItem();
                    File.WriteAllLines("test.txt", lines);
                } else if (input == "c") {
                    ChangeItem();
                    File.WriteAllLines("test.txt", lines);
                } else if (input == "h") {
                    HandleItem();
                    File.WriteAllLines("test.txt", lines);
                }
            }
        }

        static void PrintLines() {
            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(";");
                if (line[1] == "klaar") {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{i+1}. {line[0]}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        static string AskInput() {
            Console.WriteLine("\na. Add Item");
            Console.WriteLine("r. Remove item");
            Console.WriteLine("c. Change item");
            Console.WriteLine("h. handle item");
            Console.WriteLine("q. Quit");

            Console.Write("\nWat wil je doen (a, r, c, h or q)? ");
            return Console.ReadLine();
        }

        static void AddItem() {
            Console.Write("Item dat je wilt toevoegen: ");
            string newItem = Console.ReadLine();
            
            lines.Add(newItem);
        }
        
        static void RemoveItem() {
            Console.Write("Welk item wil je verwijderen? ");
            int nItem = ReadInt();

            lines.RemoveAt(nItem-1);
        }

        static void ChangeItem() {
            Console.Write("Welk item wil je veranderen? ");
            int nItem = ReadInt();

            Console.WriteLine($"Vorige waarde: {lines[nItem-1]}");
            Console.Write("Nieuwe waarde: ");
            string newItem = Console.ReadLine();

            lines[nItem-1] = newItem;
        }

        static void HandleItem() {
            Console.Write("Kies een item om af te handelen: ");
            int nItem = ReadInt();

            string[] line = lines[nItem-1].Split(";");
            lines[nItem-1] = line[0] + ";" + (line[1] == "klaar" ? "niet klaar" : "klaar");
        }

        static int ReadInt() {
            string nItem = Console.ReadLine();
            int number;
            while(!int.TryParse(nItem, out number)) {
                Console.Write("Geef een geldig getal: ");
                nItem = Console.ReadLine();
            }

            return number;
        }
    }
}
