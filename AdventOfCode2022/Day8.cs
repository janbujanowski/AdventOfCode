using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2022
{
    public class Day8 : Day66
    {
        int[,,] _forestLayers;
        string _strInput;
        int xSize;
        int ySize;

        public override void ParseInput(string strInput)
        {
            _strInput = strInput;

        }
        private int[,,] BuildForest(string strInput, int visibilityLayers)
        {
            var lines = strInput.Split("\r\n");
            xSize = lines[0].Length;
            ySize = lines.Length;
            var realLayerId = 0;
            var outputForest = new int[xSize, ySize, visibilityLayers + 1];
            for (int i = 0; i < ySize; i++)
            {
                string line = lines[i];
                for (int j = 0; j < xSize; j++)
                {
                    outputForest[j, i, realLayerId] = int.Parse(line[j].ToString());
                }
            }
            return outputForest;
        }
        public override object StarOne()
        {
            _forestLayers = BuildForest(_strInput, 4);
            BuildVisibilityLayers(_forestLayers);
            int visibleTrees = CountVisible(_forestLayers);
            return visibleTrees;
        }

        private int CountVisible(int[,,] forestLayers)
        {
            int sumVisible = xSize + xSize + ySize + ySize -4;
            int sumTree; 
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    sumTree= 0;
                    for (int i = 1; i <= 4; i++)
                    {
                        sumTree+= forestLayers[x,y,i];
                    }
                    if (sumTree>0)
                    {
                        sumVisible++;
                    }
                }
            }
            return sumVisible;
        }

        private void BuildVisibilityLayers(int[,,] forestLayers)
        {
            int maxFromLeft = 0;
            int maxFromTop = 0;
            int maxFromRight = 0;
            int maxFromBottom = 0;
            int forestLayer = 0;
            int layerFromLeft = 1;
            int layerFromTop = 2;
            int layerFromRight = 3;
            int layerFromBottom = 4;
            for (int y = 1; y < ySize-1; y++)
            {
                maxFromLeft = forestLayers[0, y, forestLayer];
                maxFromRight = forestLayers[ySize-1, y, forestLayer];
                for (int x = 1; x < xSize-1; x++)
                {
                    if (forestLayers[x , y, forestLayer] > maxFromLeft)
                    {
                        forestLayers[x, y, layerFromLeft] = 1;
                        maxFromLeft = forestLayers[x, y, forestLayer];
                    }
                    if (forestLayers[xSize -1 - x, y, forestLayer] > maxFromRight)
                    {
                        forestLayers[xSize -1 -x, y, layerFromRight] = 1;
                        maxFromRight = forestLayers[xSize - 1 - x, y, forestLayer];
                    }
                }
            }
            for (int x = 1; x < xSize - 1; x++)
            {
                maxFromTop = forestLayers[x, 0, forestLayer];
                maxFromBottom = forestLayers[x, ySize-1, forestLayer];
                for (int y = 1; y < ySize - 1; y++)
                {
                    if (forestLayers[x, y, forestLayer] > maxFromTop)
                    {
                        forestLayers[x, y, layerFromTop] = 1;
                        maxFromTop = forestLayers[x, y, forestLayer];
                    }
                    if (forestLayers[x, ySize -1 - y, forestLayer] > maxFromBottom)
                    {
                        forestLayers[x, ySize - 1 - y, layerFromBottom] = 1;
                        maxFromBottom = forestLayers[x, ySize - 1 - y, forestLayer];
                    }
                }
            }
        }

        public override object StarTwo()
        {
            long maxScenicScore= 1;
            long currentScenicScore = 1;
            for (int x = 1; x < xSize-1; x++)
            {
                for (int y = 1; y < ySize-1; y++)
                {
                    currentScenicScore = CountTrees(x, y, 1, 0) * CountTrees(x, y, -1, 0) * CountTrees(x, y, 0, 1) * CountTrees(x, y, 0, -1);
                    if (currentScenicScore > maxScenicScore)
                    {
                        maxScenicScore = currentScenicScore;
                    }
                }
            }
            
            return maxScenicScore;
        }
        int CountTrees(int startx, int starty, int directionX, int directionY)
        {
            int startHeight = _forestLayers[startx, starty, 0];
            int currentX = startx; int currentY = starty;
            int count = 0;
            bool stop = false;
            while (currentX + directionX >= 0 && currentX + directionX < xSize && currentY + directionY >= 0 && currentY + directionY < ySize && !stop)
            {
                currentX += directionX;currentY += directionY;
                count++;
                if (_forestLayers[currentX,currentY,0] >= startHeight)
                {
                    stop = true;
                }
            }
            return count;
        }
    }
}
