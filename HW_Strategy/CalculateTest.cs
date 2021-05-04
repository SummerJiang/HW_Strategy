using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace HW_Strategy
{
    [TestFixture]
    class CalculateTest
    {
        private readonly Calculate calculate = new Calculate();

        private IShape[] Rhombus { get;  set; }

        [Test]
        public void Square_with_Side()
        {
            Square square = new Square(5);
            double TotalArea = calculate.GetTotalArea(square);
            TotalAreaShouldBe(25, TotalArea);
        }
        [Test]
        public void Square_with_NegativeSide()
        {
            Square square = new Square(-5);
            Action getTotalArea = () => calculate.GetTotalArea(square);
            getTotalArea.Should().Throw<ArgumentException>().WithMessage("Side >0");
        }

        [Test]
        public void Rectangle_with__lenght_width()
        {
            Rectangle rectangle = new Rectangle(10, 5);
            double TotalArea = calculate.GetTotalArea(rectangle);
            TotalAreaShouldBe(50, TotalArea);
        }
        [Test]
        public void Rectangle_with_Negativelenght_width()
        {
            Rectangle rectangle = new Rectangle(-10, -5);
            Action getTotalArea = () => calculate.GetTotalArea(rectangle);
            getTotalArea.Should().Throw<ArgumentException>().WithMessage("Lenght or Width >0");
        }


        [Test]
        public void Circle_with_radius()
        {
            Circle circle = new Circle(5);
            double TotalArea = calculate.GetTotalArea(circle);
            TotalAreaShouldBe(15.7, TotalArea);
        }

        [Test]
        public void Circle_with_Negativeradius()
        {
            Circle circle = new Circle(-5);
            Action getTotalArea = () => calculate.GetTotalArea(circle);
            getTotalArea.Should().Throw<ArgumentException>().WithMessage("Radius >0");
        }
        [Test]
        public void Triangl_with_Base_Height()
        {
            Triangle triangle = new Triangle(2, 5);
            double TotalArea = calculate.GetTotalArea(triangle);
            TotalAreaShouldBe(5, TotalArea);
        }
        [Test]
        public void Triangl_with_Negative_Base_Height()
        {
            Triangle triangle = new Triangle(-2, -5);
            Action getTotalArea = () => calculate.GetTotalArea(triangle);
            getTotalArea.Should().Throw<ArgumentException>().WithMessage("Tbase or Theight > 0");
        }

        [Test]
        public void AllShape_TotalArea()
        {
            Square square = new Square(5);
            Rectangle rectangle = new Rectangle(10, 5);
            Circle circle = new Circle(5);
            Triangle triangle = new Triangle(2, 5);

            double TotalArea = calculate.GetTotalArea(square, rectangle, circle, triangle);
            TotalAreaShouldBe(95.7, TotalArea);
        }
        [Test]
        public void Shape_not_exist()
        {
            Action getTotalArea = () => calculate.GetTotalArea(Rhombus);
            getTotalArea.Should().Throw<ArgumentException>().WithMessage("Shape not exist");

        }

      
        private void TotalAreaShouldBe(double expected, double totalArea)
        {
            Assert.AreEqual(expected, totalArea);
        }
    }
}
