using AdventOfCode.Shared;
using AdventOfCode.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4 : IDayX
    {
        public
        List<string> mandatoryFields = new List<string>() { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt" };
        List<Dictionary<string, string>> inputPassports;
        List<Dictionary<string, string>> passportsWithMandatoryFields;
        List<Dictionary<string, string>> validPassports;

        public int DayNumber()
        {
            return 4;
        }
        public Day4(string strInput)
        {
            inputPassports = new List<Dictionary<string, string>>();
            string[] separators = new string[] { "\r\n\r\n" };
            string[] lines = strInput.Split(separators, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var passportDict = new Dictionary<string, string>();
                var processedLine = line.Replace("\r\n", " ").Split(' ');
                foreach (var param in processedLine)
                {
                    var keyValuePair = param.Split(':');
                    passportDict.Add(keyValuePair[0], keyValuePair[1]);
                }
                inputPassports.Add(passportDict);
            }

        }
        public object StarOne(string strInput)
        {
            passportsWithMandatoryFields = new List<Dictionary<string, string>>();
            foreach (var passport in inputPassports)
            {
                if (CheckIfPassportContainsMandatoryFields(passport))
                {
                    passportsWithMandatoryFields.Add(passport);
                }
            }
            return passportsWithMandatoryFields.Count;
        }

        private bool CheckIfPassportContainsMandatoryFields(Dictionary<string, string> passportKeyValuePairs)
        {
            bool isValid = true;
            foreach (var mandatoryField in mandatoryFields)
            {
                if (!passportKeyValuePairs.ContainsKey(mandatoryField))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public object StarTwo(string strInput)
        {
            validPassports = new List<Dictionary<string, string>>();
            foreach (var passport in passportsWithMandatoryFields)
            {
                if (CheckIfPassportValuesMatchPattern(passport))
                {
                    validPassports.Add(passport);
                }
            }
            return validPassports.Count;
        }
        private bool CheckIfPassportValuesMatchPattern(Dictionary<string, string> passportKeyValuePairs)
        {
            if (!CheckIfPassportContainsMandatoryFields(passportKeyValuePairs))
            {
                return false;
            }
            EyeColor resultColor;
            return 
            // byr(Birth Year) - four digits; at least 1920 and at most 2002.
            TryGetIntAndCheckRange(passportKeyValuePairs["byr"], 1920, 2002) 
            // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
            && TryGetIntAndCheckRange(passportKeyValuePairs["iyr"], 2010, 2020)
            // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
            &&TryGetIntAndCheckRange(passportKeyValuePairs["eyr"], 2020, 2030)
            // hgt(Height) - a number followed by either cm or in:
            &&TryParseHeight(passportKeyValuePairs["hgt"])
            // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            &&Regex.IsMatch(passportKeyValuePairs["hcl"], "#[0-9 || a-f]{6}")
            // ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            &&Enum.TryParse(passportKeyValuePairs["ecl"], out resultColor)
            // pid(Passport ID) - a nine - digit number, including leading zeroes.
            &&CheckIfPassportIdIsValid(passportKeyValuePairs["pid"]);
            //178 too high
        }

        private bool TryGetIntAndCheckRange(string input, int minValue, int maxValue)
        {
            int result;
            if (Int32.TryParse(input, out result))
            {
                if (minValue <= result && result <= maxValue)
                {
                    return true;
                }
            }
            return false;
        }

        private bool TryParseHeight(string input)
        {
            // If cm, the number must be at least 150 and at most 193.
            // If in, the number must be at least 59 and at most 76.
            if (input.Contains("cm"))
            {
                var values = input.Split("cm");
                return TryGetIntAndCheckRange(values[0], 150, 193);

            }
            if (input.Contains("in"))
            {
                var values = input.Split("in");
                return TryGetIntAndCheckRange(values[0], 59, 76);
            }
            return false;
        }
       
        private bool CheckIfPassportIdIsValid(string inputPID)
        {
            if (inputPID.Length != 9)
            {
                return false;
            }
            int resultPID;
            return Int32.TryParse(inputPID, out resultPID);
        }

        enum EyeColor
        {
            amb, blu, brn, gry, grn, hzl, oth
        }
    }
}
