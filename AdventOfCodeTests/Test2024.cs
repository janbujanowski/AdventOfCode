using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

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

            dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(54605, dayObject.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            var dayObject = new Day1();
            dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            dayObject.StarOne();
            Assert.AreEqual(55429, dayObject.StarTwo());
        }
    }
}
