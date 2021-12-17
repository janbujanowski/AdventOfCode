using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{

    public class Day16 : Day66
    {
        class Packet
        {
            public string Type { get; set; }
            public string Version { get; set; }
            public string Length { get; set; }
            public List<string> Values { get; set; }
        }
        string _strInput;
        string _startString;
        public override void ParseInput(string strInput)
        {
            _strInput = strInput;
        }
        private List<string> ConvertStringToBinaryList(string input)
        {
            return input.Select(letter => Convert.ToString(Convert.ToInt32(letter.ToString(), 16), 2).PadLeft(4, '0')).ToList();
        }
        string _packetTypeLiteral = "100"; //binary 4;
        public override object StarOne()
        {
            int stepsCount = 10;
            var lol = ConvertStringToBinaryList(_strInput);
            string BITSmsg = string.Join(string.Empty, lol);
            string currentWord = string.Empty;
            bool isFullWord = false;
            bool packetChecked = false;
            bool versionChecked = false;
            int currentPacketLengthCounter = 0;
            List<Packet> packets = new List<Packet>();
            string currentPacketVersion = string.Empty;
            string currentPacketType = string.Empty;
            int nextPacketLength = 15;
            for (int charPointer = 0; charPointer < BITSmsg.Length; charPointer++)
            {
                currentWord += BITSmsg[charPointer];
                currentPacketLengthCounter++;
                if (currentPacketLengthCounter == 3)
                {
                    currentPacketVersion = currentWord;
                    currentWord = string.Empty;
                }
                if (currentPacketLengthCounter == 6)
                {
                    currentPacketType = currentWord;
                    currentWord = string.Empty;
                }
                if (currentPacketType == _packetTypeLiteral && currentPacketLengthCounter == 24)
                {
                    //todo assign words
                    packets.Add(new Packet()
                    {
                        Version = currentPacketVersion,
                        Type = currentPacketType
                    });
                    currentPacketVersion = string.Empty;
                    currentPacketType = string.Empty;
                    currentPacketLengthCounter = 0;
                }
                if (IsPacketButNotLiteral(currentWord))
                {

                }
               

                //Console.WriteLine(_startString);
            }
            return -1;
        }

        private bool IsPacketButNotLiteral(string currentWord)
        {
            int minimumLengthToBeAbleToValidate = 7;
            if (currentWord.Length > minimumLengthToBeAbleToValidate)
            {
                if (!string.IsNullOrEmpty(currentWord))
                {
                    return true;
                }
            }
            return false;
        }

        Dictionary<char, int> _charCount;
        public override object StarTwo()
        {
            //GenerateCharCounter();
            int stepsCount = 10;
            ParseInput(_strInput);
            return stepsCount;
        }
    }
}