using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class Executor2017
    {
        [TestMethod]
        public void Day1StarOne()
        {
            //The night before Christmas, one of Santa's Elves calls you in a panic. "The printer's broken! We can't print the Naughty or Nice List!" By the time you make it to sub-basement 17, there are only a few minutes until midnight. "We have a big problem," she says; "there must be almost fifty bugs in this system, but nothing else can print The List. Stand in this square, quick! There's no time to explain; if you can convince them to pay you in stars, you'll be able to--" She pulls a lever and the world goes blurry.

            //When your eyes can focus again, everything seems a lot more pixelated than before. She must have sent you inside the computer! You check the system clock: 25 milliseconds until midnight. With that much time, you should be able to collect all fifty stars by December 25th.

            //Collect stars by solving puzzles. Two puzzles will be made available on each day millisecond in the advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

            //You're standing in a room with "digitization quarantine" written in LEDs along one wall. The only door is locked, but it includes a small interface. "Restricted Area - Strictly No Digitized Users Allowed."

            //It goes on to explain that you may only leave by solving a captcha to prove you're not a human. Apparently, you only get one millisecond to solve the captcha: too fast for a normal human, but it feels like hours to you.

            //The captcha requires you to review a sequence of digits (your puzzle input) and find the sum of all digits that match the next digit in the list. The list is circular, so the digit after the last digit is the first digit in the list.

            //For example:

            //1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
            //1111 produces 4 because each digit (all 1) matches the next.
            //1234 produces 0 because no digit matches the next.
            //91212129 produces 9 because the only digit that matches the next one is the last digit, 9.
            //What is the solution to your captcha?

            Assert.AreEqual(1034, Day1.StarOne());
        }
        [TestMethod]
        public void Day1StarTwo()
        {
            //You notice a progress bar that jumps to 50% completion. Apparently, the door isn't yet satisfied, but it did emit a star as encouragement. The instructions change:

            //Now, instead of considering the next digit, it wants you to consider the digit halfway around the circular list. That is, if your list contains 10 items, only include a digit in your sum if the digit 10/2 = 5 steps forward matches it. Fortunately, your list has an even number of elements.

            //For example:

            //1212 produces 6: the list contains 4 items, and all four digits match the digit 2 items ahead.
            //1221 produces 0, because every comparison is between a 1 and a 2.
            //123425 produces 4, because both 2s match each other, but no other digit has a match.
            //123123 produces 12.
            //12131415 produces 4.
            //What is the solution to your new captcha?

            Assert.AreEqual(1356, Day1.StarTwo());
        }
        [TestMethod]
        public void Day2StarOne()
        {
            //As you walk through the door, a glowing humanoid shape yells in your direction. "You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor!"

            //The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

            //For example, given the following spreadsheet:

            //5 1 9 5
            //7 5 3
            //2 4 6 8
            //The first row's largest and smallest values are 9 and 1, and their difference is 8.
            //The second row's largest and smallest values are 7 and 3, and their difference is 4.
            //The third row's difference is 6.
            //In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.

            //What is the checksum for the spreadsheet in your puzzle input?
            
            Assert.AreEqual(30994, Day2.StartOneAndTwo());
        }
        [TestMethod]
        public void Day2StarTwo()
        {
            //"Great work; looks like we're on the right track after all. Here's a star for your effort." However, the program seems a little worried. Can programs be worried?

            //"Based on what we're seeing, it looks like all the User wanted is some information about the evenly divisible values in the spreadsheet. Unfortunately, none of us are equipped for that kind of calculation - most of us specialize in bitwise operations."

            //It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result.

            //For example, given the following spreadsheet:

            //5 9 2 8
            //9 4 7 3
            //3 8 6 5
            //In the first row, the only two numbers that evenly divide are 8 and 2; the result of this division is 4.
            //In the second row, the two numbers are 9 and 3; the result is 3.
            //In the third row, the result is 2.
            //In this example, the sum of the results would be 4 + 3 + 2 = 9.

            //What is the sum of each row's result in your puzzle input?

            Assert.AreEqual(233, Day2.StartOneAndTwo());
        }
        [TestMethod]
        public void Day3StarOne()
        {
            //You come across an experimental new kind of memory stored on an infinite two - dimensional grid.

            //Each square on the grid is allocated in a spiral pattern starting at a location marked 1 and then counting up while spiraling outward.For example, the first few squares are allocated like this:

            //17  16  15  14  13
            //18   5   4   3  12
            //19   6   1   2  11
            //20   7   8   9  10
            //21  22  23---> ...
            //While this is very space - efficient(no squares are skipped), requested data must be carried back to square 1(the location of the only access port for this memory system) by programs that can only move up, down, left, or right. They always take the shortest path: the Manhattan Distance between the location of the data and square 1.

            //For example:

            //Data from square 1 is carried 0 steps, since it's at the access port.
            //Data from square 12 is carried 3 steps, such as: down, left, left.
            //Data from square 23 is carried only 2 steps: up twice.
            //Data from square 1024 must be carried 31 steps.
            //How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?

            //Your puzzle input is 312051.
            Assert.AreEqual(430, Day3.StarOne());
        }
        [TestMethod]
        public void Day3StarTwo()
        {
            //As a stress test on the system, the programs here clear the grid and then store the value 1 in square 1. Then, in the same allocation order as shown above, they store the sum of the values in all adjacent squares, including diagonals.

            //So, the first few squares' values are chosen as follows:

            //Square 1 starts with the value 1.
            //Square 2 has only one adjacent filled square (with value 1), so it also stores 1.
            //Square 3 has both of the above squares as neighbors and stores the sum of their values, 2.
            //Square 4 has all three of the aforementioned squares as neighbors and stores the sum of their values, 4.
            //Square 5 only has the first and fourth squares as neighbors, so it gets the value 5.
            //Once a square is written, its value does not change. Therefore, the first few squares would receive the following values:

            //147  142  133  122   59
            //304    5    4    2   57
            //330   10    1    1   54
            //351   11   23   25   26
            //362  747  806--->   ...
            //What is the first value written that is larger than your puzzle input?

            Assert.AreEqual(312453, Day3.StarTwo());
        }
    }
}
