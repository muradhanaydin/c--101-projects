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
            /* ODEV 2
            Console.Write("Kullanici adi: ");
            string kadi = Console.ReadLine();
            Console.Write("Sifre: ");
            string sifre = Console.ReadLine();
            if(kadi == "admin" && sifre == "root"){
                Console.WriteLine("Hosgeldiniz...");
            }else{
                Console.WriteLine("Sifre yada Kullanici Adi Hatali!");
            }
            */
            /* Odev 3
            Console.Write("Yuzde Giriniz: ");
            float rate = float.Parse(Console.ReadLine());
            Console.Write("Oranlanmis Sayiyi Giriniz: ");
            int ratedNumber = Int16.Parse(Console.ReadLine());

            double number = (ratedNumber*100)/rate; 
            Console.WriteLine($"Sayi: {number:F2}");
            */
            /*Odev 4
            int toplam = 0 , sayi = toplam;
            bool stat = true;
            try{
                do{
                    sayi = Int16.Parse(Console.ReadLine());
                    if(sayi == -1){
                        stat = false;
                    }else{
                        toplam += sayi;
                    }
                }while(stat);
            }catch(FormatException ex){
                Console.WriteLine(ex.Message.ToString());
            }
            catch(ArgumentException ex){
                Console.WriteLine(ex.Message.ToString());
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message.ToString());
            }
            Console.WriteLine($"Girilen Sayilarin Toplami: {toplam}");
            */
            
            int a = Int16.Parse(Console.ReadLine());
            if(a%2 == 0){
                Console.Write(true);
            }else{
                Console.Write(false);
            }
            
        }
          
    }
}