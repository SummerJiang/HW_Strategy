using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Strategy
{
    class Calculate
    {
        public double GetTotalArea(params IShape[] shapes)
        {
            if (shapes == null)
                throw new ArgumentException("Shape not exist");
            else
                return Math.Round(shapes.Sum(s => s.GetTotalArea()), 2);
        }

    }
    public interface IShape
    {
        double GetTotalArea();
    }
    public class Square : IShape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            this.Side = side;
        }
        public double GetTotalArea()
        {
            if (this.Side < 0)
                throw new ArgumentException("Side >0");
            return this.Side * this.Side;
        }
    }
    public class Rectangle : IShape
    {
        public double Lenght { get; set; }
        public double Width { get; set; }

        public Rectangle(double lenght, double width)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public double GetTotalArea()
        {
            if (this.Lenght < 0 || this.Width < 0)
                throw new ArgumentException("Lenght or Width >0");
            return this.Lenght * this.Width;
        }
    }
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double GetTotalArea()
        {
            if (this.Radius < 0 )
                throw new ArgumentException("Radius >0");
            return 3.14 * this.Radius;
        }
    }

    public class Triangle : IShape
    {
        public double Tbase { get; set; }
        public double Theight { get; set; }
        public Triangle(double tbase, double theight)
        {
            this.Tbase = tbase;
            this.Theight = theight;
        }

        public double GetTotalArea()
        {
            if (this.Tbase < 0 || this.Theight < 0)
                throw new ArgumentException("Tbase or Theight > 0");
            return (this.Tbase * this.Theight) / 2;
        }
    }

}
