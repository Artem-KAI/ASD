namespace lvl3.Models;

class Square
{
    public double X { get; }
    public double Y { get; }
    public double Side { get; }

    public Square(double x, double y, double side)
    {
        X = x;
        Y = y;
        Side = Math.Abs(side);
    }
 
    public double Perimeter()
    {
        return 4 * Side;
    }

 
    public double Area()
    {
        return Side * Side;
    }

    public override string ToString()
    {
        return $"Square [X:{X:F1}, Y:{Y:F1}, Side:{Side:F2}, Area: {Area():F2}, Perimeter: {Perimeter():F2}]";
    }
}