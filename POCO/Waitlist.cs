namespace POCO
{
    using System.Collections.Generic;

    public class Waitlist
    {
        public string StudentId { get; set; }

        public string ScheduleId { get; set; }

        public string Waitlist_Id { get; set; }

        public override string ToString()
        {
            return this.StudentId + "-"
                + this.ScheduleId + "-"
                + this.Waitlist_Id;
        }
    }
}
