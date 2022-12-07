using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace AdventOfCode2022
{
    class Directory
    {
        public override string ToString()
        {
            return "dir " + Name;
        }
        public string Name;
        public Directory Parent;
        public List<Directory> Directories;
        public List<File> Files;
        public long CountSize(Dictionary<string, long> _dirsSizes)
        {
            var localSum = Files.Select(file => file.Size).Sum() + Directories.Select(dir => dir.CountSize(_dirsSizes)).Sum();
            _dirsSizes.Add(string.Concat(Name,Guid.NewGuid().ToString()), localSum);
            return localSum;
        }
    }
    class File
    {
        public override string ToString()
        {
            return Name + "," + Size.ToString();
        }
        public string Name;
        public long Size;
    }

    public class Day7 : Day66
    {
        string _strInput;
        long _cutoffSize = 100000;
        Directory _topDir;
        Dictionary<string, long> _dirsSizes;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }
        private void BuildDirectories()
        {
            _dirsSizes = new Dictionary<string, long>();
            _topDir = MkDir("top", null);

            var lines = _strInput.Split("\r\n");
            int linePointer = 1;
            Directory currentDir = _topDir;

            while (linePointer < lines.Length)
            {
                var line = lines[linePointer].Split(' ');
                if (line[1] == "ls")
                {
                    //ls just skip    
                }
                if (line[0] == "dir")
                {
                    currentDir.Directories.Add(MkDir(line[1], currentDir));
                }
                if (Char.IsNumber(line[0][0]))
                {
                    var fileSize = Int64.Parse(line[0]);
                    currentDir.Files.Add(MkFile(fileSize, line[1]));
                }
                if (line[1] == "cd")
                {
                    if (line[2] == "..")
                    {
                        currentDir = currentDir.Parent;
                    }
                    else
                    {
                        currentDir = currentDir.Directories.Find(dir => dir.Name == line[2]);
                    }
                }
                linePointer++;
            }
        }

        private Directory MkDir(string name, Directory parent)
        {
            return new Directory()
            {
                Name = name,
                Directories = new List<Directory>(),
                Files = new List<File>(),
                Parent = parent
            };
        }
        private File MkFile(long size, string name)
        {
            return new File()
            {
                Name = name,
                Size = size
            };
        }
        public override object StarOne()
        {
            BuildDirectories();
            _topDir.CountSize(_dirsSizes);
            return _dirsSizes.Values.Where(dir => dir < _cutoffSize).Sum();
        }

        public override object StarTwo()
        {
            long totalSpace = 70000000;
            long neededSpace = 30000000;
            BuildDirectories();
            var usedSpace = _topDir.CountSize(_dirsSizes);
            var minimumToRemove = neededSpace - (totalSpace - usedSpace);

            return _dirsSizes.Values.Where(dir => dir > minimumToRemove).Min();
        }
    }
}
