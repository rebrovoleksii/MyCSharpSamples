using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Grade
{
    public class GradeBook
    {
        private List<float> grades;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value && OnNameChanged != null)
                    {
                        var args = new NameChangedEventArgs() { ExistingName = _name, NewName = value };
                        OnNameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        public event NameChagedDelegate OnNameChanged;

        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeBook(string name)
        {
            this._name = name;
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeBookStatistics CalculateStatitics()
        {
            var stat = new GradeBookStatistics();
            stat.LowestGrade = float.MaxValue;
            stat.HighestGrade = 0;

            float sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
                if (grade > stat.HighestGrade)
                    stat.HighestGrade = grade;
                if (grade < stat.LowestGrade)
                    stat.LowestGrade = grade;
            }
            stat.AverageGrade = sum / grades.Count;

            return stat;
        }
    }
}
