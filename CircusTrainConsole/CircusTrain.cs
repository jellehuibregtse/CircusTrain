using System;
using System.Collections.Generic;
using System.Linq;
using CircusTrain;

namespace CircusTrainConsole
{
    public class CircusTrain
    {
        private readonly List<Animal> _animals = new List<Animal>();
        private WagonDistributor _wagonDistributor;
        
        /// <summary>
        /// The start of this program.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("--- CIRCUS TRAIN ---");
            AskForAnimal();
            Console.WriteLine("All animals have been added, now starting distribution!");
            _wagonDistributor = new WagonDistributor(_animals);
            _wagonDistributor.Distribute();
            DisplayDistribution(_wagonDistributor);
        }
        
        /// <summary>
        /// Asks the user if one needs another animal to be added.
        /// </summary>
        private void AskForAnimal()
        {
            while (AskYesOrNo("Would you like to add an animal?"))
            {
                var carnivore = AskYesOrNo("Is this animal a carnivore?");
                var size = AskForSize();
                _animals.Add(new Animal(carnivore, size));
            }
        }
        
        /// <summary>
        /// Asks the user for the size of said animal.
        /// </summary>
        /// <returns>The size as an AnimalSize object.</returns>
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
        
        /// <summary>
        /// Asks a yes or no question.
        /// </summary>
        /// <param name="message">The question.</param>
        /// <returns>The answer as a boolean.</returns>
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
        
        /// <summary>
        /// Prints the result after distributing.
        /// </summary>
        /// <param name="distributor">The distributor that needs to be displayed.</param>
        private void DisplayDistribution(WagonDistributor distributor)
        {
            Console.WriteLine("\n--- Wagon Distribution ---\n");
            Console.WriteLine("Total Amount of wagons: {0}", distributor.Wagons.Count);
            Console.WriteLine("----------------------------------------------------\n");
            for (var i = 0; i < distributor.Wagons.Count; i++)
            {
                var wagon = distributor.Wagons[i];
                var animals = wagon.Animals.ToList();
                Console.WriteLine("Wagon {0}:\n\n{1} animals\n", i + 1, animals.Count);
                for (var j = 0; j < animals.Count; j++)
                {
                    var animal = animals[j];
                    Console.WriteLine("Animal {0} - {1}", j + 1,
                        animal);
                }

                Console.WriteLine("---------------------------------------------------- +");
                Console.WriteLine("Total points: {0}\n\n", wagon.Points);
            }
        }
    }
}