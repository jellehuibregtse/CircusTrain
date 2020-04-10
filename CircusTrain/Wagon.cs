using System.Collections.Generic;
using System.Linq;

namespace CircusTrain
{
    public class Wagon
    {
        public readonly List<Animal> Animals = new List<Animal>();

        public int Points
        {
            get { return Animals.Sum(animal => (int) animal.AnimalSize); }
        }

        public bool AddAnimal(Animal animal)
        {
            if (!AnimalFits(animal))
                return false;

            foreach (var animalInWagon in Animals)
            {
                if (animalInWagon.Carnivore && animalInWagon.AnimalSize >= animal.AnimalSize)
                    return false;

                if (animal.Carnivore && animal.AnimalSize >= animalInWagon.AnimalSize)
                    return false;
            }

            Animals.Add(animal);
            return true;
        }

        public bool AnimalFits(Animal animal)
        {
            return Points + (int) animal.AnimalSize <= 10;
        }
    }
}