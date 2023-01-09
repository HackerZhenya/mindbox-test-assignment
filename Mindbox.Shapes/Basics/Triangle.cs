namespace Mindbox.Shapes.Basics;

public record struct Triangle : IShape
{
    public double Tolerance { get; set; } = .01;

    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;

        if (!IsValid)
        {
            throw new ArgumentException("Invalid triangle");
        }
    }

    private bool IsValid => A + B > C &&
                            A + C > B &&
                            B + C > A;

    public bool IsRight
    {
        get
        {
            var array = new[] { A, B, C };
            Array.Sort(array);

            var sa = array[0] * array[0];
            var sb = array[1] * array[1];
            var sc = array[2] * array[2];

            return Math.Abs(sa + sb - sc) < Tolerance;
        }
    }

    public double Perimeter => A + B + C;

    public double Area
    {
        get
        {
            var sp = Perimeter / 2;
            return Math.Sqrt(sp * (sp - A) * (sp - B) * (sp - C));
        }
    }

    public void Deconstruct(out double a, out double b, out double c)
    {
        a = A;
        b = B;
        c = C;
    }
}