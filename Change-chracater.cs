using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
           List<string> inp = Console.ReadLine().Split(" ").ToList<string>();
           foreach(string text in inp){
                if(text.Length != 1)
                    Console.Write($"{text[text.Length-1] + text.Substring(1,text.Length-2) + text[0] } ");
                else
                    Console.Write($"{text} ");
           }
        }        
    }
}