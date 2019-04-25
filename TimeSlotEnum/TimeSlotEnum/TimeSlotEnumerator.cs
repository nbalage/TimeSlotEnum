using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotEnum
{
    public class TimeSlotEnumerator : IEnumerator
    {
        IList<TimeSlot> timeSlots; // ???miért nem fogadja el a SortedList-et???
        bool stepUp; // következő nagyobbat vagy kisebbet adjuk-e vissza
        int startPosition; // igényelt időpont
        int actPosition; // ahol jelenleg állunk
        int step;

        public TimeSlotEnumerator(IList<TimeSlot> timeSlots)
        {
            this.timeSlots = timeSlots;
            stepUp = true;
            step = 0;
        }

        public object Current
        {
            get
            {
                return timeSlots[actPosition];
            }
        }

        public bool MoveNext()
        {
            if (!stepUp)
            {
                // balra lépés
                var p = startPosition - step;
                if (p >= 0)
                {
                    actPosition = p;
                }
                else
                {
                    actPosition = startPosition + step;
                    step++;
                }
                stepUp = !stepUp;
            }
            else
            {
                // jobbra lépés
                var p = startPosition + step;
                if (p < timeSlots.Count)
                {
                    actPosition = p;
                }
                else
                {
                    step++;
                    actPosition = startPosition - step;
                }
                step++;
                stepUp = !stepUp;
            }
            return (actPosition < timeSlots.Count) && (actPosition >= 0);
        }

        public void Reset()
        {
            startPosition = -1;
            stepUp = true;
        }

        public void SetNearestSlotIndex(TimeSlot slot)
        {
            TimeSlot nearest;
            TimeSlot difference = new TimeSlot(23, 59);
            int index = 0;
            int i = 0;

            foreach (var item in timeSlots)
            {
                TimeSlot actDiff = item - slot;
                if (actDiff < difference)
                {
                    nearest = item;
                    difference = actDiff;
                    index = i;
                }
                i++;
            }

            startPosition = index;
            actPosition = index;
        }
    }
}
