using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1
{
    public class PC
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public string CPUtype { get; set; }
        public double CPUspeed { get; set; }
        public int Vram { get; set; }
        public int Vhd { get; set; }
        public int Vvideo { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
