using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdizo_p3
{
    class Item
    {
        public int value { get; private set; }
        public int size { get; private set; }
        public double valueToSizeRatio { get; private set; }
        public Item (int v, int s)
        {
            value = v;
            size = s;
            valueToSizeRatio =(double) v / s;
        }

        public void setValue(int v)
        {
            value = v;
        }
    }
}
