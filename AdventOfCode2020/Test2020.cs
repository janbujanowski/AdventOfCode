﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    [TestClass]
    public class Test2020
    {
        string pathToInputsFolder = @"C:\REPOS\AdventOfCode\AdventOfCode2020\inputs_2020";
        private string GetInput(int day)
        {
            return File.ReadAllText(Path.Combine(pathToInputsFolder, $"Day{day}.txt"));
        }
        //[TestMethod]
        //public void Day1StarOne()
        //{
        //    var dayObject = new Day1();
        //    dayObject.ParseInput(GetInput(1));
        //    Assert.AreEqual(1711, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day1StarTwo()
        //{
        //    var dayObject = new Day1();
        //    dayObject.ParseInput(GetInput(1));
        //    Assert.AreEqual(1743, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day2StarOne()
        //{
        //    var dayObject = new Day2();
        //    dayObject.ParseInput(GetInput(2));
        //    Assert.AreEqual(1507611, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day2StarTwo()
        //{
        //    var dayObject = new Day2();
        //    dayObject.ParseInput(GetInput(2));
        //    Assert.AreEqual(1880593125, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day3StarOne()
        //{
        //    var dayObject = new Day3();
        //    dayObject.ParseInput(GetInput(3));
        //    Assert.AreEqual(3959450, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day3StarTwo()
        //{
        //    var dayObject = new Day3();
        //    dayObject.ParseInput(GetInput(3));
        //    Assert.AreEqual(7440311, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day4StarOne()
        //{
        //    var dayObject = new Day4();
        //    dayObject.ParseInput(GetInput(4));
        //    Assert.AreEqual(33462, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day4StarTwo()
        //{
        //    var dayObject = new Day4();
        //    dayObject.ParseInput(GetInput(4));
        //    Assert.AreEqual(30070, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day5StarOne()
        //{
        //    var dayObject = new Day5();
        //    dayObject.ParseInput(GetInput(5));
        //    Assert.AreEqual(5576, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day5StarTwo()
        //{
        //    var dayObject = new Day5();
        //    dayObject.ParseInput(GetInput(5));
        //    Assert.AreEqual(18144, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day6StarOne()
        //{
        //    var dayObject = new Day6();
        //    dayObject.ParseInput(GetInput(6));
        //    Assert.AreEqual(386536UL, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day6StarTwo()
        //{
        //    var dayObject = new Day6();
        //    dayObject.ParseInput(GetInput(6));
        //    Assert.AreEqual(1732821262171UL, dayObject.StarTwo());
        //}

        //[TestMethod]
        //public void Day7StarOne()
        //{
        //    var dayObject = new Day7();
        //    dayObject.ParseInput(GetInput(7));
        //    Assert.AreEqual(356958U, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day7StarTwo()
        //{
        //    var dayObject = new Day7();
        //    dayObject.ParseInput(GetInput(7));
        //    Assert.AreEqual(105461913U, dayObject.StarTwo());
        //}
        //[TestMethod]
        //public void Day8StarOne()
        //{
        //    var dayObject = new Day8();
        //    dayObject.ParseInput(GetInput(8));
        //    Assert.AreEqual(519, dayObject.StarOne());
        //}
        //[TestMethod]
        //public void Day8StarTwo()
        //{
        //    var dayObject = new Day8();
        //    dayObject.ParseInput(GetInput(8));
        //    Assert.AreEqual(1027483, dayObject.StarTwo());
        //}
        [TestMethod]
        public async Task Day9StarOne()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(1124361034L, dayObject.StarOne());
        }
        [TestMethod]
        public async Task Day9StarTwo()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(129444555L, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day10StarOne()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            Assert.AreEqual(2059, dayObject.StarOne());
        }
        [TestMethod]
        public void Day10StarTwo()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            Assert.AreEqual(2995077699L, dayObject.StarTwo());
        }
    }
}
