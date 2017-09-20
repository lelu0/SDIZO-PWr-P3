using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    static class UI
    {
        public static void printMenu(int mode)
        {
            switch (mode)
            {
                case 0:
                    Console.WriteLine(" >>>SDIZO P3 - KAMIL PACZOS 218377<<<");
                    Console.WriteLine("1. Knapsack problem 0/1");
                    Console.WriteLine("2. Traveling salesman problem (TSP)");
                    break;
                case 1:
                    Console.WriteLine(">>Knapsack problem 0/1<<");
                    Console.WriteLine("1. Greedy Value");
                    Console.WriteLine("2. Greedy Ratio");
                    Console.WriteLine("3. Bruteforce");
                    Console.WriteLine("4. Dynamic programming");
                    Console.WriteLine("5. Load backpack");
                    Console.WriteLine("6. Generate backpack");
                    Console.WriteLine("7. Print backpack");
                    break;
                case 2:
                    Console.WriteLine(">>Traveling salesman problem (TSP)<<");
                    Console.WriteLine("1. Greedy");
                    Console.WriteLine("2. Bruteforce");
                    Console.WriteLine("3. 2-opt");
                    Console.WriteLine("4. Generate World Map");
                    Console.WriteLine("5. Load World Map");
                    Console.WriteLine("6. Print World Map");

                    break;
            }
        }
    }
}
