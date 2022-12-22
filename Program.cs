using System;

namespace conosole1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ODEV 1
                float purchasePrice , totalPrice , rate;
                Console.Write("Alis fiyati giriniz: ");
                purchasePrice = float.Parse(Console.ReadLine());
                Console.Write("Kar orani giriniz (%): ");
                rate = float.Parse(Console.ReadLine()); 
                totalPrice = purchasePrice +(purchasePrice* rate / 100);
                Console.WriteLine($"Satis Fiyatiniz : {totalPrice}TL");
            */

            Console.Write("Kullanici adi: ");
            string kadi = Console.ReadLine();
            Console.Write("Sifre: ");
            string sifre = Console.ReadLine();
            if(kadi == "admin" && sifre == "root"){
                Console.WriteLine("Hosgeldiniz...");
            }else{
                Console.WriteLine("Sifre yada Kullanici Adi Hatali!");
            }
        }
    }
}