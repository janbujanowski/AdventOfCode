using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public interface IinputProvider
    {
        string GetInput(int year, int day);
    }
}
