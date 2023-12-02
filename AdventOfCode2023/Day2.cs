using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day2 : Day66
    {
        class Game
        {
            public int Id;
            public List<CubeDraw> CubeDraws;
        }
        class CubeDraw
        {
            public int Red, Green, Blue;
        }
        int RedLimit;
        int GreenLimit;
        int BlueLimit;

        string[] lines;
        List<Game> games;
        public override void ParseInput(string strInput)
        {
            games = new List<Game>();
            lines = strInput.Split("\r\n");
            foreach (var line in lines)
            {
                int gameId = int.Parse(line.Split(':')[0].Remove(0, 5));
                Game game = new Game() { Id = gameId, CubeDraws = new List<CubeDraw>() };
                var draws = line.Split(':')[1].Split(';');
                foreach (var draw in draws)
                {
                    var balls = draw.Split(',');
                    CubeDraw cubeDraw = new CubeDraw();
                    foreach (var ballset in balls)
                    {
                        var ballsInfo = ballset.Trim().Split(' ');
                        int count = int.Parse(ballsInfo[0]);
                        switch (ballsInfo[1])
                        {
                            case "blue":
                                cubeDraw.Blue = count;
                                break;
                            case "red":
                                cubeDraw.Red = count;
                                break;
                            case "green":
                                cubeDraw.Green = count;
                                break;
                            default:
                                break;
                        }
                        
                    }
                    game.CubeDraws.Add(cubeDraw);
                }
                games.Add(game);
            }
        }

        public override object StarOne()
        {
            RedLimit = 12;
            GreenLimit = 13;
            BlueLimit = 14;

            int sum = 0;
            foreach (var game in games)
            {
                if (!game.CubeDraws.Any(draw => draw.Red > RedLimit || draw.Blue > BlueLimit || draw.Green > GreenLimit))
                {
                    sum += game.Id;
                }
            }
            return sum;
        }
        private int GetCalibrationNumberStarOne(string line)
        {
            int calibration = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    calibration += 10 * Int32.Parse(line[i].ToString());
                    i = line.Length;
                }
            }
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    calibration += Int32.Parse(line[i].ToString());
                    i = 0;
                }
            }
            return calibration;
        }
       

        public override object StarTwo()
        {

            int sum = 0;

            foreach (var line in lines)
            {
                sum += GetCalibrationNumber(line);

            }
            return sum;
        }

        public int GetCalibrationNumber(string line)
        {

            return 1;
        }
    }
}
