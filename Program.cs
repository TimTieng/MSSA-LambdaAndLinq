/*
Class: ISTA 421 - Developing Cloud Applications
Student: Tim Tieng
Instructor: Elliot Robinson
Date: 05 October 2020
Description: HW 4A C# - Lambdas and Linq
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace TimTiengHW_LambdasAndLinq
{
    static class Utilities
    {
        public static IEnumerable<TReturn> Map<T, TReturn>(this IEnumerable<T> values, Func<T, TReturn> func)
        {
            foreach (var v in values)
                yield return func(v);
        }

        public static TReturn Fold<T, TReturn>(this IEnumerable<T> values, TReturn startingValue, Func<TReturn, T, TReturn> func)
        {
            TReturn accum = startingValue;

            foreach (var v in values)
            {
                accum = func(accum, v);
            }
            return accum;
        }
    }
    class Program
    {
        static void AddOneToEachValueInIntArray(int[] array)//Part of Linq task 1
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += 1;
            }
        }
        private delegate double IntToIntMethod(double value);//Part of Linq Task 1 

        static int AddOne(int i) => i + 1;//Part of Linq Task 1

        static string AddString(string a, string b)//part of task 5
        {
            return a + b;
        }
        static int Sum(int x, int y) //Part of Task 4 
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            //Task 1- Using a FUNC, write an expression which takes no parameters and evaluates to the string "Hello, World".
            Func<string, string> greeting = x =>"Hello World";
            Console.WriteLine(greeting("")); //Used similar code presented to classmate "Rod" in class when asking instrutor for help
            Console.ReadLine();

            //Task 2 - Using a FUNC , write an expression which returns an integer, takes a single integer parameter, 
            //and adds the integer 1 to it.
            Func<int, int> task2Answer = x => x + 1;//used exact code snippet provided by classmate florabel ituralde when discusssing in a group setting
            Console.WriteLine($"The value entered plus 1 = {task2Answer(4)}");
            Console.ReadLine();

            //Task 3 - Using a FUNC, write n expression which returns an integer, takes two integer parameters, 
            //and raises the first parameter to the power of the second.
            Func<double, double> task3Answer = x => Math.Pow(x, 2);
            Console.WriteLine($"The value entered raised to the 2nd Power = {task3Answer(3)}");
            Console.ReadLine();

            //Task 4 - write an expression which returns an integer, takes two integer parameters and sums them.
            Func<int, int, int> Add = Sum;
            int SumOfValues = Add(20, 50);
            Console.WriteLine($"The sum of the provided values is: {SumOfValues}");
            Console.ReadLine();

            //Task 5 - write an expression which returns a string, takes two strings, and appends the first to the second.
            Func<string, string, string> StringAdd = AddString;
            string CombinedStrings = StringAdd("Great Scott, Marty! ", "We traveled back to 1985!");
            Console.WriteLine(CombinedStrings);
            Console.ReadLine();

            /*LINQ Tasks----------INTENTIONAL LINE BREAK---------------------------*/

            Console.WriteLine("Linq tasks depicted below :");
            Console.ReadLine();

            //Ling Pre-Task 1 - Declare a list of sequential integers with a method from the Enumerable class
            Console.WriteLine("Printing out a list of sequential integers utilizing a method from the Enumerable class:");
            IEnumerable<int> OrderedNumbers = Enumerable.Range(1,5);//Second number is the  limit
            foreach (var number in OrderedNumbers)
            {
                Console.Write("{0} ", number);
            }
            Console.ReadLine();

            //Ling Pre-Task 2 - Declare a list of dummy strings.
            List<string> DummyStrings = new List<string> { "You", "Are", "Getting", "Better", "At", "Programming" , "Just", "Keep", "Practicing", "Everyday"};
            Console.WriteLine("Declare a list of dummy strings -- Print them to verify");
            List<string> ChineseProverb = new List<string> { "Fall", "Down", "Seven", "Times,", "Stand", "Up", "Eight" };
            //foreach (var sentenceComponent in DummyStrings)
            //{
            //    Console.Write("{0} ", sentenceComponent);
            //}
            foreach (var word in ChineseProverb)
            {
                Console.Write("{0} ", word);
            }
            Console.ReadLine();
            //Linq Task 1 - Use #2 to add one to a list of integers individually. Add 1 to each value in the list
            var valuesArray = Enumerable.Range(1, 5).ToArray();
            Console.WriteLine("Print array to see values before being added by 1: ");
            foreach (var item in valuesArray)
            {
                Console.Write("{0} ", item);
            }
            Console.ReadLine();
            Console.WriteLine("This adds 1 to every pre-existing value in an array:");
            AddOneToEachValueInIntArray(valuesArray);
            foreach (var item in valuesArray)
            {
                Console.Write("{0} ", item);
            }
            Console.ReadLine();
            //Linq Task 2 - Use #3 to raise a list of integers to the second power individually.
            List<int> valuesToBeSquared = new List<int> { 1, 2, 3, 4, 5 };
           
            foreach (var item in valuesToBeSquared)
            {
                Func<int, int, int> squaredFunction = (valuesToBeSquared, exponent) => (int)Math.Pow(valuesToBeSquared, 2); //Cast required
                Console.Write("{squaredFunction(item, 2)}, ");
                Console.ReadLine();
            }
            //Linq Task 3 - Use #4 to sum a list of integers.
            List<int> ListSum = new List<int> { 1, 2, 3, 4, 5 };
            int total = ListSum.Sum();
            Console.WriteLine($"The total of the list is: {total}");
            Console.ReadLine();
            //Linq task 4 - Use number 5 to concantenate string
            Func<string, string, string> dummyStringsConcatenated = (DummyStrings, ChineseProverb) => AddString(DummyStrings, ChineseProverb);
            Console.WriteLine(dummyStringsConcatenated);
            Console.ReadLine();
            //Linq Task 5 - use #3 and a method from the Enumerable class in a new lambda expression which returns
            //an integer, takes two integers, 
        }
    }
}
/*
Function Delegate Syntax
public delegate TResult Func<in T, out TResult>(T arg);

https://www.tutorialsteacher.com/csharp/csharp-func-delegate

Lambda Syntax 
A lambda expression is a convenient way of defining an anonymous (unnamed) function 
that can be passed around as a variable or as a parameter to a method call. Many LINQ methods take a function (called a delegate) as a parameter. 
Here is an example of what a lambda expression looks like:

Func<int, int> multiplyByFive = num => num * 5;
// Returns 35
int result = multiplyByFive(7);

https://www.tutorialsteacher.com/linq/linq-lambda-expression
*/