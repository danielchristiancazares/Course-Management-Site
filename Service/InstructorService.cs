namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class InstructorService
    {
        private readonly IInstructorRepository repository;

        public InstructorService(IInstructorRepository repository)
        {
            this.repository = repository;
        }

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(instructor.InstructorId))
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            if(string.IsNullOrEmpty(instructor.FirstName))
            {
                errors.Add("Instructor requires a first name.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(instructor.LastName))
            {
                errors.Add("Instructor requires a last name.");
                throw new ArgumentException();
            }

            this.repository.InsertInstructor(instructor, ref errors);
        }

        /*public void UpdateInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
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
        }*/

        public void DeleteInstructor(String id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid instructor id.");
                throw new ArgumentException();
            }

            this.repository.DeleteInstructor(id, ref errors);
        }

        public Instructor GetInstructorInfo(String id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Instructor cannot be null.");
                throw new ArgumentException();
            }
            return this.repository.GetInstructorInfo(id, ref errors);
        }
    }
}
