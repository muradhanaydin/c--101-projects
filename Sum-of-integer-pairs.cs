using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
           List<string> arr = Console.ReadLine().Split(" ").ToList<string>();
           for(int i=0; i<arr.Count; i+=2){
                if(arr[i] == arr[i+1]){
                    Console.Write($"{Math.Pow((int.Parse(arr[i]) + int.Parse(arr[i+1])),2)}");
                    continue;
                }
                Console.Write($"{(int.Parse(arr[i]) + int.Parse(arr[i+1]))}");
           }
        }        
    }
}