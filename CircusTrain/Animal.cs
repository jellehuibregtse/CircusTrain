namespace CircusTrain
{
    public class Animal
    {
        // If the animal is carnivore or not.
        public bool Carnivore { get; }
        // The size of the animal as an enumerator.
        public AnimalSize AnimalSize { get; }

        public Animal(bool carnivore, AnimalSize animalSize)
        {
            Carnivore = carnivore;
            AnimalSize = animalSize;
        }
        
        /// <summary>
        /// Gets all the animals information as a string.
        /// </summary>
        /// <returns>A string with all the animals information, ready for displaying.</returns>
        public override string ToString()
        {
            return "Carnivorous: " + Carnivore + ", Size: " + AnimalSize + ", Points: " + (int) AnimalSize;
        }
    }
}