using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day2 : Day66
    {
        string[] lines;
        Dictionary<char, int> myChoicesEvaluation = new Dictionary<char, int>() {
            { 'X', 1 },
            { 'Y', 2 },
            { 'Z', 3 }
        };
        int _lose = 0;
        int _draw = 3;
        int _win = 6;

        //A rock 1
        //B Paper 2
        //C Scissors 3

        //X Rock 1
        //Y Paper 2
        //Z scissors 3

        //Lose 0
        //Draw 3
        //Win 6

        public override void ParseInput(string strInput)
        {
            lines = strInput.Split("\r\n");
            //pings = lines.Select(line => int.Parse(line)).ToArray();
        }

        public override object StarOne()
        {
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {

                char opponentChoice = lines[i][0];
                char myChoice = lines[i][2];
                int roundScore = EvaluateRound(opponentChoice, myChoice);
                sum += roundScore + myChoicesEvaluation[myChoice];


            }
            return sum;
        }

        private int EvaluateRound(char opponentChoice, char myChoice)
        {
            if (opponentChoice == myChoice)
            {
                return _draw;
            }
            int roundScore = 0;
            switch (opponentChoice)
            {
                case 'A':
                    if (myChoice == 'X')
                    {
                        return _draw;
                    }
                    if (myChoice == 'Y')
                    {
                        return _win;
                    }
                    if (myChoice == 'Z')
                    {
                        return _lose;
                    }
                    break;
                case 'B':
                    if (myChoice == 'X')
                    {
                        return _lose;
                    }
                    if (myChoice == 'Y')
                    {
                        return _draw;
                    }
                    if (myChoice == 'Z')
                    {
                        return _win;
                    }
                    break;
                case 'C':
                    if (myChoice == 'X')
                    {
                        return _win;
                    }
                    if (myChoice == 'Y')
                    {
                        return _lose;
                    }
                    if (myChoice == 'Z')
                    {
                        return _draw;
                    }
                    break;
                default:
                    throw new Exception("sth wrong");
            }
            return roundScore;
        }

        public override object StarTwo()
        {
            Dictionary<char, int> roundResultEvaluation = new Dictionary<char, int>() {
            { 'X', 0 },
            { 'Y', 3 },
            { 'Z', 6 }
             };
           
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {

                char opponentChoice = lines[i][0];
                char expectedResult = lines[i][2];
                int roundScore = EvaluateRoundStarTwo(opponentChoice, expectedResult);
                sum += roundScore + roundResultEvaluation[expectedResult];


            }
            return sum;
        }


        private int EvaluateRoundStarTwo(char opponentChoice, char expectedResult)
        {
            int rock = 1;
            int paper = 2;
            int scissors = 3;
            switch (opponentChoice)
            {
                case 'A':
                    if (expectedResult == 'X')//lose
                    {
                        return scissors;
                    }
                    if (expectedResult == 'Y')//draw
                    {
                        return rock;
                    }
                    if (expectedResult == 'Z')//win
                    {
                        return paper;
                    }
                    break;
                case 'B':
                    if (expectedResult == 'X')//lose
                    {
                        return rock;
                    }
                    if (expectedResult == 'Y')//draw
                    {
                        return paper;
                    }
                    if (expectedResult == 'Z')//win
                    {
                        return scissors;
                    }
                    break;
                case 'C':
                    if (expectedResult == 'X')//lose
                    {
                        return paper;
                    }
                    if (expectedResult == 'Y')//draw
                    {
                        return scissors;
                    }
                    if (expectedResult == 'Z')//win
                    {
                        return rock;
                    }
                    break;
                default:
                    throw new Exception("sth wrong");
            }
            return -1;
        }
    }
}
