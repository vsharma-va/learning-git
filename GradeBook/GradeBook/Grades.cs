using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Grades
    {
        private string className;
        private List<float> gradeList;
        
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        //properties help us to make a certain member or variable public 
        //in properties you can set some conditions which take place when someone is setting that variable
        //or getting that variable i.e changing the value or reading the value
        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                //there is a implicit variable called value available in set
                //this variable will store the value which is being stored in the variable/method
                //we are making public, which in this case is className
                if(!string.IsNullOrEmpty(value))
                {
                    className = value;
                }
                else
                {
                    throw new ArgumentException($"The value assigned to ClassName is an empty string");
                }
            }
        }


        public Grades(string className)
        {
            gradeList = new List<float>();
            this.className = className;
        }
        
        //you can have two same name methods but they have to have different arguments/parameters
        //this is called method overloading
        public void AddGrades(char Letters)
        {
            switch(Letters)
            {
                case 'A':
                    AddGrades(90.0f);
                    break;
                case 'B':
                    AddGrades(80.0f);
                    break;
                case 'C':
                    AddGrades(70.0f);
                    break;
                case 'D':
                    AddGrades(60.0f);
                    break;
                case 'E':
                    AddGrades(50.0f);
                    break;
                case 'F':
                    AddGrades(0.0f);
                    break;
            }
        }



        //Method to add a grade to the list above with some simple checks for the input value
        public ReturnStatistics AddGrades(float gradeToAdd)
        {
            ReturnStatistics returnValue = new ReturnStatistics();
            if(gradeToAdd <= 100 && gradeToAdd >= 0)
            {
                gradeList.Add(gradeToAdd);
                if(GradeAdded != null)
                {
                    //this is an event which is called(Event at the end)
                    //this event will be called whenever a grade is added 
                    //in Program.cs newGradeList.GradeAdded is called and is added to OnGradeAdded
                    //OnGradeAdded must be defined in such a way it can be called by the delegate 
                    //since the event GradeAdded is null adding OnGradeAdded to it makes it display whatever
                    //OnGradeAdded writes
                    GradeAdded(this, new EventArgs());
                }
                
                returnValue.GradeValue = gradeToAdd;
            }
            else
            {
                returnValue.Error = "Invalid Input";
                throw new ArgumentException($"{(gradeToAdd)} invalid input");
                }
            return returnValue;
        }

        //this method returns the value in the form of a class/object in this case the class/object is
        //ReturnStatistics
        //ReturnStatistics has 3 float variables which are public i.e available to all the instances of
        //ReturnStatistics class/object 
        //These variables are used to store the values of all the calculations in ComputeStatistics()
        public ReturnStatistics ComputeStatistics()
        {
            ReturnStatistics result = new ReturnStatistics();
            result.Average = 0.0f;
            result.HighestGrade = float.MinValue;
            result.LowestGrade = float.MaxValue;

            float sumGrade = 0;
            //int indexCounter = 0;

            //do
            //{
            //    result.HighestGrade = Math.Max(gradeList[indexCounter], result.HighestGrade);
            //    result.LowestGrade = Math.Min(gradeList[indexCounter], result.LowestGrade);
            //    sumGrade += gradeList[indexCounter];
            //    ++indexCounter;
            //} while(indexCounter < gradeList.Count);

            //while(indexCounter < gradeList.Count)
            //{
            //    result.HighestGrade = Math.Max(gradeList[indexCounter], result.HighestGrade);
            //    result.LowestGrade = Math.Min(gradeList[indexCounter], result.LowestGrade);
            //    sumGrade += gradeList[indexCounter];
            //    ++indexCounter;
            //}

            for(int indexCounter = 0; indexCounter < gradeList.Count; indexCounter ++)
            {
                result.HighestGrade = Math.Max(gradeList[indexCounter], result.HighestGrade);
                result.LowestGrade = Math.Min(gradeList[indexCounter], result.LowestGrade);
                sumGrade += gradeList[indexCounter];
            }

            result.Average = sumGrade / gradeList.Count;

            switch (result.Average)
            {
                //Char is always enclosed in single inverted commas
                case float avg when avg >= 90.0:
                    result.LetterGrade = 'A';
                    break;

                case float avg when avg >= 80.0:
                    result.LetterGrade = 'B';
                    break;

                case float avg when avg >= 70.0:
                    result.LetterGrade = 'C';
                    break;

                case float avg when avg >= 60.0:
                    result.LetterGrade = 'D';
                    break;

                case float avg when avg >= 50.0:
                    result.LetterGrade = 'E';
                    break;

                default:
                    result.LetterGrade = 'F';
                    break;
            }

            return result;
        }

        public string GetClassName()
        {
            return className;
        }

        public event GradeAddedDelegate GradeAdded; //this is an event 
    }
}
