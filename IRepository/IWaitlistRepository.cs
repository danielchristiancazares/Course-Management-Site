namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IWaitlistRepository
    {
        void InsertWaitlist(Waitlist waitlist, ref List<string> errors);

        void UpdateWaitlist(Waitlist waitlist, ref List<string> errors);

        void DeleteWaitlist(Waitlist waitlist, ref List<string> errors);

        List<Waitlist> GetWaitlist(ref List<string> errors);
    }
}