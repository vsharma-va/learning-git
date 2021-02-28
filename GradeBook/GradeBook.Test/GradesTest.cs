using System;
using Xunit;


namespace GradeBook.Test
{
    public class GradesTest
    {
        [Fact]
        public void GradesListStatisticsTest()
        {

            /*First create a reference to the Grade Book project 
             * then make the grades class public so that it can be accessed by this unit test
             * then create an instance of it*/ 
             
            //Arrange (This is where all the values are assigned)
            Grades whatis = new Grades("XII A");
            whatis.AddGrades(55.45f);
            whatis.AddGrades(95.35f);
            whatis.AddGrades(77.66f);
            whatis.AddGrades(87.66f);

            //Actual Values (This is where the values are computed)
            ReturnStatistics result = whatis.ComputeStatistics();
            string className = whatis.GetClassName();

            //Assert(This is where the tests are written)
            
            Assert.Equal(79.03, result.Average, 2); //(expected value, actual value, how many decimal places to check)
            Assert.Equal(95.35f, result.HighestGrade, 2);
            Assert.Equal(55.45f, result.LowestGrade, 2);
            Assert.Equal("XII A", className);
            Assert.Equal('C', result.LetterGrade);

        }
    }
}
