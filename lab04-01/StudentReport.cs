using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_01
{
    internal class StudentReport
    {
        public string StudentID { get; set; }

        public string FullName { get; set; }

        public double AverageScore { get; set;}
        //public virtual Faculty Faculty { get; set; }

        public string Faculty { get; set; }
    }
}
