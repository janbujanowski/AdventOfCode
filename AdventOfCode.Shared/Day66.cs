using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public abstract class Day66
    {
        string defaultClassMessage = "This is default abstract implementantion result";
        public int DayNumber
        {
            get
            {
                int dayNumber = default;
                string className = this.GetType().Name;
                string availableNumbers = string.Empty;
                for (int i = 0; i < className.Length; i++)
                {
                    if (Char.IsDigit(className[i]))
                    {
                        availableNumbers += className[i];
                    }
                }
                int.TryParse(availableNumbers, out dayNumber);
                return dayNumber;
            }
        }

        public int YearNumber
        {
            get
            {
                int yearNumber = default;
                var definitonAssembly = Assembly.GetAssembly(this.GetType());
                string assemblyName = definitonAssembly.GetName().Name;
                string availableNumbers = string.Empty;
                for (int i = 0; i < assemblyName.Length; i++)
                {
                    if (Char.IsDigit(assemblyName[i]))
                    {
                        availableNumbers += assemblyName[i];
                    }
                }
                int.TryParse(availableNumbers, out yearNumber);
                return yearNumber;
            }
        }
        
        public virtual void ParseInput(string strInput)
        {
        }

        public virtual object StarOne()
        {
            return defaultClassMessage;
        }

        public virtual object StarTwo()
        {
            return defaultClassMessage;
        }
    }
}
