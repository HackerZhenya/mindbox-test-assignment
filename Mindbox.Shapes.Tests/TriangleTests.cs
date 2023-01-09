using System;
using Mindbox.Shapes.Basics;
using NUnit.Framework;

namespace Mindbox.Shapes.Tests;

public class TriangleTests
{
    [TestCase(1, 2, 3)]
    [TestCase(1, 11, 12)]
    public void InstantiateTriangle_WhenInvalid_ThrowsError(double a, double b, double c)
    {
        // ReSharper disable once ObjectCreationAsStatement
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c), "Invalid triangle");
    }

    [TestCase(3, 6, 7, 8.94)]
    [TestCase(4, 6, 8, 11.61)]
    [TestCase(8, 11, 13, 43.817)]
    public void CalculateArea_WhenValid_Ok(double a, double b, double c, double expectedArea)
    {
        var triangle = new Triangle(a, b, c);
        Assert.AreEqual(expectedArea, triangle.Area, triangle.Tolerance);
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 12, 13)]
    [TestCase(8, 15, 17)]
    [TestCase(7, 24, 25)]
    [TestCase(20, 21, 29)]
    [TestCase(12, 35, 37)]
    [TestCase(9, 40, 41)]
    [TestCase(28, 45, 53)]
    [TestCase(11, 60, 61)]
    [TestCase(16, 63, 65)]
    [TestCase(33, 56, 65)]
    [TestCase(48, 55, 73)]
    [TestCase(13, 84, 85)]
    [TestCase(36, 77, 85)]
    [TestCase(39, 80, 89)]
    [TestCase(65, 72, 97)]
    public void CalculateIsRight_WhenRight_Ok(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.IsTrue(triangle.IsRight);
    }

    [TestCase(2, 3, 4)]
    [TestCase(3, 6, 7)]
    [TestCase(4, 6, 8)]
    public void CalculateIsRight_WhenNotRight_Ok(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.IsFalse(triangle.IsRight);
    }
}