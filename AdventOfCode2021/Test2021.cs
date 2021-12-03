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
            return File.ReadAllText(Path.Combine(pathToInputsFolder,$"Day{day}.txt"));
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
    }
}
