using System;
using System.Collections.Generic;
using System.Linq;
using CircusTrain;

namespace CircusTrainConsole
{
    class Program
    {
        void Run()
        {
            var smallAnimalsCarnivorous = GetTestAnimals(1, true, AnimalSize.Small); // 1
            var mediumAnimals = GetTestAnimals(5, false, AnimalSize.Medium); // 0 ^
            var mediumAnimalsCarnivorous = GetTestAnimals(5, true, AnimalSize.Medium); // 5
            var largeAnimals = GetTestAnimals(4, false, AnimalSize.Big); // 0
            var testAnimals = new List<Animal>(smallAnimalsCarnivorous.Concat(mediumAnimals)
                .Concat(mediumAnimalsCarnivorous).Concat(largeAnimals));
            var distributor = new WagonDistributor(testAnimals);
            
            distributor.Distribute();
            
            Console.WriteLine("Total Amount of wagons: {0}", distributor.Wagons.Count);
            Console.WriteLine("----------------------------------------------------\n");
            for (var i = 0; i < distributor.Wagons.Count; i++)
            {
                var wagon = distributor.Wagons[i];
                Console.WriteLine("Wagon {0}:\n\n{1} animals\n", i + 1, wagon.Animals.Count);
                for (var j = 0; j < wagon.Animals.Count; j++)
                {
                    var animal = wagon.Animals[j];
                    Console.WriteLine("Animal {0} - Size: {1}, Points: {2}, Carnivorous: {3}", j + 1, animal.AnimalSize.ToString(),
                        (int) animal.AnimalSize, animal.Carnivore);
                }

                Console.WriteLine("---------------------------------------------------- +");
                Console.WriteLine("Total points: {0}\n\n", wagon.Points);
            }
        }
        private List<Animal> GetTestAnimals(int amount, bool isCarnivorous, AnimalSize size)
        {
            var testAnimals = new List<Animal>();

            for (var i = 0; i < amount; i++)
            {
                testAnimals.Add(new Animal(isCarnivorous, size));
            }

            return testAnimals;
        }
        
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}