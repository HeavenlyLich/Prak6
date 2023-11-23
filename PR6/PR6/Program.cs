
public class Figure<T>
{
    public T Side { get; set; }

    public Figure()
    {
        Side = default(T);
    }

    public Figure(T side)
    {
        Side = side;
    }

    public Figure(Figure<T> other)
    {
        Side = other.Side;
    }

    public virtual double Area()
    {
        throw new NotImplementedException("Метод площа не реалізовано в базовому класі.");
    }

    public virtual double Perimeter()
    {
        throw new NotImplementedException("Метод периметр не реалізовано в базовому класі.");
    }

    public virtual bool Compare(Figure<T> other)
    {
        return Side.Equals(other.Side);
    }
}

public class Square<T> : Figure<T>
{
    public Square() : base() { }

    public Square(T side) : base(side) { }

    public Square(Square<T> other) : base(other) { }

    public override double Area()
    {
        dynamic sideValue = Side;
        return sideValue * sideValue;
    }

    public override double Perimeter()
    {
        dynamic sideValue = Side;
        return 4 * sideValue;
    }
    public static Square<T> operator +(Square<T> a, Square<T> b)
    {
        dynamic sideA = a.Side;
        dynamic sideB = b.Side;
        return new Square<T>(sideA + sideB);
    }

    public static Square<T> operator -(Square<T> a, Square<T> b)
    {
        dynamic sideA = a.Side;
        dynamic sideB = b.Side;
        return new Square<T>(sideA - sideB);
    }

    public static Square<T> operator *(Square<T> a, int b)
    {
        dynamic sideA = a.Side;
        return new Square<T>(sideA * b);
    }
}

public class Cube<T> : Square<T>
{
    public Cube() : base() { }

    public Cube(T side) : base(side) { }

    public Cube(Cube<T> other) : base(other) { }

    public double Volume()
    {
        dynamic sideValue = Side;
        return sideValue * sideValue * sideValue;
    }

    public override double Area()
    {
        dynamic sideValue = Side;
        return 6 * sideValue * sideValue;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Тестування класів
        Square<int> square1 = new Square<int>(10);
        Square<int> square2 = new Square<int>(5);
        Cube<int> cube = new Cube<int>(3);

        Console.WriteLine("Довжина: першого квадрата - 10; другого - 5; куба - 3.");
        Console.WriteLine("Площа квадрата 1: " + square1.Area());
        Console.WriteLine("Периметр квадрата 1: " + square1.Perimeter());
        Console.WriteLine("Порівняння квадратів на рівність : " + square1.Compare(square2));

        square1 = square1 + square2;
        Console.WriteLine("Додавання довжин сторін квадратів: " + square1.Side);

        square1 = square1 - square2;
        Console.WriteLine("Віднімання довжин сторін квадратів: " + square1.Side);

        square1 = square1 * 2;
        Console.WriteLine("Множення сторони квадрата на число(2): " + square1.Side);

        Console.WriteLine("Площа поверхні куба: " + cube.Area());
        Console.WriteLine("Об'єм куба: " + cube.Volume());
    }
}