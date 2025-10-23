using System;

public interface IComparable<T>
{
    int CompareTo(T other);
}

public struct ComplexNumber : IComparable<ComplexNumber>
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public int CompareTo(ComplexNumber other)
    {
        double magnitude1 = Math.Sqrt(Real * Real + Imaginary * Imaginary);
        double magnitude2 = Math.Sqrt(other.Real * other.Real + other.Imaginary * other.Imaginary);

        return magnitude1.CompareTo(magnitude2);
    }
}

public struct RationalNumber : IComparable<RationalNumber>
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public double Value => (double)Numerator / Denominator;

    public int CompareTo(RationalNumber other)
    {
        return Value.CompareTo(other.Value);
    }
}

class Program
{
    static void Main()
    {
        var complex1 = new ComplexNumber(3, 4);
        var complex2 = new ComplexNumber(1, 2);
        complex1.CompareTo(complex2);

        var rational1 = new RationalNumber(1, 2);
        var rational2 = new RationalNumber(3, 4);
        rational1.CompareTo(rational2);

        Console.WriteLine("Comparison test completed");
    }
}