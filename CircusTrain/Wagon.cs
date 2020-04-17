using System.Collections.Generic;
using System.Linq;

namespace CircusTrain
{
    public class Wagon
    {
        // A list of all animals in the wagon.
        private readonly List<Animal> _animals = new List<Animal>();
        public IEnumerable<Animal> Animals => _animals;

        // An integer returning the sum of all points from each animal in the wagon.
        public int Points
        {
            get { return _animals.Sum(animal => (int) animal.AnimalSize); }
        }
        
        /// <summary>
        /// Adds an animal to the wagon if the animal fits and if the animal cannot be eaten by other animals.
        /// </summary>
        /// <param name="animal">The animal to be added to the wagon.</param>
        /// <returns>If the animal was added or not.</returns>
        public bool AddAnimal(Animal animal)
        {
            if (!AnimalFits(animal))
                return false;

            foreach (var animalInWagon in _animals)
            {
                if (animalInWagon.Carnivore && animalInWagon.AnimalSize >= animal.AnimalSize)
                    return false;

                if (animal.Carnivore && animal.AnimalSize >= animalInWagon.AnimalSize)
                    return false;
            }

            _animals.Add(animal);
            return true;
        }
        
        /// <summary>
        /// Checks if the animal fits in the wagon.
        /// </summary>
        /// <param name="animal">The animal to be added to the wagon.</param>
        /// <returns>If the animal fits or not.</returns>
        private bool AnimalFits(Animal animal)
        {
            return Points + (int) animal.AnimalSize <= 10;
        }
    }
}