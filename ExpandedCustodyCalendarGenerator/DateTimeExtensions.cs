using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandedCustodyCalendarGenerator
{
    public static class DateTimeExtensions
    {
        private static GregorianCalendar _gc = new GregorianCalendar();

        public static int WeekdayOccurrence(this DateTime time)
        {
            return Enumerable.Range(1, time.Day)
                .Where(d => new DateTime(time.Year, time.Month, d).DayOfWeek == time.DayOfWeek).Count();
        }

        public static int WeekOfYear(this DateTime time, DayOfWeek dayOfWeek = DayOfWeek.Sunday)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, dayOfWeek);
        }

        public static string Ordinal(this int value)
        {
            string suffix = "th";

            int ones = value % 10;
            int tens = (int)(Math.Floor((double)(value / 10)) % 10);
            if (tens == 1)
            {
                suffix = "th";
            }
            else
            {
                switch (ones)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }
            return string.Format("{0}{1}", value, suffix);
        }
    }
}
