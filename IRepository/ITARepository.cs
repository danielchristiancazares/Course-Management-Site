namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ITARepository
    {
        void InsertTA(TA ta, ref List<string> errors);

        void UpdateTA(TA ta, ref List<string> errors);

        void DeleteTA(TA ta, ref List<string> errors);

        List<TA> GetTAList(ref List<string> errors);
    }
}
