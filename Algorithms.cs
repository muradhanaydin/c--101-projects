using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            string[] text = Console.ReadLine().Split(" ");
            Console.WriteLine(text.Length);
            algorithms(text);
        }
        public static void algorithms(string[] arr){
            for(int i=0; i<arr.Length; i++){
                string[] tx = arr[i].Split(",");
                int idx = int.Parse(tx[1]);
                if(idx > tx[0].Length){
                    Console.Write(tx[0]+" ");
                }else{
                    Console.Write($"{tx[0].Remove(idx , 1)} ");
                }
            }
        }
    }
}