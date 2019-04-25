using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotEnum
{
    public struct TimeSlot
    {
        private int hour;
        private int minute;

        public TimeSlot(int hour, int minute)
        {
            this.hour = 0;
            this.minute = 0;

            if ((hour >= 0 && hour < 24) && (minute >= 0 && minute < 60))
            {
                this.hour = hour;
                this.minute = minute;
            }
        }

        public override string ToString()
        {
            return $"{hour:D2}:{minute:D2}";
        }

        public static bool operator > (TimeSlot slot1, TimeSlot slot2)
        {
            return GetMinutes(slot1) > GetMinutes(slot2);
        }

        public static bool operator < (TimeSlot slot1, TimeSlot slot2)
        {
            return GetMinutes(slot2) > GetMinutes(slot1);
        }

        public static TimeSlot operator - (TimeSlot slot1, TimeSlot slot2)
        {
            (TimeSlot greater, TimeSlot smaller) ordered = OrderByGreatness(slot1, slot2);
            var diff = GetMinutes(ordered.greater) - GetMinutes(ordered.smaller);

            return GetTimeSlot(diff);
        }

        private static (TimeSlot, TimeSlot) OrderByGreatness(TimeSlot slot1, TimeSlot slot2)
        {
            TimeSlot greater;
            TimeSlot smaller;

            if (slot1 > slot2)
            {
                greater = slot1;
                smaller = slot2;
            }
            else
            {
                greater = slot2;
                smaller = slot1;
            }

            return (greater, smaller);
        }

        private static int GetMinutes(TimeSlot slot)
        {
            return (slot.hour * 60) + slot.minute;
        }

        private static TimeSlot GetTimeSlot(int minutes)
        {
            var min = minutes % 60;
            var _minutes = minutes - min;
            var hours = _minutes / 60;
            return new TimeSlot(hours, min);
        }
    }
}
