using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenArrayDemo
{
    public class ArrayHelper
    {
        public int[] Flatten(Array array)
        {
            var list = new List<int>();

            if (array != null)
            {
                foreach (var i in array)
                {
                    if (i is Array)
                    {
                        list.AddRange(Flatten((Array)i));
                    }
                    else if (i is int)
                    {
                        list.Add((int)i);
                    }
                }
            }
            return list.ToArray();
        }
    }
}
