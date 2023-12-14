namespace InterfacesLab;

public class MyComplex : IMyNumber<MyComplex>
{
    public double Real { get; }
    public double Imaginary { get; }

    public MyComplex(double re, double im)
    {
        Real = re;
        Imaginary = im;
    }

    public MyComplex Add(MyComplex b) => new(Real + b.Real, Imaginary + b.Imaginary);

    public MyComplex Subtract(MyComplex b) => new(Real - b.Real, Imaginary - b.Imaginary);

    public MyComplex Multiply(MyComplex b)
    {
        return new MyComplex(Real * b.Real - Imaginary * b.Imaginary, 
            Real * b.Imaginary + Imaginary * b.Real);
    }

    public MyComplex Divide(MyComplex b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        if (denominator == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return new MyComplex((Real * b.Real + Imaginary * b.Imaginary) / denominator,
            (Imaginary * b.Real - Real * b.Imaginary) / denominator);
    }

    public override bool Equals(object? obj)
    {
        if (obj is MyComplex that) return Real == that.Real && Imaginary == that.Imaginary;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imaginary);
    }

    public override string ToString() => $"{Real} + {Imaginary}i";
}