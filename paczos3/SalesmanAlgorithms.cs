using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    static class SalesmanAlgorithms
    {
        public static List<int> greedy(int[,] cityMatrix, int numberOfCities)
        {
            List<int> cityOrder = new List<int>();
            bool[] cityStatus = new bool[numberOfCities]; //flags for all cities, true - visited;
            for (int c = 0; c < numberOfCities; c++) cityStatus[c] = false; // no city is visited
            int startCity = 0;
            cityOrder.Add(0);
            cityStatus[0] = true; //city 0 is already visited
            int currentCity = 0;
            bool comeback = false; //flag if algorithm is done
            while (!comeback)
            {
                int min = int.MaxValue;
                int minIndex = 0;
                for (int i = 0; i < numberOfCities; i++)
                {
                    if (cityMatrix[currentCity, i] < min && i != currentCity && !cityStatus[i])
                    {
                        min = cityMatrix[currentCity, i];
                        minIndex = i;
                    }
                }
                cityOrder.Add(minIndex);
                currentCity = minIndex;
                cityStatus[minIndex] = true;
                if (currentCity == startCity || cityOrder.Count == numberOfCities)
                {
                    cityOrder.Add(0);
                    comeback = true;
                }

            }
            return cityOrder;
        }

        public static List<int> opt(int[,] cityMatrix, int numberOfCities)
        {
            //generating random permutation of city
            List<int> route = new List<int>();
            for (int i = 0; i < numberOfCities; i++) route.Add(i);
            route.Add(0); //adding comeback to home
            Random rn = new Random();
            int permutN = rn.Next(2, numberOfCities - 1);
            for (int i = 1; i < permutN; i++) //from 1, because we must start in 0
            {
                int j = rn.Next(1, numberOfCities-1);
                int tmp = route[j];
                route[j] = route[i];
                route[i] = tmp;
            }
            //debug printing def route
            //Console.WriteLine("def route");
            //foreach(var r in route)
            //{
            //    Console.Write(r);
            //}
            //Console.WriteLine();
            //algorithm body
            int iX = 0;
            while(iX < numberOfCities - 2)
            {
                int b = route[iX]; // i point of route
                int c = route[iX + 1]; // i+1 point of route
                for (int eX = iX+2;eX < numberOfCities-1; eX ++)
                {
                    int e = route[eX]; //i+1...
                    int f = route[eX + 1]; //next from e....
                    if(cityMatrix[b,c] + cityMatrix[e,f] > cityMatrix[b,e] + cityMatrix[c,f]) //check if after edge swap distance will be shorter
                    {
                        //swap b-c, e-f to b-e, c-f by swapping e<->c on list
                        int tmpC = route[iX + 1];
                        route[iX + 1] = route[eX];
                        route[eX] = tmpC;
                    }//end if
                }//end for
                iX++;
            }
            
           
            return route;
        }
    }
}
