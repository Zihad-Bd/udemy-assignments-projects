using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment48
{
    internal class Student : IStudent
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public List<ITestPaper> TestPapers { get; set; }
    }
}
