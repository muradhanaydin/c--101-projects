using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            int deep = int.Parse(Console.ReadLine());
            float avg = fibonacciAvg(deep);
            Console.Write($"{avg:F3}");
        }

        public static float fibonacciAvg(int d){
            if(d < 3){
                return 1;
            }
            List<int> fib = new List<int>(){1,1};
            int total = 2 , curr = 0;
            for(int i=2; i<d;i++){
                curr = fib[i-1] + fib[i-2];
                fib.Add(curr);
                total += curr;
            }
            float avg = total /= d;
            return avg;
        }
    }
}