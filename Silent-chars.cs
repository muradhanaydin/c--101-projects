using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
           List<string> inp = Console.ReadLine().Split(" ").ToList<string>();
           string vowels = "aeıioöuüAEIİOÖUÜ";
           foreach(string text in inp){
                bool stat = false;
                for(int i=0; i<text.Length-1; i++){
                        if(vowels.IndexOf(text[i]) == -1 && vowels.IndexOf(text[i+1]) == -1){
                            stat = true;
                            break;
                        }
                }
                Console.Write($"{stat} ");
           }
        }
    }
}