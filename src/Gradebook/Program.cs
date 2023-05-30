// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, Tunde!");

using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            //    var p = new Program();
            //    Program.Main(args);

            //New instance of a class called book, create Book class in another file
            //var book = new Book();
            //need to include the type in the list, initialise grades too with new
            //List<double> grades = new List<double>;
            // New instance of a class called book, create Book class
            
            //var book = new InMemoryBook("Scott's Gradebook");
            IBook book = new DiskBook("Scott's Gradebook");
            book.GradeAdded += OnGradeAdded;
            // book.GradeAdded += OnGradeAdded; //subscribe and unsubscribe multiple times to an event
            // book.GradeAdded -= OnGradeAdded;
            // book.GradeAdded += OnGradeAdded;


            // book.AddGrade(89.1);
            // book.AddGrade(74.7);

            // var done = false;
            // while(!done)
            EnterGrade(book);

            var stats = book.GetStatistics();

            //book.Name = ""; //this calls the setter to write a value into the property

            // Console.WriteLine($"{name} Total is: {result:N1}");  //N1 is for 1decimal place
            //Console.WriteLine($"Category: {Book.CATEGORY}");
            //Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Average is: {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");

            // var grades = new List<double>() {12.7, 10.4, 3.2, 54.8 };
            // grades.Add(56.1);  //method - pass parameter
            // // grades.Add(5.4);  //method - pass parameter

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("A grade was added");
            }

            // int i = 0;
            // while (i < 5) 
            // {
            //     Console.WriteLine(i);
            //     i++;
            // }
            // for (int i = 0; i <= 10; i = i + 2) 
            // {
            //   Console.WriteLine(i);
            // }

            // if(args.Length > 0)
            // {
            //     Console.WriteLine($"Hello, {args[0]}!");
            // }
            // else
            // {
            //     Console.WriteLine("Hello!");
            // }
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    // book.AddGrade('A');
                }
                catch (ArgumentException ex)
                // catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

                // if (double.TryParse(input, out double grade))

                // var grade = double.Parse(input);
                // book.AddGrade(grade);
                //dotnet run --project src/Gradebook/Gradebook.csproj
            }
        }
    }
}