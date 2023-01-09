using System;
using Mindbox.Shapes.Basics;
using NUnit.Framework;

namespace Mindbox.Shapes.Tests;

public class CircleTests
{
    [TestCase(1, Math.PI)]
    [TestCase(3, 28.27)]
    [TestCase(7, 153.93)]
    [TestCase(14, 615.75)]
    public void CalculateArea(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        Assert.AreEqual(expectedArea, circle.Area, .01d);
    }
}