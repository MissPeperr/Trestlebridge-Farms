using System;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class CreateFacility
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Grazing field");
            Console.WriteLine("2. Plowed field");

            Console.WriteLine();
            Console.WriteLine("Choose what you want to create:");

            Console.Write("> ");
            string input = Console.ReadLine();

            switch (Int32.Parse(input))
            {
                case 1:
                    Console.WriteLine("Are you sure you want to create a Grazing Field?");
                    Console.WriteLine("[Y] [N]");
                    string confirm = Console.ReadLine();
                    if (confirm.ToUpper() == "Y")
                    {
                        farm.AddGrazingField(new GrazingField());
                        Console.Write("Creating Grazing Field");
                        Utils.Loading();
                        Console.WriteLine("Grazing Field created.");
                        Thread.Sleep(1000);
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;
            }
        }
    }
}