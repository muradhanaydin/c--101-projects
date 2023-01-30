using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            Console.WriteLine("İslem yapmak istediginiz sekili secin:\n\n(1) Kare\n(2) Ucgen\n(3) Dikdortgen\n(4) Daire\n\n(5) Cikis");
            
            int inp = int.Parse(Console.ReadLine());
            switch(inp){
                case 1:{
                    Kare();
                    break;
                }
                case 2:{
                    Ucgen();
                    break;
                }
                case 3:{
                    Dikdortgen();
                    break;
                }
                case 4:{
                    Daire();
                    break;
                }
                case 5:{
                    Environment.Exit(0);
                    break;
                }
            }
        }
        public static void Kare(){
            Console.Write("Kenar uzunlugunu girin: ");
            double kenar = double.Parse(Console.ReadLine());
            Console.Write("Yukseklik girin: ");
            double yukseklik = double.Parse(Console.ReadLine());
            Square rc = new Square(kenar, yukseklik);
            ProcessSelection(rc);
        }
        public static void Ucgen(){
            Console.Write("Taban uzunlugunu girin: ");
            double taban = double.Parse(Console.ReadLine());
            Console.Write("Sol kenar uzunlugunu girin: ");
            double solkenar = double.Parse(Console.ReadLine());
            Console.Write("Sag Kenar uzunlugunu girin: ");
            double sagkenar = double.Parse(Console.ReadLine());
            Console.Write("Yukseklik girin: ");
            double yukseklik = double.Parse(Console.ReadLine());
            Triangle rc = new Triangle(taban , solkenar , sagkenar , yukseklik);
            ProcessSelection(rc);
        }
        public static void Dikdortgen(){
            Console.Write("Uzun kenari girin: ");
            double uzunkenar = double.Parse(Console.ReadLine());
            Console.Write("Kisa kenar girin: ");
            double kisakenar = double.Parse(Console.ReadLine());
            Console.Write("Yukseklik girin: ");
            double yukseklik = double.Parse(Console.ReadLine());
            Rectangle rc = new Rectangle(uzunkenar , kisakenar , yukseklik);
            ProcessSelection(rc);
        }
        public static void Daire(){
            Console.Write("Yaricapi girin: ");
            double r = double.Parse(Console.ReadLine());
            Console.Write("Yukseklik girin: ");
            double yukseklik = double.Parse(Console.ReadLine());
            Circle cr = new Circle(r, yukseklik);
            ProcessSelection(cr);
        }

        public static void ProcessSelection(Shape o){
            Console.Clear();
            Console.WriteLine($"Yapmak istediginiz islemi seciniz:\n(1) Cevre\n(2) Alan\n(3) Hacim\n(4) Ana Menu");
            int selection = int.Parse(Console.ReadLine());
            switch(selection){
                case 1:{
                    Console.Write(o.Perimeter());
                    break;
                }
                case 2:{
                    Console.Write(o.Area());
                    break;
                }
                case 3:{
                    Console.Write(o.Volume());
                    break;
                }
            }
        }

        public class Rectangle:Shape{
            public Rectangle(double x , double y , double h=0){
                this.X = x;
                this.Y = y;
                this.H = h;
            }
            public override double Area()
            {
                return (this.X * this.Y);
            }
            public override double Volume()
            {
                return (this.X * this.Y * this.H);
            }
            public override double Perimeter()
            {
                return ((this.X + this.Y) * 2);
            }
        }
        public class Square:Shape{
            public Square(double x , double h = 0){
                this.X = x;
                this.H = h;
            }
            public override double Area()
            {
                return (Math.Pow(this.X , 2));
            }
            public override double Perimeter()
            {
                return (this.X * 4);
            }
            public override double Volume()
            {
                return (Math.Pow(this.X , 3));
            }
        }
        public class Triangle:Shape{
            private double z;
            public double Z { get => this.z; set => this.z = value;}
            public Triangle(double x , double y , double z , double h){
                this.X = x;
                this.Y = y;
                this.Z = z;
                this.H = H;
            }
            public override double Area()
            {
                return ((this.X * this.H)/2);
            }
            public override double Volume()
            {
                return (0.5 * this.X * this.H);
            }
            public override double Perimeter()
            {
                return (this.X  + this.Y + this.Z);
            }
        }

        public class Circle:Shape{
            double r ;
            public double R { get=> this.r; set => this.r = value;}
            public Circle(double r , double h = 0){
                this.R = r;
                this.H = h;
            }
            public override double Area()
            {
                return (Math.PI * Math.Pow(this.R , 2));
            }
            public override double Volume()
            {
                return (Math.PI* Math.Pow(this.R , 2)*this.H);
            }
            public override double Perimeter()
            {
                return (Math.PI * 2 * this.R);
            }
        }

        public abstract class Shape{
            protected double x ,y ,h;
            public double X { get=> this.x; set=> this.x = value;}
            public double Y { get=> this.y; set=> this.y = value;} 
            public double H { get=> this.h; set=> this.h = value;}
            public abstract double Perimeter();
            public abstract double Area();
            public abstract double Volume();
        }     
    }
}