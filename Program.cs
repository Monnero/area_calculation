using System;

namespace ConsoleApp2
{
    class Figure
    {
        public double semiPerimeter;
        public double? square;
        public virtual void Print(double? radius = null, params double[] side) { }
    }
    class Triangle : Figure
    {
        public double[] side = new double[3];

        public void Input()
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Введите сторону треугольника");
                side[i] = Convert.ToDouble(Console.ReadLine());
            }
        }

        public override void Print(double? radius, double[] side)
        {
            double sideSum = 0;
            for (int i = 0; i < side.Length; i++)
                sideSum += side[i];
            semiPerimeter = sideSum / 2;
            square = Math.Sqrt(sideSum * (sideSum - side[0]) * (sideSum - side[1]) * (sideSum - side[2]));
            
            Console.WriteLine($"Площадь треугольника: {square}");
        }
        public void Rectangular(double[] side)
        {
            if ((side[0] * side[0] + side[1] * side[1] == side[2] * side[2]) || (side[0] * side[0] + side[2] * side[2] == side[1] * side[1]) || (side[2] * side[2] + side[1] * side[1] == side[0] * side[0]))
                Console.WriteLine("Треугольник является прямоугольным");
            else
                Console.WriteLine("Треугольник не является прямоугольным");

        }
    }
    class Circle : Figure
    {
        public double radius;

        public void Input()
        {
            Console.WriteLine("Введите радиус");
            radius = Convert.ToDouble(Console.ReadLine());
        }

        public override void Print(double? radius, double[] side)
        {
            square = Math.PI * radius * radius;
            Console.WriteLine($"Площадь круга: {square}" );
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            triangle.Input();
            triangle.Print(null, triangle.side);
            Circle circle = new Circle();
            circle.Input();
            circle.Print(circle.radius);
            triangle.Rectangular(triangle.side);
            Console.ReadLine();
        }
    }
}
