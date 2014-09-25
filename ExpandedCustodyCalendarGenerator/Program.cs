using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace ExpandedCustodyCalendarGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            bool visitation = false;
            bool previousVisitation = false;
            bool eventFlag = false;

            DateTime endDate = new DateTime(2021, 8, 1);
            DateTime startDate = new DateTime(2014, 8, 1);

            TimeSpan timespan = endDate - startDate;

            IICalendar ical = new iCalendar();
            ical.AddLocalTimeZone();
            ical.Name = "Serenity Henderson's Custody Calendar";

            //var dates = from d in Enumerable.Range(1, 31)
            //            select new DateTime(2015, 8, d);

            //dates.ToList().ForEach(d => Console.WriteLine("{0:yyyyMMdd} - {1} {2}", d, d.WeekdayOccurrence().Ordinal(), d.DayOfWeek));

            Event custodyEvent1 = ical.Create<Event>();
            custodyEvent1.DTStart = new iCalDateTime(new DateTime(2014, 7, 20));
            custodyEvent1.DTEnd = new iCalDateTime(new DateTime(2014, 7, 27));
            custodyEvent1.Name = "VEVENT";
            custodyEvent1.Summary = "Serenity @ Noel's";
            custodyEvent1.Description = "Noel's last full week";
            custodyEvent1.Location = "Noel's Home";
            custodyEvent1.Transparency = TransparencyType.Transparent;
            custodyEvent1.Status = EventStatus.Confirmed;

            Event custodyEvent2 = ical.Create<Event>();
            custodyEvent2.DTStart = new iCalDateTime(new DateTime(2014, 7, 27));
            custodyEvent2.DTEnd = new iCalDateTime(new DateTime(2014, 8, 1));
            custodyEvent2.Name = "VEVENT";
            custodyEvent2.Summary = "Serenity @ Niki's";
            custodyEvent2.Description = "Niki's last full week";
            custodyEvent2.Location = "Niki's Home";
            custodyEvent2.Transparency = TransparencyType.Transparent;
            custodyEvent2.Status = EventStatus.Confirmed;

            DateTime eventEnd = startDate;
            DateTime nikiStart = startDate;

            while(startDate <= endDate)
            {
                if(startDate.DayOfWeek == DayOfWeek.Friday && 
                    (startDate.WeekdayOccurrence() == 1 || 
                    startDate.WeekdayOccurrence() == 3 || 
                    startDate.WeekdayOccurrence() == 5) && 
                    visitation == false)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate.AddDays(-1));
                    custodyEvent.Duration = TimeSpan.FromDays(3);
                    custodyEvent.Summary = string.Format("Serenity @ Noel's - {0} Friday", startDate.WeekdayOccurrence().Ordinal());
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Description = "Serenity is with her dad";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    //Alarm alarm = new Alarm();
                    //alarm.Action = AlarmAction.Display;
                    //alarm.Summary = "Serenity @ Noel's";
                    //alarm.Trigger = new Trigger(TimeSpan.FromDays(-1));
                    //custodyEvent.Alarms.Add(alarm);
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }
                if(startDate.DayOfWeek == DayOfWeek.Thursday && visitation == false)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);// .AddHours(18));
                    custodyEvent.Duration = TimeSpan.FromDays(1);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - Thursday Evenings";
                    custodyEvent.Description = "Serenity is with her dad";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    //Alarm alarm = new Alarm();
                    //alarm.Action = AlarmAction.Display;
                    //alarm.Summary = "Get Serenity";
                    //alarm.Trigger = new Trigger(TimeSpan.FromHours(-2));
                    //custodyEvent.Alarms.Add(alarm);

                    //Alarm alarm1 = new Alarm();
                    //alarm1.Action = AlarmAction.Display;
                    //alarm1.Summary = "Get Serenity";
                    //alarm1.Trigger = new Trigger(TimeSpan.FromHours(-1));
                    //custodyEvent.Alarms.Add(alarm1);

                    //Alarm alarm2 = new Alarm();
                    //alarm2.Action = AlarmAction.Display;
                    //alarm2.Summary = "Get Serenity";
                    //alarm2.Trigger = new Trigger(TimeSpan.FromMinutes(-30));
                    //custodyEvent.Alarms.Add(alarm2);
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }
                if(startDate.Month == 6 && startDate.DayOfWeek == DayOfWeek.Sunday && startDate.WeekdayOccurrence() == 3 && visitation == false)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(1);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - Father's day";
                    custodyEvent.Description = "Serenity is with her dad";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }
                if(startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Monday && startDate.WeekdayOccurrence() == 1 && startDate.Year % 2 == 0)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(1);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Update W4 dependents - Niki's year";
                    custodyEvent.Description = "Niki gets to have Serenity as a dependent for tax purposes next year";
                    custodyEvent.Location = "Niki's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    //Alarm alarm = new Alarm();
                    //alarm.Action = AlarmAction.Display;
                    //alarm.Summary = "Update W4";
                    //alarm.Trigger = new Trigger(TimeSpan.FromMinutes(0));
                    //custodyEvent.Alarms.Add(alarm);
                    eventEnd = startDate + custodyEvent.Duration;
                    //eventFlag = false;
                }
                if (startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Monday && startDate.WeekdayOccurrence() == 1 && startDate.Year % 2 == 1)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(1);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Update W4 dependents - Noel's year";
                    custodyEvent.Description = "Noel gets to have Serenity as a dependent for tax purposes next year";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    //Alarm alarm = new Alarm();
                    //alarm.Action = AlarmAction.Display;
                    //alarm.Summary = "Update W4";
                    //alarm.Trigger = new Trigger(TimeSpan.FromMinutes(0));
                    //custodyEvent.Alarms.Add(alarm);
                    eventEnd = startDate + custodyEvent.Duration;
                    //eventFlag = true;
                }

                if (startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day > 18 && startDate.Day < 25 && startDate.Year % 2 == 0)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(7);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - Christmas";
                    custodyEvent.Description = "Noel gets to have Serenity for Christmas";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                if (startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day > 18 && startDate.Day < 25 && startDate.Year % 2 == 1)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(7);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Niki's - Christmas";
                    custodyEvent.Description = "Niki gets to have Serenity for Christmas";
                    custodyEvent.Location = "Niki's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = false;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                if (startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day > 25 && startDate.Year % 2 == 0)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(7);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Niki's - Winter Break";
                    custodyEvent.Description = "Niki gets to have Serenity for 2nd half of Winter Break";
                    custodyEvent.Location = "Niki's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    eventEnd = startDate + custodyEvent.Duration;
                    eventFlag = true;
                }

                if (startDate.Month == 12 && startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day > 25 && startDate.Year % 2 == 1)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(7);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - Winter Break";
                    custodyEvent.Description = "Noel gets to have Serenity for 2nd half of Winter Break";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                if (startDate.DayOfWeek == DayOfWeek.Thursday && startDate.Month == 11 && startDate.WeekdayOccurrence() == 4 && startDate.Year % 2 == 0)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(4);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Niki's - ThanksGiving";
                    custodyEvent.Description = "Niki gets to have Serenity for ThanksGiving";
                    custodyEvent.Location = "Niki's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = false;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                if (startDate.DayOfWeek == DayOfWeek.Thursday && startDate.Month == 11 && startDate.WeekdayOccurrence() == 4 && startDate.Year % 2 == 1)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(4);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - ThanksGiving";
                    custodyEvent.Description = "Noel gets to have Serenity for ThanksGiving";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                // summer vacation after the 22nd of June
                if (startDate.Month == 6 && startDate.DayOfWeek == DayOfWeek.Friday && startDate.Day > 22)
                {
                    Event custodyEvent = ical.Create<Event>();
                    custodyEvent.DTStart = new iCalDateTime(startDate);
                    custodyEvent.Duration = TimeSpan.FromDays(30);
                    custodyEvent.Name = "VEVENT";
                    custodyEvent.Summary = "Serenity @ Noel's - Summer Vacation";
                    custodyEvent.Description = "Summer Vacation with Dad!";
                    custodyEvent.Location = "Noel's Home";
                    custodyEvent.Transparency = TransparencyType.Transparent;
                    custodyEvent.Status = EventStatus.Confirmed;
                    //Alarm alarm = new Alarm();
                    //alarm.Action = AlarmAction.Display;
                    //alarm.Summary = "Make vacation Plans";
                    //alarm.Trigger = new Trigger(TimeSpan.FromDays(90));
                    //custodyEvent.Alarms.Add(alarm);

                    //Alarm alarm1 = new Alarm();
                    //alarm1.Action = AlarmAction.Display;
                    //alarm1.Summary = "Make vacation Plans";
                    //alarm1.Trigger = new Trigger(TimeSpan.FromDays(60));
                    //custodyEvent.Alarms.Add(alarm1);

                    //Alarm alarm2 = new Alarm();
                    //alarm2.Action = AlarmAction.Display;
                    //alarm2.Summary = "Make vacation Plans";
                    //alarm2.Trigger = new Trigger(TimeSpan.FromDays(30));
                    //custodyEvent.Alarms.Add(alarm2);
                    visitation = true;
                    eventFlag = true;
                    eventEnd = startDate + custodyEvent.Duration;
                }

                if(visitation == true)
                {
                    if(previousVisitation == false)
                    {
                        Event custodyEvent = ical.Create<Event>();
                        custodyEvent.DTStart = new iCalDateTime(nikiStart);
                        custodyEvent.DTEnd = new iCalDateTime(startDate);
                        custodyEvent.Name = "VEVENT";
                        custodyEvent.Summary = "Serenity @ Niki's";
                        custodyEvent.Description = "Normal custody";
                        custodyEvent.Location = "Niki's Home";
                        custodyEvent.Transparency = TransparencyType.Transparent;
                        custodyEvent.Status = EventStatus.Confirmed;
                        //Console.WriteLine("Niki end {0:yyyyMMdd}", startDate.AddDays(-1));
                    }
                }
                if(visitation == false)
                {
                    if(previousVisitation == true)
                    {
                        nikiStart = startDate;
                        //Console.WriteLine("Niki start {0:yyyyMMdd}", nikiStart);
                    }
                }
                //Console.WriteLine("Handling: {0:yyyyMMdd}", startDate);
                startDate = eventFlag ? eventEnd.AddDays(1) : startDate.AddDays(1);
                eventFlag = false;
                previousVisitation = visitation;
                visitation = false;
            }

            string filePath = @"C:\Dropbox\Public\Calendars\custody.ics";

            using (var writer = new FileStream(filePath, FileMode.Create))
            {
                iCalendarSerializer serializer = new iCalendarSerializer();
                serializer.Serialize(ical, writer, Encoding.UTF8);
            }

           // Console.ReadKey();
        }
    }
}
