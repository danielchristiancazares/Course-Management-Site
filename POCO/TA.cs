namespace POCO
{
    using System.Collections.Generic;

    public class TA
    {
        public int TA_Id_int { get; set; }

        public string TA_Id { get; set; }

        public int Schedule_Id_int { get; set; }

        public string Schedule_Id { get; set; }

        public override string ToString()
        {
            return this.TA_Id + "-"
                + this.Schedule_Id;   
        }
    }
}
