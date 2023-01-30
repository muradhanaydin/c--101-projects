using System;

namespace c__101_proj{
    internal class Program{
        public static void Main(){
            int size = int.Parse(Console.ReadLine());
            PrintTriangle(size);
        }

        public static void PrintTriangle(int s){
            for(int i=0; i<s; i++){
                for(int j=i; j<s; j++){
                    Console.Write(" ");
                }
                for(int c=0; c<i; c++){
                    Console.Write("· ");
                }
                Console.WriteLine("");
            }
        }

        
    }
}