using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day5 : IDayX
    {
        string[] lines;
        int[] seatsIDs;

        public int DayNumber()
        {
            return 5;
        }
        public Day5(string strInput)
        {
            lines = strInput.Split("\r\n");
            seatsIDs = new int[lines.Length];
        }

        public object StarOne(string strInput)
        {
            
            for (int i = 0; i < lines.Length; i++)
            {
                seatsIDs[i] = CalculateSeatID(lines[i]);
            }
            //987
            return seatsIDs.Max();
        }

        private int CalculateSeatID(string line)
        {
            int minRow = 0;
            int maxRow = 127;
            int minColumn = 0;
            int maxColumn = 7;
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case 'F':
                        maxRow = maxRow - (maxRow - minRow + 1) / 2;
                        break;
                    case 'B':
                        minRow = minRow + (maxRow - minRow + 1) / 2;
                        break;
                    case 'R':
                        minColumn = minColumn + (maxColumn - minColumn + 1) / 2;
                        break;
                    case 'L':
                        maxColumn = maxColumn - (maxColumn - minColumn + 1) / 2;
                        break;
                    default:
                        break;
                }
            }
            var finalRow = maxRow;
            var finalColumn = maxColumn;
            
            return finalRow * 8 + finalColumn;
        }

        public object StarTwo(string strInput)
        {
            Array.Sort(seatsIDs);
            for (int i = 0; i < seatsIDs.Length; i++)
            {
                if (seatsIDs[i+1] != seatsIDs[i] + 1)
                {
                    return seatsIDs[i] + 1;
                }
            }
            //603
            return -1;
        }
        
    }
}
