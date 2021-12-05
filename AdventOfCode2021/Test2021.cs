using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2021
{
    [TestClass]
    public class Test2021
    {
        string pathToInputsFolder = @"C:\REPOS\AdventOfCode\AdventOfCode2021\inputs_2021";
        private string GetInput(int day)
        {
            return File.ReadAllText(Path.Combine(pathToInputsFolder, $"Day{day}.txt"));
        }
        [TestMethod]
        public void Day1StarOne()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(1711, dayObject.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(1743, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day2StarOne()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(1507611, dayObject.StarOne());
        }
        [TestMethod]
        public void Day2StarTwo()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(1880593125, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day3StarOne()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(3959450, dayObject.StarOne());
        }
        [TestMethod]
        public void Day3StarTwo()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(7440311, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day4StarOne()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(33462, dayObject.StarOne());
        }
        [TestMethod]
        public void Day4StarTwo()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(30070, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day5StarOne()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual(5576, dayObject.StarOne());
        }
        [TestMethod]
        public void Day5StarTwo()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual(18144, dayObject.StarTwo());
        }

    }
}
