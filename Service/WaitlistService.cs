namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class WaitlistService
    {
        private readonly IWaitlistRepository repository;

        public WaitlistService(IWaitlistRepository repository)
        {
            this.repository = repository;
        }

        public void InsertWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            if (waitlist == null)
            {
                errors.Add("Waitlist cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(waitlist.StudentId))
            {
                errors.Add("Invalid schdule id");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(waitlist.ScheduleId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.InsertWaitlist(waitlist, ref errors);
        }

        public void UpdateWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            if (waitlist == null)
            {
                errors.Add("waitlist cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(waitlist.StudentId))
            {
                errors.Add("Invalid schdule id");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(waitlist.ScheduleId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.UpdateWaitlist(waitlist, ref errors);

        }

        public void DeleteWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            if (waitlist == null)
            {
                errors.Add("waitlist cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(waitlist.StudentId))
            {
                errors.Add("Invalid schdule id");
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(waitlist.ScheduleId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.DeleteWaitlist(waitlist, ref errors);
        }
        
        public List<Waitlist> GetWaitlist(ref List<string> errors)
        {
            return this.repository.GetWaitlist(ref errors);
        }
    }
}
