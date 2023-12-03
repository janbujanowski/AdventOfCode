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
            Assert.AreEqual(55429, dayObject.StarTwo());
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

        [TestMethod]
        public void Day2StarOne()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(2439, dayObject.StarOne());
        }
        [TestMethod]
        public void Day2StarTwo()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(63711, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day3StarOne()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3, "Day3_sometestcase.txt"));
            Assert.AreEqual(925, dayObject.StarOne());
            dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3, "Day3_aoctestcase.txt"));
            Assert.AreEqual(4361, dayObject.StarOne());
            dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3,"Day3_maciej.txt"));
            Assert.AreEqual(522726, dayObject.StarOne());
            dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(507214, dayObject.StarOne());
        }
        [TestMethod]
        public void Day3StarTwo()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3, "Day3_maciej.txt"));
            Assert.AreEqual(81721933, dayObject.StarTwo());
        }

    }
}
