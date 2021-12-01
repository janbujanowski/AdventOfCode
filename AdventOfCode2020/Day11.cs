using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day11 : Day66
    {
        enum SeatDefinition
        {
            Floor = '.',
            Empty = 'L',
            Occupied = '#'
        }

        SeatDefinition[,] seatDefinitions;
        List<(int, int)> adjacentSeats = new List<(int, int)>()
            {
                (-1, -1), (-1, 0), (-1, 1),
                 (0, -1),           (0, 1),
                 (1, -1),  (1, 0),  (1, 1)
            };

        public override void ParseInput(string strInput)
        {
            var lines = strInput.Split("\r\n");
            seatDefinitions = new SeatDefinition[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    seatDefinitions[i, j] = (SeatDefinition)lines[i][j];
                }
            }
        }

        public override object StarOne()
        {
            //2265 yeas
            var repeatCycle = true;
            SeatDefinition[,] seatState = seatDefinitions;
            int rounds = 0;
            while (repeatCycle)
            {
                (bool, SeatDefinition[,]) newState = ExecuteMoveCycle(seatState);
                repeatCycle = newState.Item1;
                seatState = newState.Item2;
                //rounds++;
                //for (int i = 0; i < seatState.GetLength(0); i++)
                //{
                //    for (int j = 0; j < seatState.GetLength(1); j++)
                //    {
                //        Console.Write((char)seatState[i, j]);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine($"Round : {rounds}");
            }
            
            int emptySeats = CountOccupiedSeats(seatState);
            return emptySeats;
        }


        private (bool, SeatDefinition[,]) ExecuteMoveCycle(SeatDefinition[,] seatState)
        {
            var aMoveWasMade = false;
            SeatDefinition[,] newSeatsState = new SeatDefinition[seatState.GetLength(0), seatState.GetLength(1)];
            for (int i = 0; i < seatState.GetLength(0); i++)
            {
                for (int j = 0; j < seatState.GetLength(1); j++)
                {
                    SeatDefinition newState = seatState[i, j];
                    switch (seatState[i, j])
                    {
                        case SeatDefinition.Floor:
                            //leave umodified
                            break;
                        case SeatDefinition.Empty:
                            newState = TryChangeEmptyToOccupied(seatState, i, j);
                            break;
                        case SeatDefinition.Occupied:
                            newState = TryChangeOccupiedToEmpty(seatState, i, j);
                            break;
                        default:
                            break;
                    }
                    if (newState != seatState[i, j])
                    {
                        aMoveWasMade = true;
                    }
                    newSeatsState[i, j] = newState;
                }
            }
            return (aMoveWasMade, newSeatsState);
        }

        private SeatDefinition TryChangeOccupiedToEmpty(SeatDefinition[,] seatState, int i, int j)
        {
            SeatDefinition result = SeatDefinition.Occupied;
            int adjacentOccupiedSeatsCount = 0;
            foreach (var seatModifier in adjacentSeats)
            {
                int seatPositionX = i + seatModifier.Item1;
                int seatPositionY = j + seatModifier.Item2;
                if (seatPositionX >= 0 && seatPositionX < seatState.GetLength(0) && seatPositionY >= 0 && seatPositionY < seatState.GetLength(1))
                {
                    if (seatState[seatPositionX, seatPositionY] == SeatDefinition.Occupied)
                    {
                        adjacentOccupiedSeatsCount++;
                    }
                }
            }
            if (adjacentOccupiedSeatsCount >= 4)
            {
                result = SeatDefinition.Empty;
            }
            return result;
        }

        private SeatDefinition TryChangeEmptyToOccupied(SeatDefinition[,] seatState, int i, int j)
        {
            SeatDefinition result = SeatDefinition.Occupied;
            foreach (var seatModifier in adjacentSeats)
            {
                int seatPositionX = i + seatModifier.Item1;
                int seatPositionY = j + seatModifier.Item2;
                if (seatPositionX >= 0 && seatPositionX < seatState.GetLength(0) && seatPositionY >= 0 && seatPositionY < seatState.GetLength(1))
                {
                    if (seatState[seatPositionX, seatPositionY] == SeatDefinition.Occupied)
                    {
                        result = SeatDefinition.Empty;
                        break;
                    }
                }
            }
            return result;
        }

        private int CountOccupiedSeats(SeatDefinition[,] seatState)
        {
            int count = 0;
            foreach (var row in seatState)
            {
                if (row == SeatDefinition.Occupied)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
