namespace lvl2.Models;

using System;

class Square
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Side { get; private set; }

    public Square(double x, double y, double side)
    {
        X = x;
        Y = y;
        Side = Math.Abs(side);
    }
     
    public double GetPerimeter()
    {
        return 4 * Side;
    }

    public double GetArea()
    {
        return Side* Side;
    }


    public override string ToString()
    {
        return $"Square [X:{X:F1}, Y:{Y:F1}, Side:{Side:F2}, Area: {GetArea():F2}, Perimeter: {GetPerimeter():F2}]";
    }
}