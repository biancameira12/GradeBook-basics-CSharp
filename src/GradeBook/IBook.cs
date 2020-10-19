using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        void DisplayStatistics(Statistics statistics);
        Statistics GetStatistics();
        
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}
