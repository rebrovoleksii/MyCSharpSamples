using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Grade
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeBookStatistics CalculateStatitics()
        {
            var lowestGrade = float.MaxValue;
            foreach (var grade in grades)
            {
                if (lowestGrade > grade) lowestGrade = grade;
            }
            grades.Remove(lowestGrade);

            return base.CalculateStatitics();
        } 

        public override String GetClassNameVirtual()
        {
            return "ThrowAwayGradeBook";
        }

        public String GetClassName()
        {
            return "ThrowAwayGradeBook";
        }

        // non virtual methods could not be overriden
        //public override String GetClassName()
        //{
        //    return "ThrowAwayGradeBook";
        //}
    }
}
