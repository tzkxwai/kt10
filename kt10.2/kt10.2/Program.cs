using System;

public interface IClonable<T>
{
    T Clone();
}

public class Point : IClonable<Point>
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Point(Point other)
    {
        X = other.X;
        Y = other.Y;
    }

    public Point Clone()
    {
        return new Point(this);
    }
}

public class Rectangle : IClonable<Rectangle>
{
    public Point TopLeft { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(Point topLeft, double width, double height)
    {
        TopLeft = topLeft;
        Width = width;
        Height = height;
    }

    public Rectangle(Rectangle other)
    {
        TopLeft = other.TopLeft.Clone();
        Width = other.Width;
        Height = other.Height;
    }

    public Rectangle Clone()
    {
        return new Rectangle(this);
    }
}

public static class Cloner
{
    public static T CloneObject<T>(T obj) where T : IClonable<T>
    {
        return obj.Clone();
    }
}

class Program
{
    static void Main()
    {
        var point = new Point(3, 4);
        var clonedPoint = Cloner.CloneObject(point);

        var rect = new Rectangle(new Point(1, 1), 10, 5);
        var clonedRect = Cloner.CloneObject(rect);

        Console.WriteLine("Cloning test completed");
    }
}