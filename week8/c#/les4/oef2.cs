using System;
using System.Collections.Generic;
using System.Text;

namespace les4
{
    class oef2
    {
        static void Main(string[] args)
        {
            List<string> namen = new List<string> {
                "Bergamont Grandurance RD7",
                "Tokyobike Bisou",
                "Koga E-Worldtraveller",
                "Achielle Sam",
                "Santos Travelmaster 2.8"
            };

            List<double> prijzen = new List<double> {
                3000.0,
                9000.0,
                2500.0,
                1000.0,
                99000.0
            };

            List<int> aantalVersnellingen = new List<int> {
                5,
                4,
                5,
                6,
                5
            };

            string input = "";
            while (input != "q")
            {
                Console.Clear();

                ToonList(namen, prijzen, aantalVersnellingen);
                Console.Write("\nAdd, remove or quit? (type a, c, r or q): ");
                input = Console.ReadLine();
                if (input == "a")
                {
                    AddTo(namen, prijzen, aantalVersnellingen);
                }
                else if (input == "r")
                {
                    RemoveFrom(namen, prijzen, aantalVersnellingen);
                }
                else if (input == "c")
                {
                    ChangeList(namen, prijzen, aantalVersnellingen);
                }
            }
            Console.WriteLine("Tot de volgende keer!");
            Console.ReadLine();

            static void ToonList(List<string> nameList, List<double> priceList, List<int> gearsList)
            {
                for (int index = 0; index < nameList.Count; index++)
                {
                    Console.WriteLine((index+1) + ". " + nameList[index] + ", prijs: " + priceList[index] + ", aantal versnellingen: " + gearsList[index]);
                }
            }

            static void AddTo(List<string> nameList, List<double> priceList, List<int> gearsList)
            {
                Console.Write("\nGeef een nieuw fietsmodel in: ");
                string fietsModel = Console.ReadLine();

                Console.Write("Geef de prijs: ");
                double prijs = double.Parse(Console.ReadLine());

                Console.Write("Geef het aantal versnellingen in: ");
                int versnellingen = int.Parse(Console.ReadLine());

                nameList.Add(fietsModel);
                priceList.Add(prijs);
                gearsList.Add(versnellingen);
            }

            static void RemoveFrom(List<string> nameList, List<double> priceList, List<int> gearsList)
            {
                Console.Write("\nWelk nummer wil je verwijderen (laat leeg om niets te verwijderen): ");
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    int index = int.Parse(input) - 1;
                    nameList.RemoveAt(index);
                    priceList.RemoveAt(index);
                    gearsList.RemoveAt(index);
                }
            }

            static void ChangeList(List<string> nameList, List<double> priceList, List<int> gearsList)
            {
                Console.Write("\nWelk nummer wil je veranderen (laat leeg om niets te veranderen): ");
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    string whichList = "";
                    
                    while (whichList != "q")
                    {
                        whichList = ToonChangeListInput();

                        if (whichList == "1")
                        {
                            int index = int.Parse(input) - 1;
                            string inhoud = changeFromList("Huidige inhoud: " + nameList[index]);

                            if (inhoud.Length > 0)
                            {
                                nameList[index] = inhoud;
                            }
                        }
                        else if (whichList == "2")
                        {
                            int index = int.Parse(input) - 1;
                            string inhoud = changeFromList("Huidige inhoud: " + priceList[index]);

                            if (inhoud.Length > 0)
                            {
                                priceList[index] = double.Parse(inhoud);
                            }
                        }
                        else if (whichList == "3")
                        {
                            int index = int.Parse(input) - 1;
                            string inhoud = changeFromList("Huidige inhoud: " + gearsList[index]);

                            if (inhoud.Length > 0)
                            {
                                gearsList[index] = int.Parse(inhoud);
                            }
                        }
                    }
                }
            }

            static string ToonChangeListInput()
            {
                Console.WriteLine("\n1. Naam");
                Console.WriteLine("2. Prijs");
                Console.WriteLine("3. Versnellingen");
                Console.WriteLine("q. Stop");

                Console.Write("\nWat wil je wijzigen: ");

                return Console.ReadLine();
            }

            static string changeFromList(string question)
            {
                Console.WriteLine(question);
                Console.Write("Geef de nieuwe inhoud: ");

                return Console.ReadLine();
            }
        }
    }
}
