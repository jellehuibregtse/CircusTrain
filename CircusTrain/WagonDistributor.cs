using System.Collections.Generic;
using System.Linq;

namespace CircusTrain
{
    public class WagonDistributor
    {
        // A list of all the wagons created.
        public readonly List<Wagon> Wagons = new List<Wagon>();

        // List of animals that need to be distributed over n amount of wagons.
        private readonly List<Animal> _animals;

        public WagonDistributor(List<Animal> animals)
        {
            _animals = animals;
        }

        /// <summary>
        /// Distributes all animals in the List over the minimum amount of wagons needed.
        /// Wagons which are then stored in the wagons list.
        /// </summary>
        public void Distribute()
        {
            foreach (var animal in _animals)
            {
                if (Wagons.Any(wagon => wagon.AddAnimal(animal))) continue;

                AddWagonWithAnimal(animal);
            }
        }
        
        /// <summary>
        /// Creates a new wagon and adds the animal to the newly created wagon.
        /// </summary>
        /// <param name="animal">The animal that needs a new wagon.</param>
        private void AddWagonWithAnimal(Animal animal)
        {
            var newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            Wagons.Add(newWagon);
        }
    }
}