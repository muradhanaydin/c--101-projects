using BarcodeLib;
using System.Drawing;
using IronBarCode;

namespace c__101_proj

{
    internal class BarcodeGenerator{
        static string path = @Environment.CurrentDirectory;
        public static void Main(){
            while(true){
                Console.WriteLine("YAPMAK ISTEDIGINIZ ISLEMI SECINIZ!\n\n(1) Barkod olustur\n(2) Barkod oku\n(3) Sistemden Cik");
                if(int.TryParse(Console.ReadLine() , out int selection)){
                    if(selection == 1){
                        EncodeBarcode();
                    }else if(selection == 2){
                        DecodeBarcode();
                    }else if(selection == 3){
                        Environment.Exit(0);
                    }else{
                        Console.WriteLine("X Gecersiz islem girdiniz!\n");
                    }
                }else{
                    Console.WriteLine("X Gecersiz islem girdiniz!\n");
                }
            }
        }
        static void EncodeBarcode(){
            try{
                Console.Write("Numerik Barkod Metnini Giriniz : ");
                string barcodeText = Console.ReadLine();
                Barcode barcode = new Barcode();
                Image img = barcode.Encode(TYPE.CODE128, barcodeText);
                string path = Directory.GetCurrentDirectory() + @$"\{barcodeText}.jpg";
                barcode.SaveImage(path, BarcodeLib.SaveTypes.PNG);
                Console.WriteLine($"Barkod basariyla olusturuldu! {path} yoluna kaydedildi.");
                return;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return;
            }
        }
        static void DecodeBarcode(){
            try{
                string path = $"{Directory.GetCurrentDirectory()}\\";
                while(true){
                    Console.Write("Barkod dosyasinin ismini giriniz: ");
                    string filename = Console.ReadLine();
                    if(File.Exists(path+filename)){
                        path += filename;
                        break;
                    }else{
                        Console.WriteLine("Dosya Bulunamadi!");
                    }
                }
                var result = BarcodeReader.Read(@path);
                Console.WriteLine(result.ToString());
                return;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}