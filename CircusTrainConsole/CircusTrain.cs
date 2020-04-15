using System;
using System.Collections.Generic;
using CircusTrain;

namespace CircusTrainConsole
{
    public class CircusTrain
    {
        private readonly List<Animal> _animals = new List<Animal>();
        private WagonDistributor _wagonDistributor;

        public void Run()
        {
            Console.WriteLine("--- CIRCUS TRAIN ---");
            AskForAnimal();
            Console.WriteLine("All animals have been added, now starting distribution!");
            _wagonDistributor = new WagonDistributor(_animals);
            _wagonDistributor.Distribute();
            Print(_wagonDistributor);
        }

        private void AskForAnimal()
        {
            while (AskYesOrNo("Would you like to add an animal?"))
            {
                var carnivore = AskYesOrNo("Is this animal a carnivore?");
                var size = AskForSize();
                _animals.Add(new Animal(carnivore, size));
            }
        }

        private AnimalSize AskForSize()
        {
            Console.WriteLine("What size is this animal? (small/medium/large)");

            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !(input.ToLower().Equals("small") ||
                                                    input.ToLower().Equals("medium") ||
                                                    input.ToLower().Equals("large")))
            {
                Console.WriteLine("Please enter small/medium/large");
                input = Console.ReadLine();
            }

            return input.Equals("small") ? AnimalSize.Small :
                input.Equals("medium") ? AnimalSize.Medium :
                input.Equals("large") ? AnimalSize.Large : AnimalSize.Small;
        }

        private bool AskYesOrNo(string message)
        {
            Console.WriteLine("{0} (yes/no)", message);

            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || !(input.ToLower().Equals("yes") || input.ToLower().Equals("no")))
            {
                Console.WriteLine("Please enter yes/no");
                input = Console.ReadLine();
            }

            return input.ToLower().Equals("yes");
        }

        private void Print(WagonDistributor distributor)
        {
            Console.WriteLine("\n--- Wagon Distribution ---\n");
            Console.WriteLine("Total Amount of wagons: {0}", distributor.Wagons.Count);
            Console.WriteLine("----------------------------------------------------\n");
            for (var i = 0; i < distributor.Wagons.Count; i++)
            {
                var wagon = distributor.Wagons[i];
                Console.WriteLine("Wagon {0}:\n\n{1} animals\n", i + 1, wagon.Animals.Count);
                for (var j = 0; j < wagon.Animals.Count; j++)
                {
                    var animal = wagon.Animals[j];
                    Console.WriteLine("Animal {0} - Size: {1}, Points: {2}, Carnivorous: {3}", j + 1,
                        animal.AnimalSize.ToString(),
                        (int) animal.AnimalSize, animal.Carnivore);
                }

                Console.WriteLine("---------------------------------------------------- +");
                Console.WriteLine("Total points: {0}\n\n", wagon.Points);
            }
        }
    }
}