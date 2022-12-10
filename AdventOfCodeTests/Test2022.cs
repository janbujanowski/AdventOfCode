using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace AdventOfCode2022
{
    [TestClass]
    public class Test2022
    {
        private void NotYetImplementedDay()
        {
            throw new NotImplementedException("Day still needs work");
        }
        private string GetInput(int day)
        {
            return AdventOfCode.Shared.Inputs.GetDayInput(2022, day);
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

        [TestMethod]
        public void Day2StarOne()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(13484, dayObject.StarOne());
        }
        [TestMethod]
        public void Day2StarTwo()
        {
            var dayObject = new Day2();
            dayObject.ParseInput(GetInput(2));
            Assert.AreEqual(13433, dayObject.StarTwo());
        }

        [TestMethod]
        public void Day3StarOne()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(7795, dayObject.StarOne());
        }
        [TestMethod]
        public void Day3StarTwo()
        {
            var dayObject = new Day3();
            dayObject.ParseInput(GetInput(3));
            Assert.AreEqual(2703, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day4StarOne()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(538, dayObject.StarOne());
        }
        [TestMethod]
        public void Day4StarTwo()
        {
            var dayObject = new Day4();
            dayObject.ParseInput(GetInput(4));
            Assert.AreEqual(792, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day5StarOne()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual("BZLVHBWQF", dayObject.StarOne());
        }
        [TestMethod]
        public void Day5StarTwo()
        {
            var dayObject = new Day5();
            dayObject.ParseInput(GetInput(5));
            Assert.AreEqual("TDGJQTZSL", dayObject.StarTwo());
        }
        [TestMethod]
        public void Day6StarOne()
        {
            var dayObject = new Day6();
            dayObject.ParseInput("bvwbjplbgvbhsrlpgdmjqwftvncz");
            Assert.AreEqual(5, dayObject.StarOne());
            dayObject.ParseInput("nppdvjthqldpwncqszvftbrmjlhg");
            Assert.AreEqual(6, dayObject.StarOne());
            dayObject.ParseInput("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            Assert.AreEqual(10, dayObject.StarOne());
            dayObject.ParseInput("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            Assert.AreEqual(11, dayObject.StarOne());
            dayObject.ParseInput(GetInput(6));
            Assert.AreEqual(1531, dayObject.StarOne());
        }
        [TestMethod]
        public void Day6StarTwo()
        {
            var dayObject = new Day6();
            dayObject.ParseInput("bvwbjplbgvbhsrlpgdmjqwftvncz");
            Assert.AreEqual(23, dayObject.StarTwo());
            dayObject.ParseInput("nppdvjthqldpwncqszvftbrmjlhg");
            Assert.AreEqual(23, dayObject.StarTwo());
            dayObject.ParseInput("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
            Assert.AreEqual(29, dayObject.StarTwo());
            dayObject.ParseInput("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
            Assert.AreEqual(26, dayObject.StarTwo());
            dayObject.ParseInput(GetInput(6));
            Assert.AreEqual(2518, dayObject.StarTwo());
        }

        [TestMethod]
        public void Day7StarOne()
        {
            var dayObject = new Day7();
            dayObject.ParseInput(GetInput(7));
            Assert.AreEqual(1325919L, dayObject.StarOne());
        }
        [TestMethod]
        public void Day7StarTwo()
        {
            var dayObject = new Day7();
            dayObject.ParseInput(GetInput(7));
            Assert.AreEqual(2050735L, dayObject.StarTwo());
        }

        [TestMethod]
        public void Day9StarOne()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(5779, dayObject.StarOne());
        }

        [TestMethod]
        public void Day9StarTwo()
        {
            var dayObject = new Day9();
            dayObject.ParseInput(GetInput(9));
            Assert.AreEqual(2331, dayObject.StarTwo());
        }
        [TestMethod]
        public void Day10StarOne()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            Assert.AreEqual(13920, dayObject.StarOne());
        }

        [TestMethod]
        public void Day10StarTwo()
        {
            var dayObject = new Day10();
            dayObject.ParseInput(GetInput(10));
            Assert.AreEqual("EGLHBLFJ", dayObject.StarTwo());
        }
    }
}
