namespace CircusTrain
{
    public class Animal
    {
        public bool Carnivore { get; }
        public AnimalSize AnimalSize { get; }

        public Animal(bool carnivore, AnimalSize animalSize)
        {
            Carnivore = carnivore;
            AnimalSize = animalSize;
        }
    }
}