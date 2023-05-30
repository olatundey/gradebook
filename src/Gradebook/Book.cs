namespace GradeBook
{
    //object is the base type
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    //public delegate void GradeAddedDelegate(double grade);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
        
    }
    public class DiskBook : Book
    {
        
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt")) // wrap using Using so it can dispose after
            //var writer = File.AppendText($"{Name}.txt"); //opens a file for logging
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            //writer.Dispose();
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt")) // OPENTEXT to open the file that has the correct name
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        // public override string? ToString()
        // {
        //     return base.ToString();
        // }
    }

    //change to inmemory book using rename symbol
    public class InMemoryBook : Book //IBook //adding the interface, 0 or more interface can be specified
    {
        
        private List<double> grades;


        // public string Name
        // {
        //     get; 
            
        //     set;

            // {
            //     return name;
            // }
            // set 
            // {
            //     name = value;
            // }
        //}

        // readonly string category = "Science"; //only initiative/change Constructor
        public const string CATEGORY = "Science"; //constant

        public override event GradeAddedDelegate? GradeAdded;
        //By making the event nullable ?, you indicate that it can have a null value, 
        //which is necessary in this case when exiting the constructor.

        public InMemoryBook(string name) : base(name) //use name instead of ""
        {
            //category = "";
            //const int X = 3;
            grades = new List<double>();
            Name = name;
        }
 
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(80);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }


    public override void AddGrade(double grade)

    {
        if (grade <= 100 && grade >= 0)
        {
            grades.Add(grade);
            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}");
            //Console.WriteLine("Invalid value");
        }
        // var book = new Book();
    }


    public override Statistics GetStatistics()
    {
        // if (grades.Count == 0)
        // {
        //     Console.WriteLine("No grades entered.");
        //     return;
        // }
        //initialise
        var result = new Statistics();
        

        //var result = 0.0;
        //var highGrade = double.MinValue; //to ensure that any subsequent value we compare it to will be greater.
        //var lowestGrade = double.MaxValue; // which represents the largest possible value for a double type in .NET.
        //By initializing highGrade with the smallest possible value for a double (double.MinValue), we guarantee that any grade we encounter in the program will be higher than highGrade. 
        //As we process grades, we can compare them with the initial value of highGrade and update it if we find a higher grade.
        //var avg = 0.0;

        //var index = 0;
        //do
        //or
        //while(index < grades.Count)

        // in for expres -var initialise, condition, iter
        //for (var index = 0; index < grades.Count; index += 1)

        //foreach preferable

        // loop can use, foreach statement
        foreach(var grade in grades)
        {
            result.Add(grade);
            // result.Average += grade;
            // result.High = Math.Max(grade, result.High);
            // result.Low = Math.Min(grade, result.Low);
            // result.Average += grades[index];
            // result.High = Math.Max(grades[index], result.High);
            // result.Low = Math.Min(grades[index], result.Low);
            // index++;
            // if(number > highGrade)
            // {
            //     highGrade = number
            // }
        }
        //while(index < grades.Count);
        //avg = result/gr ades.Count;
        //result.Average /= grades.Count;
        
        //PATTERN MATCHING WITH SWITCH
        // switch(result.Average)
        // {
        //     case var d when d >= 90.0:
        //         result.Letter = 'A';
        //         break;
            
        //     case var d when d >= 80.0:
        //         result.Letter = 'B';
        //         break;
        //     case var d when d >= 70.0:
        //         result.Letter = 'C';
        //         break;
        //     case var d when d >= 60.0:
        //         result.Letter = 'D';
        //         break;
        //     default:
        //         result.Letter = 'F';
        //         break;
        // }


        return result;

    }
}
}