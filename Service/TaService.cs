namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class TaService
    {
        private readonly ITARepository repository;

        public TaService(ITARepository repository)
        {
            this.repository = repository;
        }

        public void InsertTA(TA ta, ref List<string> errors)
        {
            if (ta == null)
            {
                errors.Add("TA cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta.TA_Id))
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            this.repository.InsertTA(ta, ref errors);
        }

        public void UpdateTA(TA ta, ref List<string> errors)
        {
            if (ta == null)
            {
                errors.Add("TA cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta.TA_Id))
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta.Schedule_Id))
            {
                errors.Add("Invalid Schedule id");
                throw new ArgumentException();
            }

            this.repository.UpdateTA(ta, ref errors);
        }

        public void DeleteTA(TA ta, ref List<string> errors)
        {
             if (string.IsNullOrEmpty(ta.TA_Id))
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta.Schedule_Id))
            {
                errors.Add("Invalid Schedule id");
                throw new ArgumentException();
            }

            this.repository.DeleteTA(ta, ref errors);
        }
        
        public List<TA> GetTAList(ref List<string> errors)
        {
            return this.repository.GetTAList(ref errors);
        }
    }
}
