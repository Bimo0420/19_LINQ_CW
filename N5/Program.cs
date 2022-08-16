using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PC pc5 = pc3.FirstOrDefault();  //- найти самый дорогой и самый бюджетный компьютер;
            Console.WriteLine($"Сымый дешевый: {pc5.Code} {pc5.Name} {pc5.Price}");
            PC pc6 = pc3.LastOrDefault();
            Console.WriteLine($"Сымый дорогой: {pc6.Code} {pc6.Name} {pc6.Price}");


            Console.ReadKey();
        }
    }
}
