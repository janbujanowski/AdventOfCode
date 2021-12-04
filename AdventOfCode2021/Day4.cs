using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    //44 + jakies 10
    public class Day4 : Day66
    {
        string _strInput;
        string[] lines;
        List<int> bingoPickCollection;

        Dictionary<int, List<int>> boardsMarks;
        Dictionary<int, List<List<int>>> bingoBoardsAsRows;
        Tuple<int, int> winningBoardAndRow;
        List<Tuple<int, int>> allWinningBoardsAndRows;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
            var linesList = strInput.Split("\r\n").ToList();
            linesList.Add("");
            lines = linesList.ToArray();
            bingoPickCollection = lines[0].Split(',').Select(number => int.Parse(number)).ToList();

            allWinningBoardsAndRows = new List<Tuple<int, int>>();
            bingoBoardsAsRows = new Dictionary<int, List<List<int>>>();
            List<List<int>> bingoArrayAsRows = new List<List<int>>();
            int bingoArrayCounter = 0;
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    bingoBoardsAsRows.Add(bingoArrayCounter, bingoArrayAsRows);
                    bingoArrayAsRows = new List<List<int>>();
                    bingoArrayCounter++;
                }
                else
                {
                    bingoArrayAsRows.Add(lines[i].Trim().Replace("  ", " ").Split(" ").Select(number => int.Parse(number)).ToList());
                }
            }

            for (int i = 0; i < bingoBoardsAsRows.Count; i++)
            {
                bingoBoardsAsRows[i] = AddVertical(bingoBoardsAsRows[i]);
            }

        }

        private List<List<int>> AddVertical(List<List<int>> list)
        {
            var verticalRows = new List<List<int>>();
            for (int i = 0; i < list[0].Count; i++)
            {
                List<int> verticalRow = new List<int>();
                foreach (var horizontalRow in list)
                {
                    verticalRow.Add(horizontalRow.ElementAt(i));
                }
                verticalRows.Add(verticalRow);
            }

            list.AddRange(verticalRows);
            return list;
        }

        public override object StarOne()
        {
            int boardSize = 5;
            int bingoCounter = -1;
            bool boardHasBingo = false;
            boardsMarks = InitializeBlankMarks(bingoBoardsAsRows.Count);
            while (!boardHasBingo)
            {
                bingoCounter++;
                MarkBoards(bingoPickCollection[bingoCounter]);
                if (bingoCounter >= boardSize)
                {
                    boardHasBingo = EvaluateCards(boardSize);
                }
            }

            int resultSum = GetSumOfUnmarkedNumbers(allWinningBoardsAndRows.First());
            return resultSum * bingoPickCollection[bingoCounter];
        }


        private Dictionary<int, List<int>> InitializeBlankMarks(int count)
        {
            var cleanBoardsMarks = new Dictionary<int, List<int>>();
            for (int i = 0; i < count; i++)
            {
                cleanBoardsMarks.Add(i, new List<int>());
            }
            return cleanBoardsMarks;
        }

        private void MarkBoards(int number)
        {
            for (int i = 0; i < bingoBoardsAsRows.Count; i++)
            {
                foreach (var row in bingoBoardsAsRows[i])
                {
                    if (row.Contains(number))
                    {
                        boardsMarks[i].Add(number);
                    }
                }
            }
        }

        private bool EvaluateCards(int boardSize)
        {
            bool boardHasBingo = false;
            foreach (var card in boardsMarks.Where(board => board.Value.Count >= boardSize))
            {
                List<int> markedList = card.Value;
                for (int i = 0; i < bingoBoardsAsRows[card.Key].Count; i++)
                {
                    if (bingoBoardsAsRows[card.Key][i].Intersect(markedList).Count() == boardSize)
                    {
                        boardHasBingo = true;
                        if (!allWinningBoardsAndRows.Where(x => x.Item1 == card.Key).Any())
                        {
                            allWinningBoardsAndRows.Add(new Tuple<int, int>(card.Key, i));
                        }
                    }
                }

            }
            return boardHasBingo;
        }
        private int GetSumOfUnmarkedNumbers(Tuple<int, int> winningBoardAndRow)
        {
            int sum = 0;
            for (int i = 0; i < bingoBoardsAsRows[winningBoardAndRow.Item1].Count / 2; i++)
            {
                var unmarkedNumbers = bingoBoardsAsRows[winningBoardAndRow.Item1][i].Except(boardsMarks[winningBoardAndRow.Item1]);
                sum += unmarkedNumbers.Sum();
            }
            return sum;
        }


        public override object StarTwo()
        {
            int boardSize = 5;
            int bingoCounter = -1;
            bool boardHasBingo = false;
            boardsMarks = InitializeBlankMarks(bingoBoardsAsRows.Count);
            while (allWinningBoardsAndRows.Count < boardsMarks.Count)
            {
                bingoCounter++;
                MarkBoards(bingoPickCollection[bingoCounter]);
                if (bingoCounter >= boardSize)
                {
                    boardHasBingo = EvaluateCards(boardSize);
                }
            }

            int resultSum = GetSumOfUnmarkedNumbers(allWinningBoardsAndRows.Last());
            return resultSum * bingoPickCollection[bingoCounter];
        }
    }
}