using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    class Program
    {
        static Backpack backpack;
        static WorldMap map;
        static void tests()
        {
            for (int j = 8; j <= 30; j += 4)
            {
                Stopwatch watch = new System.Diagnostics.Stopwatch();
                //watch.Start();
                //Console.WriteLine("-Greedy" + j);
                //for (int i = 0; i < 100; i++)
                //{

                //    map = new WorldMap(j, true);
                //    watch.Start();
                //    map.bestRoute = SalesmanAlgorithms.greedy(map.cityMatrix, map.numberOfCities);
                //    watch.Stop();

                //}
                //double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency) / 100;
                //Console.WriteLine("Execution time[ms]: " + elapsedMS);


                watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                Console.WriteLine("-Brute" + j);
                for (int i = 0; i < 100; i++)
                {

                    backpack = new Backpack(250);
                    backpack.items = _Shared.generateItems(250,j);
                    watch.Start();
                    backpack.items = BackpackAlgorithms.bruteforceValue(backpack.items, backpack.capacity);
                    watch.Stop();

                }
                double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency) / 100;
                Console.WriteLine("Execution time[ms]: " + elapsedMS);
                //
                //watch = new System.Diagnostics.Stopwatch();
                //watch.Start();
                //Console.WriteLine("-opt" + j);
                //for (int i = 0; i < 100; i++)
                //{

                //    map = new WorldMap(j, true);
                //    watch.Start();
                //    map.bestRoute = SalesmanAlgorithms.opt(map.cityMatrix, map.numberOfCities);
                //    watch.Stop();

                //}
                //elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency) / 100;
                //Console.WriteLine("Execution time[ms]: " + elapsedMS);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            backpack = null;
            map = null;
            //tests();

            //menu section
            while (true)
            {
                UI.printMenu(0);
                int select = 0;
                int.TryParse(Console.ReadLine(), out select);
                switch (select)
                {
                    case 1:
                        UI.printMenu(1);
                        int ch = 0;
                        int.TryParse(Console.ReadLine(), out ch);
                        switch (ch)
                        {
                            case 1:
                                if (backpack != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    backpack.items = BackpackAlgorithms.greedyValue(backpack.items, backpack.capacity);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    Console.ReadLine();
                                }
                                break;
                            case 2:
                                if (backpack != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    backpack.items = BackpackAlgorithms.greedyRatio(backpack.items, backpack.capacity);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    Console.ReadLine();
                                }
                                break;
                            case 3:
                                if (backpack != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    backpack.items = BackpackAlgorithms.bruteforceValue(backpack.items, backpack.capacity);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    Console.ReadLine();
                                }
                                break;
                            case 4:
                                if (backpack != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    backpack.items = BackpackAlgorithms.dynamic(backpack.items, backpack.capacity);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    Console.ReadLine();
                                }
                                break;
                            case 5:

                                Console.WriteLine("Give me filename with extension:");
                                string filename = Console.ReadLine();
                                backpack = new Backpack();
                                backpack.loadBackapck(filename);

                                break;
                            case 6:

                                Console.WriteLine("Give me capacity:");
                                int c = 0;
                                int.TryParse(Console.ReadLine(), out c);
                                backpack = new Backpack(c);
                                backpack.items = _Shared.generateItems(c);
                                break;

                            case 7:
                                if (backpack != null)
                                {
                                    backpack.printBackpack();
                                }
                                break;
                            default:
                                break;

                        }
                        break;
                    //TSP //////////////////////////////////////////////////////////////////////////////////
                    case 2:
                        UI.printMenu(2);
                        int ch2 = 0;
                        int.TryParse(Console.ReadLine(), out ch2);
                        switch (ch2)
                        {
                            case 1:
                                if (map != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    map.bestRoute = SalesmanAlgorithms.greedy(map.cityMatrix, map.numberOfCities);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    map.printBestRoute();
                                    Console.ReadLine();
                                }
                                break;
                            case 2:
                                if (map != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    map.bruteForce(1);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    map.printBestRoute();
                                    Console.ReadLine();
                                }
                                break;
                            case 3:
                                if (map != null)
                                {
                                    //start measurement
                                    Stopwatch watch = new System.Diagnostics.Stopwatch();
                                    watch.Start();
                                    map.bestRoute = SalesmanAlgorithms.opt(map.cityMatrix, map.numberOfCities);
                                    //stop measurement
                                    watch.Stop();
                                    double elapsedMS = ((watch.ElapsedTicks * 1000) / Stopwatch.Frequency);
                                    Console.WriteLine("Execution time[ms]: " + elapsedMS);
                                    map.printBestRoute();
                                    Console.ReadLine();
                                }
                                break;
                            case 4:
                                Console.WriteLine("Give me no. cities:");
                                int c = 0;
                                int.TryParse(Console.ReadLine(), out c);
                                map = new WorldMap(c, true);
                                break;
                            case 5:

                                Console.WriteLine("Give me filename with extension:");
                                string filename = Console.ReadLine();
                                map = new WorldMap(0, false, filename);
                                break;
                            case 6:

                                map.printWorldMap();
                                break;
                            default:
                                break;

                        }
                        break;
                    default:
                        break;
                }

            }









            //g
            // Backpack backpack = new Backpack();
            // backpack.loadBackapck("test.txt");
            // backpack.printBackpack();
            //backpack.items = _Shared.generateItems(backpack.capacity);
            // backpack.printBackpack();
            //backpack.items = BackpackAlgorithms.greedyValue(backpack.items, backpack.capacity);
            //backpack.printBackpack();
            // backpack.items = BackpackAlgorithms.dynamic(backpack.items, backpack.capacity);
            // backpack.printBackpack();
            ////ratio
            //Console.WriteLine("Ratio based ------------------------------------");
            //backpack.items = _Shared.generateItems(backpack.capacity);
            //backpack.printBackpack();
            //backpack.items = BackpackAlgorithms.greedyRatio(backpack.items, backpack.capacity);
            //backpack.printBackpack();
            ////bf
            //Console.WriteLine("Brute force ------------------------------------");
            //backpack.items = _Shared.generateItems(backpack.capacity);
            //backpack.printBackpack();
            //backpack.items = BackpackAlgorithms.bruteforceValue(backpack.items, backpack.capacity);
            //backpack.printBackpack();
            // WorldMap map = new WorldMap(1000,true,"test_world.txt");
            // map.printWorldMap();  
            // List<int> route = SalesmanAlgorithms.opt(map.cityMatrix, map.numberOfCities);
            //Console.WriteLine("Route cost: " + _Shared.routeCost(route, map.cityMatrix));
            //foreach (var i in route)
            //{
            //    Console.Write(i + "-->");
            //}

            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            ////map.bruteForce(1);
            //watch.Stop();
            //double elapsedMS = watch.ElapsedMilliseconds;
            //Console.WriteLine("Execution time[ms]: " + elapsedMS);
            ////map.printBestRoute();
            Console.ReadLine();
        }
    }
}
