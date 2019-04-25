using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            var brunchTimes = new TimeSlots
            {
                new TimeSlot(9, 00),
                new TimeSlot(9, 15),
                new TimeSlot(9, 30),
                new TimeSlot(9, 45),
                new TimeSlot(10, 00),
                new TimeSlot(10, 15),
                new TimeSlot(10, 30),
                new TimeSlot(10, 45),
                new TimeSlot(11, 00),
                new TimeSlot(11, 15),
                new TimeSlot(11, 30),
                new TimeSlot(11, 45),
            };
            var lunchTimes = new TimeSlots
            {
                new TimeSlot(11, 00),
                new TimeSlot(11, 15),
                new TimeSlot(11, 30),
                new TimeSlot(11, 45),
                new TimeSlot(12, 00),
                new TimeSlot(12, 15),
                new TimeSlot(12, 30),
                new TimeSlot(12, 45),
                new TimeSlot(13, 00),
                new TimeSlot(13, 15),
                new TimeSlot(13, 30),
                new TimeSlot(13, 45),
            };
            var dinnerTimes = new TimeSlots
            {
                new TimeSlot(17, 00),
                new TimeSlot(17, 15),
                new TimeSlot(17, 30),
                new TimeSlot(17, 45),
                new TimeSlot(18, 00),
                new TimeSlot(18, 15),
                new TimeSlot(18, 30),
                new TimeSlot(18, 45),
                new TimeSlot(19, 00),
                new TimeSlot(19, 15),
                new TimeSlot(19, 30),
                new TimeSlot(19, 45),
            };

            //Booking b1 = new Booking(lunchTimes);
            //var times1 = b1.Book(new TimeSlot(12, 0), 5);

            //foreach (var item in times1)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine();

            //Booking b2 = new Booking(brunchTimes);
            //var times2 = b2.Book(new TimeSlot(11, 30), 6);

            //foreach (var item in times2)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine();

            Booking b3 = new Booking(dinnerTimes);
            var times3 = b3.Book(new TimeSlot(17, 0), 4);

            foreach (var item in times3)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
