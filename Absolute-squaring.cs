using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
           List<string> arr = Console.ReadLine().Split(" ").ToList<string>();
           int minTotal = 0  , maxTotal = 0 , limit = 67;
           for(int i=0; i<arr.Count; i++){
                int number = int.Parse(arr[i]);
                if(number < limit){
                    minTotal += limit - number;
                }else{
                    maxTotal += Convert.ToInt16(Math.Pow(Math.Abs(limit - number),2));
                }
           }
           Console.WriteLine($"{minTotal} {maxTotal}");
        }        
    }
}