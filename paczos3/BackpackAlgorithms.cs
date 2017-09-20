using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    static class BackpackAlgorithms
    {
        public static List<Item> greedyValue(List<Item> items = null, int capacity = 100)
        {
            //Bubble sort algorithm 
            bool changeFlag = true;
            while (changeFlag)
            {
                changeFlag = false;
                for (int i = 0; i < items.Count() - 1; i++)
                {
                    //swap elements 
                    if (items.ElementAt(i).value < items.ElementAt(i + 1).value)
                    {
                        Item tmp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = tmp;
                        changeFlag = true;
                    }
                }
            }

            //end of bubble sorting
            //Adding items till backpack is not full
            List<Item> itemsInBackpack = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                if (_Shared.getListSize(itemsInBackpack) + items[i].size <= capacity)
                {
                    itemsInBackpack.Add(items[i]);
                }
                else
                {
                    continue;
                }
            }
            return itemsInBackpack;
        }

        //Implementation based on value and size ratio
        public static List<Item> greedyRatio(List<Item> items = null, int capacity = 100)
        {
            //Bubble sort algorithm 
            bool changeFlag = true;
            while (changeFlag)
            {
                changeFlag = false;
                for (int i = 0; i < items.Count() - 1; i++)
                {
                    //swap elements 
                    if (items.ElementAt(i).valueToSizeRatio <= items.ElementAt(i + 1).valueToSizeRatio)
                    {
                        Item tmp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = tmp;
                        changeFlag = true;
                    }
                }
            }

            //end of bubble sorting
            //Adding items till backpack is not full
            List<Item> itemsInBackpack = new List<Item>();
            for (int i = 0;i < items.Count ; i++)
            {
                if (_Shared.getListSize(itemsInBackpack) + items[i].size <= capacity)
                {
                    itemsInBackpack.Add(items[i]);
                }
                else
                {
                    continue;
                }
            }
            return itemsInBackpack;
        }

        public static List<Item> bruteforceValue(List<Item> items = null, int capacity = 100)
        {
            int maxValue = 0; //Current best value
            List<Item> bestSet = new List<Item>(); //List for best set of items in backpack
            int subsetsNumber = (int)Math.Pow(2, items.Count); // because max combination number of n-element set is 2^n
            //check if is passed valid set of items
            if (items == null)
                return bestSet;
            //iterating by every posible subset
            for (int i = 0; i < subsetsNumber; i++)
            {
                List<Item> subset = new List<Item>();
                uint mask = 0; //bitmask 
                while (mask < items.Count) //iterating and checking if element is in HIGH state in bitmask, then include in subset
                {
                    if ((i & (1u << (int)mask)) > 0)
                    {
                        subset.Add(items[(int)mask]);
                    }
                    mask++;
                }
                int tv = _Shared.getListValue(subset); //temp variable for subset summary value, because it may be used again
                if (tv > maxValue && _Shared.getListSize(subset) <= capacity) // Checking if better set hasn't been discovered yet and current could be packet to backpack [|^|]
                {
                    maxValue = _Shared.getListValue(subset);
                    bestSet = subset;
                }
            }
            return bestSet;
        }

        public static List<Item> dynamic(List<Item> items = null, int capacity = 100)
        {
            int[,] tableP = new int[items.Count, capacity + 1]; //table for items value available for capacity

            //putting 0 for every cell of every table
            for (int i = 0; i < items.Count; i++)
                for (int j = 0; j <= capacity; j++)
                {
                    tableP[i, j] = 0;
                }

            //process first row of table
            for (int j = 0; j <= capacity; j++)
            {
                if (items[0].size <= j)
                {
                    tableP[0, j] = items[0].value;
                }
            }
            //process other rows of table
            //from 1, because item 0 was calculated upper
            for (int i = 1; i < items.Count; i++)//2
            {
                for (int j = 0; j <= capacity; j++)//3
                {
                    //4 
                    //excluded if  && tableP[i - 1, j] < tableP[i, j - items[i].size] + items[i].value
                    if (j >= items[i].size)
                    {
                        //writting value and index to table if is possible to pack item on this capacity
                        tableP[i, j] = Math.Max(tableP[i - 1, j], tableP[i - 1, j - items[i].size] + items[i].value);
                    }
                    else
                    {
                        //rewritte value from previous row
                        tableP[i, j] = tableP[i - 1, j];
                    }
                }
            }
            //debug: print matrix
            for (int i = 1; i < items.Count; i++)//2
            {
                for (int j = 0; j < capacity; j++)//3
                {

                }
            }
            //getting answer
            List<Item> itemsSet = new List<Item>();
            int ia = items.Count - 1; // item counter, row
            int ja = capacity; //ia, ja - i answer, j answer, capacity counter, column
            //going bottom->up, right->left on matrix
            while (true)
            {
                if (ia < 0)
                    break;
                if (tableP[ia, ja] == 0)
                    break;
                if (ia - 1 >= 0)
                    if (tableP[ia, ja] == tableP[ia - 1, ja]) //if vale not came from current row continue and don't keep item
                    {
                        ia--;
                        continue;
                    }
                //keep this item
                itemsSet.Add(items[ia]);
                //go up and right /-\ \-/ /-/ ...
                ja = ja - items[ia].size;
                ia--;

            }
            return itemsSet;
        }
    }
}
