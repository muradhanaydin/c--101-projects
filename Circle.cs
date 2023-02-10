using BarcodeLib;
using System.Drawing;
using IronBarCode;

namespace c__101_proj

{
    internal class BarcodeGenerator{
        public static void Main(){
            double radius;
            double thickness = 0.1;
            char symbol = '*';
            do
            {
                Console.Write("Yaricap girini: ");
                if (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0)
                {
                Console.WriteLine("radius have to be positive number");
                }
            }
            while (radius <= 0);
            Console.WriteLine();
            double rIn =radius- thickness, rOut = radius + thickness;
            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                double value = x * x + y * y;
                if (value >= rIn * rIn && value <= rOut * rOut)
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
                }
                Console.WriteLine();
            }
        }
    }
}