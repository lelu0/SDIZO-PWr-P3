using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    static class _Shared
    {
        //backpack shared functions
        static public int getListSize(List<Item> list)
        {
            if (list == null)
                return 0;
            int weight = 0;
            foreach (var i in list)
            {
                weight += i.size;
            }
            return weight;
        }
        static public int getListValue(List<Item> list)
        {
            if (list == null)
                return 0;
            int value = 0;
            foreach (var i in list)
            {
                value += i.value;
            }
            return value;
        }
        static public void printItemList(List<Item> list)
        {
            if (list == null)
                Console.WriteLine("No items found");
            foreach (var i in list)
            {
                Console.WriteLine("Size: " + i.size + ", Value: " + i.value + ", Ratio: " + i.valueToSizeRatio);
            }

        }
        static public List<Item> generateItems(int capacity, int itemsN = 0)
        {
            Random rn = new Random();
            List<Item> items = new List<Item>();
            if (itemsN == 0)
                while (getListSize(items) <= capacity * 1.3)
                {
                    items.Add(new Item(rn.Next(1, 30), rn.Next(1, 40)));
                }
            else
            {
                for (int i = 0; i < itemsN; i++)
                    items.Add(new Item(rn.Next(1, 30), rn.Next(1, 40)));
                if (getListSize(items) < capacity * 1.3)
                    items[itemsN - 1] = new Item(rn.Next(1, 30),(int)( capacity * 1.3 - getListSize(items)));
            }
           // Console.WriteLine("Items generated");

            return items;
        }

        static public int routeCost(List<int> route, int[,] matrix)
        {
            int cost = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                cost += matrix[route[i], route[i + 1]];

            }
            return cost;
        }
    }
}
