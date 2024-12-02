using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdventOfCode2024
{
    [TestClass]
    public class Test2024
    {
        private void NotYetImplementedDay()
        {
            throw new NotImplementedException("Day still needs work");
        }
        private string GetInput(int day)
        {
            return AdventOfCode.Shared.Inputs.GetDayInput(2024, day);
        }

        [TestMethod]
        public void Day1StarOne()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(1580061, dayObject.StarOne());
        }

        [TestMethod]
        public void Day1StarTwo()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            dayObject.StarOne();
            Assert.AreEqual(23046913, dayObject.StarTwo());
        }

        [TestMethod]
        public void Day2StarOne()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(202, dayObject.StarOne());
        }

        [TestMethod]
        public void Day2StarTwo()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(271, dayObject.StarTwo());
        }
    }
}
