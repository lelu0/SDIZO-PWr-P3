using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    class WorldMap
    {
        public int[,] cityMatrix { get; private set; }
        public int numberOfCities { get; private set; }
        //variables for bruteforce algorithm -- start
        private List<int> cityList = new List<int>(); // list of all cities for manipulation
        private int minRoute; //distance of current minimal route
        public List<int> bestRoute = new List<int>(); // list for current best road
        // -- end
        public WorldMap(int noCities, bool generic = true, string filename = null)
        {
            minRoute = int.MaxValue;
            numberOfCities = noCities;
            //list for brute force
            cityList = new List<int>();
            for (int i = 0; i < numberOfCities; i++) cityList.Add(i);
            cityList.Add(0);
            //end
            cityMatrix = new int[noCities, noCities];
            if (generic)
                generateCities(noCities);
            else if (filename != null)
                loadWorldMap(filename);
        }

        //generate world map based on number of cities
        public void generateCities(int noCities)
        {
            Random rn = new Random();
            for (int i = 0; i < noCities; i++)
            {
                //from i, because every i-loop sets row and column for one more city
                for (int j = i; j < noCities; j++)
                {
                    if (i == j)
                        cityMatrix[i, j] = 0;
                    else
                    {
                        //generating distance between cities
                        int distance = rn.Next(1, 300);
                        cityMatrix[i, j] = distance;
                        cityMatrix[j, i] = distance;
                    }
                }
            }
        }

        public void printWorldMap()
        {
            Console.Write("xxx|");
            for (int i = 0; i < numberOfCities; i++) Console.Write("{0,4 }", i + "|");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < numberOfCities; i++)
            {
                Console.Write("{0,4 }", i + "|");
                for (int j = 0; j < numberOfCities; j++)
                {
                    Console.Write("{0,4 }", cityMatrix[i, j] + "|");
                }
                Console.WriteLine();
            }
        }

        public void loadWorldMap(string filename)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Read from file error - " + e);
            }
            int citycounter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                
                String[] tmp = lines[i].Split();
                if (i == 0 && tmp != null)
                {
                    int c = 0;
                    int.TryParse(tmp[0], out c);
                    numberOfCities = c;
                    cityMatrix = new int[numberOfCities, numberOfCities];
                    cityList = new List<int>();
                    for (int j = 0; j < numberOfCities; j++) cityList.Add(j);
                    cityList.Add(0);
                }
                else
                {
                    if (i > numberOfCities)
                        break;                    
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        if (tmp[j] == "")
                            continue;
                        int t;
                        int.TryParse(tmp[j], out t);
                        cityMatrix[i - 1, citycounter] = t;
                        citycounter++;
                    }
                    citycounter = 0;
                }

            }
        }
        //recursion brute force algorithm, iteration from 0 to end
        public void bruteForce(int k)
        {
            if (k < numberOfCities - 1)
            {
                for (int i = k; i < numberOfCities; i++)
                {
                    //cities swap
                    int tmp = cityList[i];
                    cityList[i] = cityList[k];
                    cityList[k] = tmp;
                    bruteForce(k + 1);
                    //re-swap of cities
                    tmp = cityList[i];
                    cityList[i] = cityList[k];
                    cityList[k] = tmp;
                }
            }
            else
            {
                //calculating distance for current permutation
                int distance = 0;
                cityList[numberOfCities] = 0;
                //iterating through list of cities in order
                for (int c = 1; c < numberOfCities; c++) {
                    //adding distance between cities 
                    distance += cityMatrix[cityList[c-1], cityList[c]];
                }
                //adding comeback to home
                distance += cityMatrix[cityList[numberOfCities -1], 0];
                if(distance < minRoute && cityList[0] == 0) //statment secured for wrong permutation
                {//saving
                    bestRoute = new List<int>();
                    for (int i = 0; i < numberOfCities; i++) bestRoute.Add(cityList[i]);
                    Console.WriteLine("|"+distance);                    
                    minRoute = distance;
                }
            }
        }

        public void printBestRoute()
        {
            int dist = 0;
            for(int i = 1; i< numberOfCities; i++)
            {
                Console.WriteLine(bestRoute[i - 1] + "-[" + cityMatrix[bestRoute[i - 1], bestRoute[i]] + "]->" + bestRoute[i]);
                dist += cityMatrix[bestRoute[i - 1], bestRoute[i]];
            }
            Console.WriteLine(bestRoute[numberOfCities - 1]+"-["+ cityMatrix[bestRoute[numberOfCities - 1], 0] + "]> 0");
            dist += cityMatrix[bestRoute[numberOfCities - 1], 0];
            Console.WriteLine("Summary distance: " + dist);
        }
    }
}
