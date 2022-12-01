using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AdventOfCode2022
{
    [TestClass]
    public class Test2022
    {
        private void NotYetImplementedDay()
        {
            throw new NotImplementedException("Day still needs work");
        }
        string pathToInputsFolder = @"C:\REPOS\aoc\AdventOfCode2022\inputs_2022";
        private string GetInput(int day)
        {
            return File.ReadAllText(Path.Combine(pathToInputsFolder, $"Day{day}.txt"));
        }
        [TestMethod]
        public void Day1StarOne()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(70296, dayObject.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            dayObject.StarOne();
            Assert.AreEqual(205381, dayObject.StarTwo());
        }
        
    }
}
