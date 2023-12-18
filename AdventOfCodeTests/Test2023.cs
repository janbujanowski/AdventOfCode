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

            Assert.AreEqual(83, dayObject.GetCalibrationNumber("eighthree"));
            Assert.AreEqual(79, dayObject.GetCalibrationNumber("sevenine"));
            Assert.AreEqual(71, dayObject.GetCalibrationNumber("7twoonev"));
            dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            Assert.AreEqual(54605, dayObject.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
           

            var dayObject = new Day1();

            Assert.AreEqual(21, dayObject.GetCalibrationNumber("two1two1"));
            Assert.AreEqual(12, dayObject.GetCalibrationNumber("1two1two"));
            Assert.AreEqual(39, dayObject.GetCalibrationNumber("v3one9"));
            Assert.AreEqual(41, dayObject.GetCalibrationNumber("46one"));
            dayObject = new Day1();
            dayObject.ParseInput(GetInput(1));
            dayObject.StarOne();
            Assert.AreEqual(55429, dayObject.StarTwo());
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

            dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(72553319, dayObject.StarTwo());

            dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3, "Day3_sometestcase.txt"));
            Assert.AreEqual(6756, dayObject.StarTwo());

            dayObject = new Day3();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 3, "Day3_aoctestcase.txt"));
            Assert.AreEqual(467835, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day4StarOne()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(25174, dayObject.StarOne());
        }
        [TestMethod]
        public void Day4StarTwo()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(6420979, dayObject.StarTwo());
        }

        [TestMethod]
        public void Day5StarOne()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual(214922730UL, dayObject.StarOne());
        }
        [TestMethod]
        public void Day5StarTwo()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual(148041808UL, dayObject.StarTwo());
        }
        
        [TestMethod]
        public void Day6StarOne()
        {
            var dayObject = new Day6();
            dayObject.ParseInput(GetInput(6));
            Assert.AreEqual(608902, dayObject.StarOne());
        }
        [TestMethod]
        public void Day6StarTwo()
        {
            var dayObject = new Day6();
            dayObject.ParseInput(GetInput(6));
            Assert.AreEqual(46173809UL, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day7StarOne()
        {
            var dayObject = new Day7();
            dayObject.ParseInput(GetInput(7));
            Assert.AreEqual(249204891UL, dayObject.StarOne());
            dayObject = new Day7();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 7, "Day7_edgecases.txt"));
            Assert.AreEqual(3542UL, dayObject.StarOne());
        }
        [TestMethod]
        public void Day7StarTwo()
        {
            var dayObject = new Day7();
            dayObject.ParseInput(GetInput(7));
            Assert.AreEqual(249666369UL, dayObject.StarTwo());
            new Day7();
            dayObject.ParseInput(AdventOfCode.Shared.Inputs.GetSpecificFileNameFromInputs(2023, 7, "Day7_edgecases.txt"));
            Assert.AreEqual(3667UL, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day8StarOne()
        {
            var dayObject = new Day8();
            dayObject.ParseInput(GetInput(8));
            Assert.AreEqual(18113, dayObject.StarOne());
        }
        [TestMethod]
        public void Day8StarTwo()
        {
            var dayObject = new Day8();
            dayObject.ParseInput(GetInput(8));
            Assert.AreEqual(12315788159977UL, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day9StarOne()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(1974913025L, dayObject.StarOne());
        }
        [TestMethod]
        public void Day9StarTwo()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(884L, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day10StarOne()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            Assert.AreEqual(6823d, dayObject.StarOne());
        }
        [TestMethod]
        public void Day10StarTwo()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            dayObject.StarOne();
            Assert.AreEqual(415, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day11StarOne()
        {
            var dayObject = new Day11();
            dayObject.ParseInput(GetInput(11));
            Assert.AreEqual(9605127L, dayObject.StarOne());
        }
        [TestMethod]
        public void Day11StarTwo()
        {
            var dayObject = new Day11();
            dayObject.ParseInput(GetInput(11));
            Assert.AreEqual(458191688761L, dayObject.StarTwo());
        }


        [TestMethod]
        public void Day16StarOne()
        {
            var dayObject = new Day16();
            dayObject.ParseInput(GetInput(16));
            Assert.AreEqual(7185, dayObject.StarOne());
        }
        [TestMethod]
        public void Day16StarTwo()
        {
            var dayObject = new Day16();
            dayObject.ParseInput(GetInput(16));
            Assert.AreEqual(7616, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day18StarOne()
        {
            var dayObject = new Day18();
            dayObject.ParseInput(GetInput(18));
            Assert.AreEqual(62365, dayObject.StarOne());
        }
        //[TestMethod]
        //public void Day18StarTwo()
        //{
        //    var dayObject = new Day18();
        //    dayObject.ParseInput(GetInput(18));
        //    Assert.AreEqual(7616, dayObject.StarTwo());
        //}
    }
}
