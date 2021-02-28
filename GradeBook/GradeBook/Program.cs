using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Grades newGradeList = new Grades("XII A");
            newGradeList.GradeAdded += OnGradeAdded;

            Console.WriteLine("Enter the grades\n Or press 'Q' or 'q' to exit");
            bool complete = false;
            
            while(!complete)
            {
                string userInput = Console.ReadLine();
                if (userInput != "Q" && userInput != "q")
                {
                    try
                    {
                        float grade = float.Parse(userInput);
                        newGradeList.AddGrades(grade);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    complete = true;
                    continue;
                }
            }
            
            ReturnStatistics result = newGradeList.ComputeStatistics();
            string className = newGradeList.GetClassName();
            
            Console.WriteLine($"The following grades are for class {className} ---------->");
            Console.WriteLine($"The highest grade is {result.HighestGrade}");
            Console.WriteLine($"The Lowest grade is {result.LowestGrade}");
            Console.WriteLine($"The average of all the grades is {result.Average}\n");
            Console.WriteLine($"The class grade is {result.LetterGrade}\n");
           
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade was added");
        }
    }
}
