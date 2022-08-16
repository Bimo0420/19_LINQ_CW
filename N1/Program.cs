using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace N1    //1.    Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.

//Определить:

//- все компьютеры с указанным процессором.Название процессора запросить у пользователя;

//- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;

//- вывести весь список, отсортированный по увеличению стоимости;

//- вывести весь список, сгруппированный по типу процессора;

//- найти самый дорогой и самый бюджетный компьютер;

//- есть ли хотя бы один компьютер в количестве не менее 30 штук?
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PC> listPC = new List<PC>()
            {
                new PC(){Code=01, Name="Apple", CPUtype= "CISC", CPUspeed= 2.2, Vram=32 , Vhd=512 , Vvideo=2 , Price= 1499.99, Quantity=5 },
                new PC(){Code=02, Name="Dell", CPUtype= "RISC", CPUspeed= 3.4, Vram=64 , Vhd=1024 , Vvideo=2 , Price= 999.99, Quantity=3 },
                new PC(){Code=03, Name="Asus", CPUtype= "CISC", CPUspeed= 2.8, Vram=16 , Vhd=1024 , Vvideo=4 , Price= 850.99, Quantity=2 },
                new PC(){Code=04, Name="HP", CPUtype= "MISC", CPUspeed= 2.8, Vram=16 , Vhd=512 , Vvideo=1 , Price= 1199.99, Quantity=2 },
                new PC(){Code=05, Name="Apple", CPUtype= "CISC", CPUspeed= 3.3, Vram=32 , Vhd=1024 , Vvideo=2 , Price= 1199.99, Quantity=5 },
                new PC(){Code=06, Name="Lenovo", CPUtype= "VLIM", CPUspeed= 3.0, Vram=32 , Vhd=1024 , Vvideo=2 , Price= 1299.99, Quantity=6 },
                new PC(){Code=07, Name="HP", CPUtype= "MISC", CPUspeed= 2.5, Vram=32 , Vhd=512 , Vvideo=2 , Price= 1199.99, Quantity=7 },
                new PC(){Code=08, Name="Asus", CPUtype= "RISC", CPUspeed= 2.7, Vram=64 , Vhd=512 , Vvideo=4 , Price= 1399.99, Quantity=11 },
                new PC(){Code=09, Name="HP", CPUtype= "RISC", CPUspeed= 2.8, Vram=64 , Vhd=1024 , Vvideo=4 , Price= 1299.99, Quantity=5 },
                new PC(){Code=10, Name="HP", CPUtype= "CISC", CPUspeed= 3.8, Vram=128 , Vhd=2048 , Vvideo=8 , Price= 3500.00, Quantity=31 }

            };
            Console.WriteLine("Введите название процессора:");    //все компьютеры с указанным процессором.Название процессора запросить у пользователя
            string name = Console.ReadLine();
            List<PC> pc1 = listPC    //синтаксис на основе методов расширения (есть еще SQL подобный)
                .Where(d => d.CPUtype == name)
                .ToList();
            Print(pc1);


            Console.WriteLine("Введите  объём процессора:");  //- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            int vram = Convert.ToInt16(Console.ReadLine());
            List<PC> pc2 = listPC
                .Where(x => x.Vram > vram)
                .ToList();
            Print(pc2);
            Console.WriteLine();

            List<PC> pc3 = listPC    //- вывести весь список, отсортированный по увеличению стоимости;
                .OrderBy(x => x.Price)
                .ToList();
            Print(pc3);
            Console.WriteLine();

            IEnumerable<IGrouping<string, PC>> pc4 = listPC.GroupBy(x => x.CPUtype);    //- вывести весь список, сгруппированный по типу процессора;
            foreach (IGrouping<string, PC> grp in pc4)
            {
                Console.WriteLine(grp.Key);
                foreach (PC comp in grp)
                    Console.WriteLine($"{comp.Code} {comp.Name} {comp.CPUtype} {comp.CPUspeed} {comp.Vram} {comp.Vhd} {comp.Vvideo} {comp.Price} {comp.Quantity}");
            }
            Console.WriteLine();

            PC pc5 = pc3.FirstOrDefault();  //- найти самый дорогой и самый бюджетный компьютер;
            Console.WriteLine($"Сымый дешевый: {pc5.Code} {pc5.Name} {pc5.Price}");
            PC pc6 = pc3.LastOrDefault();
            Console.WriteLine($"Сымый дорогой: {pc6.Code} {pc6.Name} {pc6.Price}");
            Console.WriteLine();

            Console.WriteLine(listPC.Any(x => x.Quantity > 30));    //- есть ли хотя бы один компьютер в количестве не менее 30 штук?

            Console.ReadKey();
        }
        static void Print(List<PC> PC)
        {
            foreach (PC comp in PC)
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.CPUtype} {comp.CPUspeed} {comp.Vram} {comp.Vhd} {comp.Vvideo} {comp.Price} {comp.Quantity}");  //интерполируемая строка
        }
    }
}
