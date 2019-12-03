using System;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        private static bool _isFull = false;
        public static void CheckForFullField(int index, Farm farm, IGrazing animal)
        {
            int choice = index + 1;

            if (farm.GrazingFields[index].AnimalCount == farm.GrazingFields[index].Capacity)
            {
                _isFull = true;
                Console.WriteLine("This facility is full.");
                Thread.Sleep(750);
                Console.WriteLine("Please choose another facility.");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1500);
                CollectInput(farm, animal);
            }
            else
            {
                Console.Write($"Adding animal to option {choice}");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine("Added animal.");
                farm.GrazingFields[index].AddResource(animal);
            }
        }
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            while (!_isFull)
            {
                Utils.Clear();
                break;
            }

            Console.WriteLine("CHOOSING FACILITY...");
            Console.WriteLine();
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field ({farm.GrazingFields[i].AnimalCount} animals)");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            choice--;

            CheckForFullField(choice, farm, animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}