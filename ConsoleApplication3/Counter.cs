using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Counter
    {
        public int N { get; set; }
        public int Value { get; set; }

        public void Add(int x)
        {
            this.Value = this.Value + x;
            this.N++;
        }
        public float Mean()
        {
            return this.Value / this.N;
        }
    }
}
