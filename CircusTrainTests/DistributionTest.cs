using System.Collections.Generic;
using System.Linq;
using CircusTrain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrainTests
{
    [TestClass]
    public class DistributionTest
    {
        private static List<Animal> GetTestAnimals(int amount, bool isCarnivorous, AnimalSize size)
        {
            var testAnimals = new List<Animal>();

            for (var i = 0; i < amount; i++)
            {
                testAnimals.Add(new Animal(isCarnivorous, size));
            }

            return testAnimals;
        }

        [TestMethod]
        public void DistributionTestAllSmallAnimals()
        {
            var testAnimals = GetTestAnimals(10, false, AnimalSize.Small);
            var distributor = new WagonDistributor(testAnimals);

            distributor.Distribute();

            Assert.IsTrue(distributor.Wagons.Count == 1);
        }

        [TestMethod]
        public void DistributionTestAllMediumAnimals()
        {
            var testAnimals = GetTestAnimals(10, false, AnimalSize.Medium);
            var distributor = new WagonDistributor(testAnimals);

            distributor.Distribute();
            Assert.IsTrue(distributor.Wagons.Count == 4);
        }

        [TestMethod]
        public void DistributionTestAllBigAnimals()
        {
            var testAnimals = GetTestAnimals(10, false, AnimalSize.Big);
            var distributor = new WagonDistributor(testAnimals);

            distributor.Distribute();
            Assert.IsTrue(distributor.Wagons.Count == 5);
        }

        [TestMethod]
        public void DistributionTestAllSmallAndCarnivorous()
        {
            var testAnimals = GetTestAnimals(10, true, AnimalSize.Small);
            var distributor = new WagonDistributor(testAnimals);
            
            distributor.Distribute();
            Assert.IsTrue(distributor.Wagons.Count == 10);
        }
        
        [TestMethod]
        public void DistributionTestSmall()
        {
            var smallAnimalsCarnivorous = GetTestAnimals(5, true, AnimalSize.Small); // 5
            var smallAnimals = GetTestAnimals(5, false, AnimalSize.Small); // 1
            var testAnimals = new List<Animal>(smallAnimalsCarnivorous.Concat(smallAnimals));
            var distributor = new WagonDistributor(testAnimals);
            
            distributor.Distribute();
            
            Assert.IsTrue(distributor.Wagons.Count == 6);
        }

        [TestMethod]
        public void DistributionAllCarnivorous()
        {
            var smallAnimalsCarnivorous = GetTestAnimals(1, true, AnimalSize.Small); // 1
            var mediumAnimals = GetTestAnimals(5, false, AnimalSize.Medium); // 1 extra
            var mediumAnimalsCarnivorous = GetTestAnimals(5, true, AnimalSize.Medium); // 5
            var largeAnimals = GetTestAnimals(4, false, AnimalSize.Big); // 0
            var testAnimals = smallAnimalsCarnivorous.Concat(mediumAnimals)
                .Concat(mediumAnimalsCarnivorous).Concat(largeAnimals).ToList();
            var distributor = new WagonDistributor(testAnimals);
            
            distributor.Distribute();
            
            Assert.IsTrue(distributor.Wagons.Count == 7);
        }
    }
}