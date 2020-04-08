using System.Collections.Generic;
using System.Linq;

namespace CircusTrain
{
    public class WagonDistributor
    {
        public readonly List<Wagon> Wagons = new List<Wagon>();

        // List of animals that need to be distributed over n amount of wagons.
        private readonly List<Animal> _animals;

        public WagonDistributor(List<Animal> animals)
        {
            _animals = animals;
        }
        
        public void Distribute()
        {
            foreach (var animal in _animals)
            {
                if (Wagons.Any(wagon => wagon.AddAnimal(animal))) continue;

                AddWagonWithAnimal(animal);
            }
        }

        public void AddWagonWithAnimal(Animal animal)
        {
            var newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            Wagons.Add(newWagon);
        }
    }
}