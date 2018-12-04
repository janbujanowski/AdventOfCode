using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public interface IDayX
    {
        int DayNumber();

        object StarOne(string strInput);

        object StarTwo(string strInput);

    }
}
