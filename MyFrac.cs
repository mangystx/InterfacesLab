using System.Numerics;

namespace InterfacesLab;

public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
{
    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public MyFrac(BigInteger nom, BigInteger denom)
    {
        if (denom == 0) throw new ArgumentException("Denominator cannot be zero.");
        Numerator = nom;
        Denominator = denom;
        BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
        if (Denominator >= 0) return;
        Numerator = -Numerator;
        Denominator = -Denominator;
    }

    public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { }

    public MyFrac Add(MyFrac b)
    {
        return new MyFrac(Numerator * b.Denominator + b.Numerator * Denominator, 
            Denominator * b.Denominator);
    }

    public MyFrac Subtract(MyFrac b)
    {
        return new MyFrac(Numerator * b.Denominator - b.Numerator * Denominator, 
            Denominator * b.Denominator);
    }

    public MyFrac Multiply(MyFrac b)
    {
        return new MyFrac(Numerator * b.Numerator, Denominator * b.Denominator);
    }

    public MyFrac Divide(MyFrac b)
    {
        if (b.Numerator == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return new MyFrac(Numerator * b.Denominator, Denominator * b.Numerator);
    }

    public override string ToString() => $"{Numerator}/{Denominator}";

    public int CompareTo(MyFrac? other)
    {
        BigInteger numerator1 = Numerator * other.Denominator;
        BigInteger numerator2 = other.Numerator * Denominator;

        return numerator1.CompareTo(numerator2);
    }
}