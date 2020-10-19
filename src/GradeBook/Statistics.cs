using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void CalculateStatistics(List<double> grades)
        {
            for (var index = 0; index < grades.Count; index++)
            {
                High = Math.Max(grades[index], High);
                Low = Math.Min(grades[index], Low);
                Average += grades[index];
            }

            Average /= grades.Count;
        }
    }
}
