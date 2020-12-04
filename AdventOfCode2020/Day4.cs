using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day4 : IDayX
    {
        string[] passports;
        List<string> mandatoryFields = new List<string>() { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt" };

        public int DayNumber()
        {
            return 3;
        }
        public Day4(string strInput)
        {
            string[] separators = new string[] { "\r\n\r\n" };
            passports = strInput.Split(separators, StringSplitOptions.None);

        }
        public object StarOne(string strInput)
        {
            int validPassports = 0;
            foreach (var passport in passports)
            {
                if (CheckIfPassportIsValid(passport))
                {
                    validPassports++;
                }
            }
            return validPassports;
        }

        private bool CheckIfPassportIsValid(string passportInString)
        {
            bool isValid = true;
            foreach (var mandatoryField in mandatoryFields)
            {
                if (!passportInString.Contains(mandatoryField))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public object StarTwo(string strInput)
        {
            return true;
        }
    }
}
