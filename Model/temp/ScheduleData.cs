using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ScheduleData
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Comments { get; set; }
        public DateTime ProgramStartTime { get; set; }
        public DateTime ProgramEndTime { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsRecurrence { get; set; }
        public string RecurrenceRule { get; set; }

        public static List<ScheduleData> getDummySchedule ()
        {
            List<ScheduleData> data = new List<ScheduleData> {
                new ScheduleData {
                    ProgramName = "Minklerin dersi",
                    Comments = "Night out with turtles",
                    ProgramStartTime = DateTime.Today.AddHours(10),
                    ProgramEndTime = DateTime.Today.AddHours(11).AddMinutes(30),
                    IsAllDay = false     },
                new ScheduleData {
                    ProgramName = "Yildizların dersi",
                    Comments = "Long sleep during winter season",
                    ProgramStartTime = DateTime.Today.AddHours(13),
                    ProgramEndTime = DateTime.Today.AddHours(14).AddMinutes(30),     },
                new ScheduleData {
                    ProgramName = "Büyüklerin dersi",
                    Comments = "Sleeping in hot season",
                    ProgramStartTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    ProgramEndTime = DateTime.Today.AddHours(19).AddMinutes(30),  }
            };

            return data;
        }

    }
}
