namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IInstructorRepository
    {
        void InsertInstructor(Instructor instructor, ref List<string> errors);

        void DeleteInstructor(string id, ref List<string> errors);

        //void UpdateInstruct(Instructor instructor);

        Instructor GetInstructorInfo(string id, ref List<string> errors);
    }
}
