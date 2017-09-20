using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    class Backpack
    {
        public int capacity { get; private set; }
        public float currentValue { get; private set; }
        public List<Item> items { get; set; }
        public Backpack(int inCap = 100)
        {
            capacity = inCap;
            currentValue = 0;
            items = new List<Item>();
        }

        public void printBackpack()
        {
            Console.WriteLine("<------------->");
            _Shared.printItemList(items);
            Console.WriteLine("-------------");
            Console.WriteLine("Backpack capacity: " + capacity);
            Console.WriteLine("Current load: " + _Shared.getListSize(items));
            Console.WriteLine("Current value: " + _Shared.getListValue(items));
            Console.WriteLine("////-------------\\\\");
        }
        //loading backpack from file
        public void loadBackapck(string filename)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(filename);
            }
            catch(Exception e)
            {
                Console.WriteLine("Read from file error - " + e);
            }
            int it = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                String[] tmp = lines[i].Split();                
                if (i == 0 && tmp != null)
                {
                    int c = 0;
                    int.TryParse(tmp[0], out c);
                    capacity = c;
                    for(int j = 0;; j++)
                    {
                        if (tmp[j] == "")
                            continue;
                        else
                        {
                            int.TryParse(tmp[j], out it);
                            break;
                        }
                            
                    }
                }
                else
                {
                    if (i > it)
                        break;
                    for (int j = 1;; j++)
                    {
                        if (tmp[j] == "")
                            continue;
                        int v, s;
                        int.TryParse(tmp[0], out s);
                        int.TryParse(tmp[j], out v);
                        items.Add(new Item(v, s));
                        break;
                    }
                }

            }
        }

    }
}
