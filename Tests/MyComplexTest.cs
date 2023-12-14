using Xunit;

namespace InterfacesLab.Tests;

public class MyComplexTest
{
    [Fact]
    public void TestAddition()
    {
        var a = new MyComplex(1, 3);
        var b = new MyComplex(1, 6);
        MyComplex result = a.Add(b);

        Assert.Equal(new MyComplex(2, 9), result);
    }

    [Fact]
    public void TestSubtract()
    {
        var a = new MyComplex(1, 3);
        var b = new MyComplex(1, 6);
        MyComplex result = a.Subtract(b);

        Assert.Equal(new MyComplex(0, -3), result);
    }

    [Fact]
    public void TestSquare()
    {
        var a = new MyComplex(1, 3);
        var b = new MyComplex(1, 6);
        MyComplex result = a.Add(b);
        result = result.Multiply(result);

        Assert.Equal(new MyComplex(2, 9), result);
        Assert.Equal(new MyComplex(-8, 6), a.Multiply(a));
        Assert.Equal(new MyComplex(-35, 12), b.Multiply(b));

        result = a.Multiply(a).Add(new MyComplex(2, 0).Multiply(a).Multiply(b)).Add(b.Multiply(b));

        Assert.Equal(new MyComplex(-77, 36), result);
    }

    [Fact]
    public void TestMultiply()
    {
        var a = new MyComplex(1, 3);
        var b = new MyComplex(1, 6);
        MyComplex result = a.Multiply(b);

        Assert.Equal(new MyComplex(-15, 9), result);
    }

    [Fact]
    public void TestDivide()
    {
        var a = new MyComplex(1, 3);
        var b = new MyComplex(1, 6);
        MyComplex result = a.Divide(b);

        Assert.Equal(new MyComplex(0.5, 0), result);

        MyComplex c = new MyComplex(0, 5);

        Assert.Throws<DivideByZeroException>(() => a.Divide(c));
    }
}