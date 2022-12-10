using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    [TestClass]
    public class Test2020
    {
        private string GetInput(int day)
        {
            return AdventOfCode.Shared.Inputs.GetDayInput(2020, day);
        }

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
