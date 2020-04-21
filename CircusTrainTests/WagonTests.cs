using System.Collections.Generic;
using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrainTests
{
    [TestClass]
    public class WagonTests
    {
        private Wagon _wagon;

        [TestInitialize]
        public void Setup()
        {
            _wagon = new Wagon();
        }
        
        [TestMethod]
        public void WagonTooManyAnimals()
        {
            var animal = new Animal(false, AnimalSize.Small);
            
            for (var i = 0; i < 10; i++)
            {
                _wagon.AddAnimal(new Animal(false, AnimalSize.Small));
            }

            Assert.IsFalse(_wagon.AddAnimal(animal));
        }

        [TestMethod]
        public void WagonAddSmallAnimal()
        {
            var animal = new Animal(false, AnimalSize.Small);

            _wagon.AddAnimal(animal);
            
            Assert.AreEqual(1, _wagon.Points);
        }
        
        [TestMethod]
        public void WagonAddMediumAnimal()
        {
            var animal = new Animal(false, AnimalSize.Medium);

            _wagon.AddAnimal(animal);
            
            Assert.AreEqual(3, _wagon.Points);
        }
        
        [TestMethod]
        public void WagonAddLargeAnimal()
        {
            var animal = new Animal(false, AnimalSize.Large);

            _wagon.AddAnimal(animal);
            
            Assert.AreEqual(5, _wagon.Points);
        }
    }
}