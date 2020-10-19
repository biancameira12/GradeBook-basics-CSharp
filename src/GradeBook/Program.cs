using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook(name: "Gradebook 1");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            var result = book.GetStatistics();
            book.DisplayStatistics(result);
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

        private static void EnterGrades(IBook book)
        {
            var doing = true;
            while (doing)
            {
                try
                {
                    Console.Write("Do you want to enter a grade?(y/n)");
                    var response = Console.ReadLine();
                    if (response == "y")
                    {
                        try
                        {
                            Console.Write("Enter a grade: ");
                            var grade = Convert.ToDouble(Console.ReadLine());
                            book.AddGrade(grade);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (response == "n")
                    {
                        Console.WriteLine("Nice working with you, goodbye!");
                        doing = false;
                    }
                    else
                    {
                        throw new ArgumentException("Please enter the character 'y' to continue entering numbers or 'n' to stop");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }
    }
}