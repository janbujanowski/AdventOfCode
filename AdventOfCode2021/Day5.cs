using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //44 + jakies 10
    public class Day5 : Day66
    {
        string _strInput;
        int[,] pointersToLines;
        int diagramSize = 1000;
        int pointsLength;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            var lines = _strInput.Split("\r\n");

            pointersToLines = new int[lines.Length, 4];
            pointsLength = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] coordsPairsStr = lines[i].Replace(" -> ", ",").Split(",");
                int[] coordsPairs = coordsPairsStr.Select(num => int.Parse(num)).ToArray();
                for (int j = 0; j < 4; j++)
                {
                    pointersToLines[i, j] = coordsPairs[j];
                }
            }
        }

        public override object StarOne()
        {
            int[,] diagram = new int[diagramSize, diagramSize];
            
            for (int i = 0; i < pointsLength; i++)
            {
                int x1 = pointersToLines[i, 0];
                int y1 = pointersToLines[i, 1];
                int x2 = pointersToLines[i, 2];
                int y2 = pointersToLines[i, 3];

                if (IsHorizontalOrVertical(x1,y1,x2,y2))
                {
                    AddToDiagram(x1, y1, x2, y2, diagram);
                    //PrintDiagram(diagram);
                }
            }
            int result = CountAllAboveOne(diagram);
            
            return result;
        }
        private bool IsHorizontalOrVertical(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 || y1 == y2;
        }
        private void AddToDiagram(int x1, int y1, int x2, int y2, int[,] diagram)
        {
            CheckAndReplaceIfNeeded(ref x1, ref y1, ref x2, ref y2);
            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    diagram[i, j]++;
                }
            }
        }
        private void CheckAndReplaceIfNeeded(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            int memo = 0;
            if (x2 < x1)
            {
                memo = x1; x1 = x2; x2 = memo;
            }
            if (y2 < y1)
            {
                memo = y1; y1 = y2; y2 = memo;
            }
        }
        private int CountAllAboveOne(int[,] diagram)
        {
            int sum = 0;
            for (int i = 0; i < diagramSize; i++)
            {
                for (int j = 0; j < diagramSize; j++)
                {
                    if (diagram[i,j] > 1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }

        public override object StarTwo()
        {
            int boardSize = 5;
       
            return boardSize;
        }
        private void PrintDiagram(int[,] diagram)
        {
            for (int i = 0; i < diagramSize; i++)
            {
                for (int j = 0; j < diagramSize; j++)
                {
                    Console.Write(diagram[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}