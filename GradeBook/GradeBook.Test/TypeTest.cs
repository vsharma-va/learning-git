using System;
using Xunit;

namespace GradeBook.Test
{
    public class TypeTest
    {
        //this is like a variable which can be used to call functions that return string and 
        //take string as an parameter
        public delegate string WriteLogDelegate(string logValue);

        [Fact]
        public void DelegateTest()
        {
            WriteLogDelegate log = new WriteLogDelegate(ReturnString);
            string checker = log("Hello");

            Assert.Equal("Hello", checker);
        }

        private string ReturnString(string value)
        {
            return value;
        }

        [Fact]
        public void Test1()
        {
            int x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);

        }

        private void SetInt(ref int value)
        {
            value = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ParameterCanBePassedByRef()
        {
            Grades joke = new Grades("First");
            PassValueByRef(ref joke, "Second");

            Assert.Equal("Second", joke.ClassName);
        }

        private void PassValueByRef(ref Grades joke, string v)
        {
            joke = new Grades(v);
        }

        [Fact]
        public void GetGradesReturnDifferentObjects()
        {
            var first = new Grades("XII A");
            var second = new Grades("XI A");

            Assert.Equal("XII A", first.ClassName);
            Assert.Equal("XI A", second.ClassName);
            Assert.NotSame(first, second); //Alternate method to check the above two asserts
        }

        [Fact]
        public void CSharpParameterIsPassedByValueByDefault()
        {
            Grades secondInstance = new Grades("Hello");
            
            GetSetName(secondInstance, "Why");

            Assert.Equal("Hello", secondInstance.ClassName);
        }

        private void GetSetName(Grades instance, string value)
        {
            instance = new Grades(value);
        }




        [Fact]
        public void CanChangeValueOfTheReference()
        {
            Grades instance = new Grades("Hello There");
            SetClassName(instance, "Why?");

            Assert.Equal("Why?", instance.ClassName);
        }

        private void SetClassName(Grades instance, string newName)
        {
            instance.ClassName = newName;
        }

        [Fact]
        public void TwoVarsCanRefferenceSameObject()
        {
            var first = new Grades("XII A");
            var second = first;
            ChangeGradeName(second, "h");


            Assert.Equal("h", first.ClassName);
        }

        private void ChangeGradeName(Grades instance, string name)
        {
            instance.ClassName = name;
        }


        [Fact]
        public void StringsAreAReferenceButBehaveLikeValueTypes()
        {
            string value = "Hello";
            string capValue = ToUpperCase(value);

            //Assert.Equal("HELLO", value);//This will return false because string acts like a value type
            Assert.Equal("HELLO", capValue);
        }

        private string ToUpperCase(string value)
        {
           return value.ToUpper();//this creates a copy of the string in all caps
        }
    }
}
