using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public void DisplayStatistics(Statistics statistics)
        {
            Console.WriteLine($"Average grade of {Name} is {statistics.Average:N1}");
            Console.WriteLine($"Lowest grade of {Name} is {statistics.Low}");
            Console.WriteLine($"Highest grade of {Name} is {statistics.High}");
            Console.WriteLine($"The letter grade of {Name} is {statistics.Letter}");
        }
    }
}
