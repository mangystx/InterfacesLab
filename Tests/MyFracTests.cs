using System.Numerics;
using Xunit;

namespace InterfacesLab.Tests;

public class MyFracTests
{
    [Fact]
    public void TestAddition()
    {
        MyFrac a = new (1, 3);
        MyFrac b = new MyFrac(1, 6);
        MyFrac result = a.Add(b);

        Assert.Equal(new MyFrac(1, 2), result);
        result = result.Multiply(result);
        Assert.Equal(new MyFrac(1, 4), result);
    }
    
    [Fact]
    public void TestSubtract()
    {
        MyFrac a = new (1, 3);
        MyFrac b = new MyFrac(1, 6);
        MyFrac result = a.Divide(b);

        Assert.Equal(new MyFrac(2, 1), result);
    }
    
    [Fact]
    public void TestSquare()
    {
        MyFrac a = new (1, 3);
        MyFrac b = new MyFrac(1, 6);
        MyFrac result = a.Add(b);
        result = result.Multiply(result);
        Assert.Equal(new MyFrac(1, 4), result);
        Assert.Equal(new MyFrac(1, 9), a.Multiply(a));
        Assert.Equal(new MyFrac(1, 36), b.Multiply(b));
        result = a.Multiply(a).Add(new MyFrac(2, 1).Multiply(a).Multiply(b)).Add(b.Multiply(b));
        Assert.Equal(new MyFrac(1, 4), result);
    }

    [Fact]
    public void TestMultiply()
    {
        MyFrac a = new (1, 3);
        MyFrac b = new(1, 6);
        MyFrac result = new MyFrac(2, 1).Multiply(a).Multiply(b);
        Assert.Equal(new MyFrac(1, 9), result);
    }

    [Fact]
    public void TestDivide()
    {
        MyFrac a = new (1, 3);
        MyFrac b = new(1, 6);
        MyFrac result = a.Divide(b);
        Assert.Equal(new MyFrac(6, 3), result);
        MyFrac c = new(0, 5);
        Assert.Throws<DivideByZeroException>(() => a.Divide(c));
    }
    
    [Fact]
    public void TestMyFracArraySorting()
    {
        MyFrac[] fractions = {
            new(3, 2),
            new(1, 4),
            new(5, 8),
            new(7, 3),
            new(2, 1)
        };
    
        Array.Sort(fractions);
    
        for (int i = 1; i < fractions.Length; i++)
        {
            Assert.True(fractions[i - 1].CompareTo(fractions[i]) <= 0,
                $"Array is not sorted. {fractions[i - 1]} should be less than or equal to {fractions[i]}");
        }
    }

    [Fact]
    public void MyTest()
    {
        BigInteger a = 1;
        for (int i = 1; i <= 100; i++)
        {
            a *= i;
        }
        
        BigInteger b = 1;
        for (int i = 100; i >= 1; i--)
        {
            b *= i;
        }
        
        Assert.Equal(a, b);
    }
}