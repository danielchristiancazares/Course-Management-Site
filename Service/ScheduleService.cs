namespace Service
{
    using System;

    using System.Collections.Generic;

    using IRepository;

    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public void InsertToSchedule(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(schedule.Year))
            {
                errors.Add("Invalid year");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(schedule.Quarter))
            {
                errors.Add("Invalid quarter");
                throw new ArgumentException();
            }

            this.repository.InsertToSchedule(schedule, ref errors);
        }

        public void DeleteFromSchedule(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(schedule.Year))
            {
                errors.Add("Invalid year");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(schedule.Quarter))
            {
                errors.Add("Invalid quarter");
                throw new ArgumentException();
            }

            this.repository.DeleteFromSchedule(schedule, ref errors);
        }

        public void UpdateSchedule(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(schedule.Year))
            {
                errors.Add("Invalid year");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(schedule.Quarter))
            {
                errors.Add("Invalid quarter");
                throw new ArgumentException();
            }

            this.repository.UpdateSchedule(schedule, ref errors);
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(year))
            {
                errors.Add("Invalid year.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(quarter))
            {
                errors.Add("Invalid quarter.");
                throw new ArgumentException();
            }

            return this.repository.GetScheduleList(year, quarter, ref errors);
        }
    }
}
