using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment48
{
    internal interface IStudent
    {
        int RollNo { get; set; }
        string StudentName { get; set; }
        List<ITestPaper> TestPapers { get; set; }
    }
}
