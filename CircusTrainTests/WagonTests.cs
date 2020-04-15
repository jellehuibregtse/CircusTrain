using System.Collections.Generic;
using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrainTests
{
    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void WagonTooManyAnimals()
        {
            var wagon = new Wagon();
            var animal = new Animal(false, AnimalSize.Small);
            
            for (var i = 0; i < 10; i++)
            {
                wagon.AddAnimal(new Animal(false, AnimalSize.Small));
            }

            Assert.IsFalse(wagon.AddAnimal(animal));
            Assert.IsFalse(wagon.AnimalFits(animal));
        }
    }
}