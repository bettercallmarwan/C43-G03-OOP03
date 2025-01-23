using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
#region part 01

#region Q1) Write a class named Calculator that contains a method named Add. Overload the Add method to:

//public class Calculator
//{
//    public static int sum(int a, int b) => a + b;
//    public static int sum(int a, int b, int c) => a + b + c;
//    public static double sum(double a, double b) => a + b;

//}


//namespace Assignment_3
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine(Calculator.sum(1, 2));
//            Console.WriteLine(Calculator.sum(1, 2, 3));
//            Console.WriteLine(Calculator.sum(1.1, 2.6));

//        }
//    }
//}

#endregion

#region Q2) Create a class named Rectangle with the following constructors:

public class Rectangle
{
    private readonly int width;
    private readonly int height;

    public Rectangle() => this.width = this.height = 0;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public Rectangle(int width) => this.width = this.height = width;
}

#endregion

#region Q3) Define a class Complex Number that represents a complex number with real and imaginary parts.


//public class Complex
//{
//    private readonly int real;
//    private readonly int imaginary;

//    public Complex(int real, int imaginary)
//    {
//        this.real = real;
//        this.imaginary = imaginary;
//    }

//    public static Complex operator +(Complex a, Complex b) => new Complex(a.real + b.real, a.imaginary + b.imaginary);

//    public static Complex operator -(Complex a, Complex b) => new Complex(a.real - b.real, a.imaginary - b.imaginary);

//    public override string ToString() => imaginary < 0 ? $"{real} -{-1 * imaginary}i" : $"{real} +{imaginary}i";
//}



//namespace Assignment_3
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Complex c1 = new Complex(3, 5);
//            Complex c2 = new Complex(1, 7);

//            Console.WriteLine(c1 + c2);
//            Console.WriteLine(c1 - c2);
//        }
//    }
//}
#endregion

#region Q4)

#region a) Create a base class named Employee with method That Work as it prints    "Employee is  working".

public class Employee
{
    public virtual void work() => Console.WriteLine("Employee is working");
}

#endregion

#region b) Create a derived class named Manager that overrides the Work method to print "Manager is managing". 

public class Manager : Employee
{
    public override void work()
    {
        base.work();
        Console.WriteLine("Manager is managing");
    }
}

#endregion

#endregion

#region Question 5)

/// <summary>
/// (Override) => This keyword ensures polymorphism, so it overrides the existing method in the base class, allowing us to make a different implementation of it in the child class, and also the base class can use the overriden method.
/// (new)      => This keyword creates a new method in the child class, that is completely different from the method of the same name in the base class.
/// </summary>

#region a) Create a base class BaseClass with a virtual method DisplayMessage that prints  "Message from BaseClass".
public class BaseClass
{
    public virtual void DisplayMessage() => Console.WriteLine("Message from BaseClass");
}
#endregion

#region b) Create a derived class DerivedClass1 that overrides the DisplayMessage method using the override keyword
public class DerivedClass1 : BaseClass
{
    public override void DisplayMessage() => Console.WriteLine("Message from DerivedClass1");
}
#endregion

public class DerivedClass2 : BaseClass
{
    public new void DisplayMessage() => Console.WriteLine("Message from DerivedClass2");
}

#endregion

#endregion

#region part 02


public class Duration
{
    #region 1-Define Class Duration To include Three Attributes Hours, Minutes and Seconds.

    private readonly int hours;
    private readonly int minutes;
    private readonly int seconds;

    
    #endregion

    public override string ToString() => $"{hours}:{minutes}:{seconds}";

    public override bool Equals(object obj) => obj is Duration d && this.hours == d.hours && this.minutes == d.minutes && this.seconds == d.seconds;

    public override int GetHashCode()
    {
        string s = string.Concat(hours, minutes, seconds);
        int ans = Convert.ToInt32(s);
        return ans;
    }

    #region 3-Define All Required Constructors to Produce this output:
    public Duration()
    {
        
    }
    public Duration(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public Duration(int seconds)
    {
        this.hours = seconds / 3600;
        seconds %= 3600;

        this.minutes = seconds / 60;
        seconds %= 60;

        this.seconds = seconds;

    }
    #endregion

    #region 4-Implement All required Operators overloading to enable this Code:

    // Helper function
    private static int toSeconds(Duration a) => a.hours * 3600 + a.minutes * 60 + a.seconds;

    public static Duration operator +(Duration a, Duration b) 
        => new Duration(toSeconds(a) + toSeconds(b));

    public static Duration operator -(Duration a, Duration b)
        => new Duration(toSeconds(a) - toSeconds(b));

    public static Duration operator +(Duration a, int sec)
        => new Duration(toSeconds(a) + sec);

    public static Duration operator ++(Duration a)
        => new Duration(toSeconds(a) + 60);

    public static Duration operator --(Duration a)
        => new Duration(toSeconds(a) - 60);

    public static bool operator >(Duration a, Duration b)
        => toSeconds(a) > toSeconds(b);

    public static bool operator <(Duration a, Duration b)
        => toSeconds(a) < toSeconds(b);

    public static bool operator >=(Duration a, Duration b)
        => toSeconds(a) >= toSeconds(b);

    public static bool operator <=(Duration a, Duration b)
        => toSeconds(a) <= toSeconds(b);

    public static implicit operator bool(Duration a)
        => toSeconds(a) > 0;

    public static explicit operator DateTime(Duration a)
    {
        DateTime now = DateTime.Now;
        return new DateTime(now.Year, now.Month, now.Day, a.hours, a.minutes, a.seconds);
    }

    #endregion
}

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration d1 = new Duration(0, 1, 0);
            Duration d2 = new Duration(1, 0, 3);

            Console.WriteLine(d1.Equals(d2));

            Console.WriteLine(d1.GetHashCode());
            Console.WriteLine(d2.GetHashCode());

            Duration d3 = d1 + d2;
            Console.WriteLine(d3);

            Console.WriteLine(d1 + 3600);
            if (d1)
                Console.WriteLine("hi");

            DateTime dt = (DateTime)d2;
            Console.WriteLine(dt);
        }
    }
}


#endregion