using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            string[] words = Console.ReadLine().Split(" ");
            PrintWordsBackwords(words);
        }
        public static void PrintWordsBackwords(string[] words){
            foreach(string word in words){
                Console.Write($"{string.Concat(word.ToCharArray().Reverse())} ");
            }
        }
        
    }
}