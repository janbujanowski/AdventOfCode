using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace AdventOfCode2023
{
    [TestClass]
    public class Test2023
    {
        private void NotYetImplementedDay()
        {
            throw new NotImplementedException("Day still needs work");
        }
        private string GetInput(int day)
        {
            return AdventOfCode.Shared.Inputs.GetDayInput(2023, day);
        }
        [TestMethod]
        public void Day1StarOne()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(54605, dayObject.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            var dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            dayObject.StarOne();
            Assert.AreEqual(55489, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day1StarTwoLineTestCases()
        {
            var dayObject = new Day1();
           
            Assert.AreEqual(21, dayObject.GetCalibrationNumber("two1two1"));
            Assert.AreEqual(12, dayObject.GetCalibrationNumber("1two1two"));
            Assert.AreEqual(39, dayObject.GetCalibrationNumber("v3one9"));
            Assert.AreEqual(41, dayObject.GetCalibrationNumber("46one"));
        }
        [TestMethod]
        public void Day1StarTwoLineTestCases2()
        {
            var dayObject = new Day1();

            Assert.AreEqual(83, dayObject.GetCalibrationNumber("eighthree"));
            Assert.AreEqual(79, dayObject.GetCalibrationNumber("sevenine"));
            Assert.AreEqual(71, dayObject.GetCalibrationNumber("7twoonev"));
            
        }


    }
}
