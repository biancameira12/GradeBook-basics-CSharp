using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letterGrade)
        {
            switch (letterGrade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                else
                {
                    throw new ArgumentException($"Invalid {nameof(grade)}");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid value ({grade}) entered.");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            result.CalculateStatistics(grades);
            return result;
        }

        private List<double> grades;
        public const string CATEGORY = "Computer Science";
    }
}