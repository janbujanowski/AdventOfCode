using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AdventOfCode2021
{
    [TestClass]
    public class Test2022
    {
        private void NotYetImplementedDay()
        {
            throw new NotImplementedException("Day still needs work");
        }
        string pathToInputsFolder = @"C:\REPOS\aoc\AdventOfCode2021\inputs_2021";
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
        
    }
}
