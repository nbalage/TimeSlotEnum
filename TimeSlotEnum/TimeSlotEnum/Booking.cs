using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotEnum
{
    public class Booking
    {
        TimeSlots timeSlots;

        public Booking(TimeSlots slots)
        {
            this.timeSlots = slots;
        }

        public IEnumerable<TimeSlot> Book(TimeSlot desiredTime, int slotsShown)
        {
            if (slotsShown < 0)
            {
                throw new IndexOutOfRangeException();
            }

            timeSlots.SetNearest(desiredTime);
            List<TimeSlot> retSlots = new List<TimeSlot>();

            foreach (TimeSlot item in timeSlots)
            {
                if (retSlots.Count < slotsShown)
                {
                    retSlots.Add(item);
                }
            }

            return retSlots;
        }
    }
}
