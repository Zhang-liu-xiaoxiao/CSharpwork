using System;

namespace Week3Work2
{
    public abstract class Shape
    {
        public abstract void getArea();
        public abstract void isLegal();
    }

    public class Rectangle : Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public bool isShapeLegal { get; set; }
        public double area { get; set; }
        public Rectangle() { }
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.isShapeLegal = (this.width > 0 && this.height > 0);
        }
        public override void isLegal()
        {
            if (!this.isShapeLegal)
                Console.WriteLine("it's not a legal shape");
        }
        public override void getArea()
        {
            if (this.isShapeLegal)
            {
                Console.WriteLine($"the area of the shape is {this.height * this.width}");
                this.area = this.height * this.width;
            }
            else
                Console.WriteLine("it's not a legal shape");
        }
    }
    public class Square : Shape
    {
        public int edge { get; set; }
        public bool isShapeLegal { get; set; }
        public double area { get; set; }
        public Square() { }
        public Square(int edge)
        {
            this.edge = edge;
            this.isShapeLegal = (this.edge > 0);
        }
        public override void getArea()
        {
            if (isShapeLegal)
            {
                Console.WriteLine($"the area of the square is {this.edge * this.edge}");
                this.area = this.edge * this.edge;
            }
            else
                Console.WriteLine("it's not legal");
        }

        public override void isLegal()
        {
            if (!this.isShapeLegal)
                Console.WriteLine("it's not a legal shape");
        }
    }
    class Triangle : Shape
    {
        public int edge1 { get; set; }
        public int edge2 { get; set; }
        public int edge3 { get; set; }
        public double area { get; set; }
        public bool isShapeLegal { get; set; }
        public Triangle() { }
        public Triangle(int edge1, int edge2, int edge3)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
            this.edge3 = edge3;

            this.isShapeLegal = (edge1 > 0 && edge2 > 0 && edge3 > 0)
                && (edge1 + edge2 > edge3) && (edge1 + edge3 > edge2) && (edge2 + edge3 > edge1);
        }
        public override void getArea()
        {
            if (isShapeLegal)
            {
                double p = (edge1 + edge2 + edge3) / 2;
                Console.WriteLine($"the area is {Math.Sqrt(p * (p - edge1) * (p - edge2) * (p - edge3))} ");
                this.area = Math.Sqrt(p * (p - edge1) * (p - edge2) * (p - edge3));
            }
            else
                Console.WriteLine("it's not legal");
        }

        public override void isLegal()
        {
            if (!isShapeLegal)
                Console.WriteLine("it's not a legal shape");
        }

    }

    class ShapeFactory
    {
        public ShapeFactory() { }
        public static Shape createShape()
        {
            int rad1,rad2,rad3,rad4;
            Random random = new Random();
            rad1 = random.Next(1, 3);
            rad2 = random.Next(1, 10);
            rad3 = random.Next(1, 10);
            rad4 = random.Next(1, 10);
            Shape returnedShape = new Rectangle();
            switch (rad1)
            {
                case 1:
                    returnedShape = new Rectangle(rad2, rad3);
                    break;
                case 2:
                    returnedShape = new Square(rad2);
                    break;
                case 3:
                    returnedShape = new Triangle(rad2, rad3, rad4);
                    break;
                default:
                    break;
            }
            return returnedShape;
        }
        static void Main(string[] args)
        {
            Shape shape1 = ShapeFactory.createShape();
            Shape shape2 = ShapeFactory.createShape();
            Shape shape3 = ShapeFactory.createShape();
            Shape shape4 = ShapeFactory.createShape();
            Shape shape5 = ShapeFactory.createShape();
            Shape shape6 = ShapeFactory.createShape();
            Shape shape7 = ShapeFactory.createShape();
            Shape shape8 = ShapeFactory.createShape();
            Shape shape9 = ShapeFactory.createShape();
            Shape shape10 = ShapeFactory.createShape();
            shape1.getArea();
            shape2.getArea();
            shape3.getArea();
            shape4.getArea();
            shape5.getArea();
            shape6.getArea();
            shape7.getArea();
            shape8.getArea();
            shape9.getArea();
            shape10.getArea();

        }
    }

}
