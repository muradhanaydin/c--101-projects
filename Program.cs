using System;
using System.Collections;
using System.Collections.Generic;   

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
            /*Odev 12 [Metodlar]
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
            */

            /*
            //Recursive Function
            int result = 1;
            for(int i=1; i<5; i++){
                result *= 3;
            }
            Console.WriteLine(result);
            Islemler islemler = new();
            islemler.ekranaYaz(islemler.Expo(3,5).ToString());

            //Extension Metodlar
            string ifade = "Ne Mutlu Turkum Diyene!";
            bool sonuc = ifade.CheckSpaces();
            islemler.ekranaYaz(sonuc.ToString());

            islemler.ekranaYaz(ifade.MakeLowerCase());
            islemler.ekranaYaz(ifade.MakeUpperCase());


            islemler.ekranaYaz(ifade.ReplaceWhiteSpaceToMoonStar());

            int s = 5;
            islemler.ekranaYaz(s.IsEvenNumber().ToString());
            */


            /*
            //GENERIC COLLECTION ve LIST
            //List<type> [objectName] = new List<type>();

            List<int> numbers = new List<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);
            numbers.Add(50);

            List<string> words = new List<string>();
            words.Add("Hello");
            words.Add("World!");
            words.Add("This");
            words.Add("Is");
            words.Add("My");
            words.Add("First");
            words.Add("Code");

            //List kolleksiyon tipindeki bir arrayin eleman sayisi(dizi sayisini) getirme
            Console.WriteLine($"numbers[{numbers.Count}]");
            Console.WriteLine($"numbers[{words.Count}]");

            //Foreach ile kolleksiyon verilerini ekrana yazma yada uzerinde islem yapma 
            foreach(var num in numbers){
                Console.WriteLine($"{num} ");
            }
            foreach(var word in words){
                Console.WriteLine($"{word} ");
            }

            //Diger bir sekilde foreach metodunu kullanma 
            numbers.ForEach(num => {
                Console.WriteLine($"{num} ");
            });
            words.ForEach(word => {
                Console.WriteLine($"{word} ");
            });

            //Listeden Eleman Cikarma Yada Silme
            numbers.Remove(10); //direk silmek istedigimiz degerler verilir
            words.RemoveAt(4); //verdigimiz index numarasindaki elemani siler
            numbers.ForEach(num => {
                Console.WriteLine($"{num} ");
            });
            words.ForEach(word => {
                Console.WriteLine($"{word} ");
            });

            //List icerisinde eleman arama 
            if(words.Contains("Hello")){
                Console.WriteLine("----- ELEMAN BULUNDU -----");
            }

            //List icerisinde bulanan veririn index numarasini bulma
            Console.WriteLine(words.BinarySearch("Code"));

            //Bir diziyi []  List tipine cevirme
            string[] turkishWords = {"Merhaba", "Dunya!" , "Bu" , "Benim" , "Ilk" , "Kodum"};
            List<string> turkishWords2 = new List<string>(turkishWords);
            turkishWords2.ForEach(word => {
                Console.WriteLine($"{word}");
            });
            
            //List icindeki elemanlari temizleme 
            numbers.Clear();

            //List icerisinde class nesnesi tutmak
            User user1 = new User();
            User user2 = new User();
            List<User> users = new List<User>();

            user1.Name = "Ahmet";
            user1.Surname = "Uludiyar";
            user1.Age = 34;

            users.Add(user1);

            users.Add(new User(){ //Diger sekilde sinif uyesini List kolleksiyonuna ekleme
                Name = "Mahmut",
                Surname = "Boz",
                Age = 23
            });

            users.ForEach(user=>{
                Console.WriteLine($"User -> Name: {user.Name}   Surname: {user.Surname}   Age: {user.Age}");
            });
            */


            /*
            //ArrayList Kullanimi

            ArrayList liste = new ArrayList();
            liste.Add("Bu bir metindir.");
            liste.Add(10);
            liste.Add(true);
            liste.Add('a');

            //Icersindeki verilere erisim => <arrayIsmi>[index]
            Console.WriteLine(liste[3]);

            //Liste elemanlarini yazdiriyoruz
            foreach(var item in liste){
                Console.WriteLine($"{item}");
            }

            //AddRange ile liste icine birden fazla veri ekleme
            List<int> sayilar = new List<int>(){10,20,30,40,50,60,70};
            liste.AddRange(sayilar);
            Console.WriteLine("------ AddRange Sonrasi ------");
            foreach(var item in liste){
                Console.WriteLine($"{item}");
            }
            //Sort metodunu kullanirken sadece int tipindeki verileri siralama yapar. Aksi takdirde runtime hatasi verir fakat kod blogunda hata uyarisi vermez.
            */

            /*

            //Dictionary Kullanili => Key , value mantigi ile calisir ayni ingilizce turkce sozluk gibi. Olustururken hem key in hemde value nun tipini ayri ayri belirtiriz.
            //Dictionary<key-type,value-type> <name> = new Dictionary<key-type,value-type>(); seklinde olusturulur.

            Dictionary<int,string> kullanicilar = new Dictionary<int,string>();
            kullanicilar.Add(1021 , "Mert");
            kullanicilar.Add(1022 , "Ayse");
            kullanicilar.Add(1023 , "Fatma");
            kullanicilar.Add(1024 , "Hayriye");

            //Dizinin elemanlarina erisim
            Console.WriteLine("------ Elemanlara Erisim -----");
            Console.WriteLine(kullanicilar[1023]);
            foreach(var item in kullanicilar){
                Console.WriteLine(item);
            }

            //Count kullanimi
            Console.WriteLine($"------ Count -------\n{kullanicilar.Count}");

            //Contains kullanimi
            Console.WriteLine($"------ Contains -------\n{kullanicilar.ContainsKey(1021)}\n{kullanicilar.ContainsValue("Mert")}");

            //Remove kullanimi
            Console.WriteLine($"------ Remove -------\n{kullanicilar.Remove(1023)}");
            foreach (var item in kullanicilar){
                Console.WriteLine(item);
            }
            
            //Keys kullanimi
            Console.WriteLine($"------ Keys -------");
            foreach(var keys in kullanicilar.Keys){
                Console.WriteLine(keys);
            }

            //Value kullanimi
            Console.WriteLine($"------ Keys -------");
            foreach(var value in kullanicilar.Values){
                Console.WriteLine(value);
            }
            */

            //CLASS ODEV 1 (Constructor)

            // Employee calisan1 = new Employee();
            // calisan1.Name = "Ahmet";
            // calisan1.Surname = "Bar";
            // calisan1.Department = "Insan Kaynaklari";
            // calisan1.No = 123;
            // calisan1.PringtEmployeeData();

            // Employee calisan2 = new Employee("Fatma" , "Caliskan" , 12 , "Mudur");
            // calisan2.PringtEmployeeData();

            // Employee calisan3 = new Employee("Fatih" , "Kalan");
            // calisan3.PringtEmployeeData();

            //CLASS ODEV 2 (Encapsulation)

            // Student std1 = new Student("Ahmet" , "Birinci" , 4 , 321245);
            // Student std2 = new Student("Filiz" , "Kapici" , 7 , 456157);
            // std1.PrintStudentData();
            // std2.PrintStudentData();
            // std1.ClassDown();
            // std2.ClassUp();
            // std1.PrintStudentData();
            // std2.PrintStudentData();     

            //CLASS ODEV 3 (STATIC)    

            // Console.WriteLine($"Isci Sayisi : {EmployeeStatic.Count}");
            // EmployeeStatic emp1 = new EmployeeStatic("Ayse" , "Boyaci" , 234 , "Software Tester");
            // EmployeeStatic emp2 = new EmployeeStatic("Faruk" , "Yerebasan");
            // EmployeeStatic emp3 = new EmployeeStatic();
            // Console.WriteLine($"Isci Sayisi : {EmployeeStatic.Count}");

            //ClASS ODEV 4 (STRUCT)

            Triangular ucgen1 = new Triangular(4,5);
            Console.WriteLine($"1.Ucgen Alani : {ucgen1.CalculateAreaOfTriangular():F2}");
            Triangular ucgen2;
            ucgen2.baseWeight = 5;
            ucgen2.height = 15;
            Console.WriteLine($"1.Ucgen Alani : {ucgen2.CalculateAreaOfTriangular():F2}");

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

    struct Triangular{
        public float baseWeight;
        public float height;

        public Triangular(float bw , float h){ 
            //Kurucu metodu. Fakat yeni struct olustururken new <struct-name>(); seklinde kullanilmalidir. Atama yapilmadigindan dolayi diger metodlar hata verir.
            this.baseWeight = bw;
            this.height = h;
        }

        public float CalculateAreaOfTriangular(){
            return this.baseWeight * height /2;
        }
    }
    class EmployeeStatic{
        public static int Count;
        public string Name;
        public string Surname;
        public string Department;
        public int No;

        public EmployeeStatic(string name , string surname , int no , string department){
            this.Name = name;
            this.Surname = surname;
            this.No = no;
            this.Department = department;
            Count += 1;
        }

        public EmployeeStatic(string name , string surname){
            this.Name = name;
            this.Surname = surname;
            Count +=1;
        }

        public EmployeeStatic(){
            Count +=1;
        }

        public void PringtEmployeeData(){
            Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nDepartmant: {Department}\nNo: {No}\n");
        }
    }


    class Student{
        private string name;
        private string surname;
        private int classNumber;
        private int number;

        public string Name {get=>name; set=>name=value;}
        public string Surname {get=>surname; set=>surname=value;}
        public int Number {get=>number; set=>number=value;}
        public int ClassNumber {get=>classNumber; set=>classNumber = value<1?1:value;}
        public Student(string name , string surname , int classnumber , int number){
            Name = name;
            Surname = surname;
            Number = number;
            ClassNumber = classnumber;
        }
        public Student(){}
        public void ClassDown(){
            ClassNumber -= 1;
        }
        public void ClassUp(){
            ClassNumber += 1;
        }
        public void PrintStudentData(){
            Console.WriteLine($"---STUDENT INFO---\nName          : {Name}\nSurname       : {Surname}\nNumber        : {Number}\nCurrent Class : {ClassNumber}\n");
        }
    }
    class Employee{
        public string Name;
        public string Surname;
        public string Department;
        public int No;

        public Employee(string name , string surname , int no , string department){
            this.Name = name;
            this.Surname = surname;
            this.No = no;
            this.Department = department;
        }

        public Employee(string name , string surname){
            this.Name = name;
            this.Surname = surname;
        }

        public Employee(){}

        public void PringtEmployeeData(){
            Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nDepartmant: {Department}\nNo: {No}\n");
        }
    }
    class User{
        private string name;
        private string surname;
        private int age;

        public string Name { get=>name; set=>name=value; }
        public string Surname { get=>surname; set=>surname=value; }
        public int Age { get=>age; set=>age=value;}
    }
    class Islemler{
        public int Expo(int a, int f){
            if(f == 1){
                return f;
            }else{
                return a*Expo(a , f-1);
            }
        }
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
    public static class Extension{
        public static bool CheckSpaces(this string param){
            return param.Contains(" ");
        }
        public static string ReplaceWhiteSpaceToMoonStar(this string param){
            return string.Join(" c* " , param.Split(" "));
        }
        public static string MakeUpperCase(this string param){
            return param.ToUpper();
        }
        public static string MakeLowerCase(this string param){
            return param.ToLower();
        }
        public static bool IsEvenNumber(this int param){
            return param % 2 == 0;
        }
    }
}