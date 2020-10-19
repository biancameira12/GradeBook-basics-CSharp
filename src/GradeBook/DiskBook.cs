using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {

                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = Convert.ToDouble(line);
                    grades.Add(grade);
                }
            }

            result.CalculateStatistics(grades);
            return result;
        }
        private List<double> grades;
    }
}
