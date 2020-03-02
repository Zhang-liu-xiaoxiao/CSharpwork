using System;

namespace Week3Work1
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
        Rectangle() { }
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
                Console.WriteLine($"the area of the shape is {this.height * this.width}");
            else
                Console.WriteLine("it's not a legal shape");
        }
    }
    public class Square : Shape
    {
        public int edge { get; set; }
        public bool isShapeLegal { get; set; }
        public Square() { }
        public Square(int edge)
        {
            this.edge = edge;
            this.isShapeLegal = (this.edge > 0);
        }
        public override void getArea()
        {
            if(isShapeLegal)
                Console.WriteLine($"the area of the square is {this.edge*this.edge}");
            else
                Console.WriteLine("it's not legal");
        }

        public override void isLegal()
        {
            if(!this.isShapeLegal)
                Console.WriteLine("it's not a legal shape");
        }
    }
    class Triangle : Shape
    {
        public int edge1 { get; set; }
        public int edge2 { get; set; }
        public int edge3 { get; set; }
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
            }
            else
                Console.WriteLine("it's not legal");
        }

        public override void isLegal()
        {
            if (!isShapeLegal)
                Console.WriteLine("it's not a legal shape");
        }
        static void Main(string[] args)
        {

            Rectangle rec1 = new Rectangle(1, 2);
            Rectangle rec2 = new Rectangle(0, 1);
            rec1.getArea();
            rec2.getArea();

            Square sq1 = new Square(3);
            Square sq2 = new Square(-1);
            Triangle tra1 = new Triangle(1, 1, 3);
            Triangle tra2 = new Triangle(4, 5, 3);
            sq1.getArea();
            sq2.getArea();
            tra1.getArea();
            tra2.getArea();
        }
    }

}
