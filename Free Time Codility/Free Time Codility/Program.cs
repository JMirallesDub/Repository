using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Free_Time_Codility
{
    class Program
    {
        enum Dow { Sat, Sun, Mon, Tue, Wed, Thu, Fri = 1 };
        static void Main(string[] args)
        {
            //var list = dateList.OrderBy(x => x.TimeOfDay).ToList();
            // ToList added in response to comment.
            //            string input = @"Mon 01:00-23:00
            //Tue 01:00-23:00
            //Wed 01:00-23:00
            //Thu 01:00-23:00
            //Fri 01:00-23:00
            //Sat 01:00-23:00
            //Sun 01:00-21:00";

            int[] n = (int[])Enum.GetValues(typeof(Dow));

            string input = @"Sun 10:00-20:00
Fri 05:00-10:00
Fri 16:30-23:50
Sat 10:00-24:00
Sun 01:00-04:00
Sat 02:00-06:00
Tue 03:30-18:15
Tue 19:00-20:00
Wed 04:25-15:14
Wed 15:14-22:40
Thu 00:00-23:59
Mon 05:00-13:00
Mon 15:00-21:00";
            int total = solution(input);
        }

        public static int solution(string S)
        {
            double minutes = 0;
            
            var startDate = new DateTime(1900, 1, 2);
            var endDate = new DateTime(1900, 1, 9);

            var meetingsDate = new List<DateTime>();


            string[] meetings = S.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            
            for (int meeting = 0; meeting < meetings.Length; meeting++)
            {
                var beginDateTime = new DateTime(1900, 1, 1) { };
                var endDateTime = new DateTime(1900, 1, 1) { };

                switch (meetings[meeting].Substring(0, 3).ToUpper())
                {
                    case "MON":
                        beginDateTime = beginDateTime.AddDays(1);
                        endDateTime = endDateTime.AddDays(1);
                        break;
                    case "TUE":
                        beginDateTime = beginDateTime.AddDays(2);
                        endDateTime = endDateTime.AddDays(2);
                        break;
                    case "WED":
                        beginDateTime = beginDateTime.AddDays(3);
                        endDateTime = endDateTime.AddDays(3);
                        break;
                    case "THU":
                        beginDateTime = beginDateTime.AddDays(4);
                        endDateTime = endDateTime.AddDays(4);
                        break;
                    case "FRI":
                        beginDateTime = beginDateTime.AddDays(5);
                        endDateTime = endDateTime.AddDays(5);
                        break;
                    case "SAT":
                        beginDateTime = beginDateTime.AddDays(6);
                        endDateTime = endDateTime.AddDays(6);
                        break;
                    case "SUN":
                        beginDateTime = beginDateTime.AddDays(7);
                        endDateTime = endDateTime.AddDays(7);
                        break;

                }

                string[] periods = meetings[meeting].Split(new[] { " " }, StringSplitOptions.None);

                string[] times = periods[1].Split(new[] { "-" }, StringSplitOptions.None);
                string[] startperiodTime = times[0].Split(new[] { ":" }, StringSplitOptions.None);
                string[] endperiodTime = times[1].Split(new[] { ":" }, StringSplitOptions.None);


                beginDateTime = beginDateTime.AddMinutes(int.Parse(startperiodTime[1]));
                beginDateTime = beginDateTime.AddHours(int.Parse(startperiodTime[0]));

                endDateTime = endDateTime.AddMinutes(int.Parse(endperiodTime[1]));
                endDateTime = endDateTime.AddHours(int.Parse(endperiodTime[0]));

                meetingsDate.Add(beginDateTime);
                meetingsDate.Add(endDateTime);
            }

            var meetingDateTimes = meetingsDate.OrderBy(m => m.Date).ThenBy(m=>m.TimeOfDay).ToArray();
         


            for (int pos = 0; pos < meetingDateTimes.Length + 2 ; pos= pos + 2)
            {
                if (pos == 0)
                {
                    TimeSpan spans = meetingDateTimes[0].Subtract(startDate);
                    minutes = spans.TotalMinutes;
                }
                else if (pos == meetingDateTimes.Length)
                {
                    TimeSpan spane = endDate.Subtract(meetingDateTimes[pos -1]);
                    if (spane.TotalMinutes > minutes)
                        minutes = spane.TotalMinutes;
                }
                else
                {
                    TimeSpan spanst = meetingDateTimes[pos].Subtract(meetingDateTimes[pos - 1]);
                    if (spanst.TotalMinutes > minutes)
                        minutes = spanst.TotalMinutes;
                }
                
            }

            return (int) minutes;
        }
    }
}
