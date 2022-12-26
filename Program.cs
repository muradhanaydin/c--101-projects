using System;

namespace conosole1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ODEV 1 [Degiskenler]
                float purchasePrice , totalPrice , rate;
                Console.Write("Alis fiyati giriniz: ");
                purchasePrice = float.Parse(Console.ReadLine());
                Console.Write("Kar orani giriniz (%): ");
                rate = float.Parse(Console.ReadLine()); 
                totalPrice = purchasePrice +(purchasePrice* rate / 100);
                Console.WriteLine($"Satis Fiyatiniz : {totalPrice}TL");
            */
            /* ODEV 2 [Operatorler]
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
            /* Odev 3 [Tip Donusumleri]
            Console.Write("Yuzde Giriniz: ");
            float rate = float.Parse(Console.ReadLine());
            Console.Write("Oranlanmis Sayiyi Giriniz: ");
            int ratedNumber = Int16.Parse(Console.ReadLine());

            double number = (ratedNumber*100)/rate; 
            Console.WriteLine($"Sayi: {number:F2}");
            */
            /*Odev 4 [Hata Yonetimi]
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
             /* Odev 5 [Karar Yapilari]
            int a = Int16.Parse(Console.ReadLine());
            if(a%2 == 0){
                Console.Write(true);
            }else{
                Console.Write(false);
            }
            */
            /* Odev 6 [Kara Yapilari]
            int s1 , s2;
            char op;
            Console.Write("1. Sayiyi giriniz: ");
            s1= Int16.Parse(Console.ReadLine());
            Console.Write("2. Sayiyi giriniz: ");
            s2= Int16.Parse(Console.ReadLine());
            Console.Write("Islem tipini giriniz: ");
            op= Char.Parse(Console.ReadLine());

            switch(op){
                case '+':
                    Console.WriteLine("Sonuc: " + (s1+s2));
                    break;
                case '-':
                    Console.WriteLine("Sonuc: " + (s1-s2));
                    break;
                case '*':
                    Console.WriteLine("Sonuc: " + (s1*s2));
                    break;
                case '/':
                    Console.WriteLine("Sonuc: " + (s1/s2));
                    break;
                case '^':
                    Console.WriteLine("Sonuc: " + Math.Pow(s1,s2));
                    break;
                default:
                    Console.WriteLine("GECERSIZ ISTEM TIPI GIRDINIZ! [+,-,*,/,^]");
                    break;
            }
            */
            /*Odev 7 [Donguler]
            int n = Int16.Parse(Console.ReadLine());
            for(int i=1; i<11; i++){
                Console.WriteLine($"{n} x {i} = {n*i}");
            }
            */
            /*Odev 8 [Donguler]
            int total = 0,i;
            while(true){
                i = Int16.Parse(Console.ReadLine());
                if(i == -1){
                    break;
                }else{
                    if(i%2==0){
                        total += i;
                    }else{
                        continue;
                    }
                }
            }
            Console.WriteLine($"Girilen Cift Sayilarin Toplami: {total}");
            */
            /*Odev 9 [Array]
            int[] sayilar = {1,5,4,8,7};
            int toplam  =0;
            foreach(int sayi in sayilar){
                toplam +=sayi;
            }
            Console.WriteLine(toplam);
            */
            /*Odev 10[Array]
            int[] arr = new int[5];
            for(int i=0; i<arr.Length; i++){
                arr[i] = Int16.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            Console.WriteLine($"Son eleman ile ilk eleman farki: {arr[arr.Length-1] - arr[0]}");
            */
            /* Odev 11[Metodlar]
            Program prg = new Program();
            Console.Write("Hesaplanacak Sayi: ");
            int sayi = Int16.Parse(Console.ReadLine());
            prg.ekranaYaz(prg.faktoriyel(sayi).ToString());
            */

            string sayiText = "999";
            bool sonuc = int.TryParse(sayiText , out int sayi);
            if(sonuc){
                Console.WriteLine($"Islem Basarili!\n{sayi}");
            }else{
                Console.WriteLine("Islem Basarisiz!");
            }

            Islemler islemler = new Islemler();
            islemler.Topla(4,5,out int toplam);
            Console.WriteLine($"Toplam: {toplam}");

            islemler.Topla(4,5,6,out int toplamOl);
            Console.WriteLine($"ToplamOl: {toplamOl}");

            int ikincisayi = 123;
            islemler.ekranaYaz(ikincisayi.ToString());




        }   
        /* 
        public int faktoriyel(int f){
            int fak = 1;
            for(int i=1;i<=f;i++){
                fak *= i;
            }
            return fak;
        }
        public void ekranaYaz(string text){
            Console.WriteLine(text);
        }*/
    }
    class Islemler{
        public void Topla(int a , int b , out int toplam){
            toplam = a+b;
        }
        public void Topla(int a , int b ,int c, out int toplam){
            toplam = a+b+c;
        }
        public void ekranaYaz(string text){
            Console.WriteLine(text);
        }
    }
}