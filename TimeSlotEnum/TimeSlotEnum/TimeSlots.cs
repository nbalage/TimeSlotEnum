using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotEnum
{
    public class TimeSlots : IEnumerable
    {
        IList<TimeSlot> timeSlots;
        TimeSlotEnumerator enumerator;

        public TimeSlots()
        {
            timeSlots = new List<TimeSlot>();
            enumerator = new TimeSlotEnumerator(timeSlots);
        }

        public TimeSlots(IList<TimeSlot> slots)
        {
            this.timeSlots = slots;
        }

        public void Add(TimeSlot slot)
        {
            timeSlots.Add(slot);
        }

        public void SetNearest(TimeSlot slot)
        {
            enumerator = new TimeSlotEnumerator(timeSlots);
            enumerator.SetNearestSlotIndex(slot);
        }

        public IEnumerator GetEnumerator()
        {
            return enumerator ?? new TimeSlotEnumerator(timeSlots);
        }
    }
}
