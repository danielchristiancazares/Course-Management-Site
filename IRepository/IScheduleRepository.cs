namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors);

        void InsertToSchedule(Schedule schedule, ref List<string> errors);

        void DeleteFromSchedule(Schedule schedule, ref List<string> errors);

        void UpdateSchedule(Schedule schedule, ref List<string> errors);
    }
}
