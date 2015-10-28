namespace POCO
{
    public class Enrollment
    {
        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

        public string Grade { get; set; }

        public float GradeValue { get; set; }

        public bool GradeChange { get; set; }

        public string GradingOption { get; set; }
    }
}
