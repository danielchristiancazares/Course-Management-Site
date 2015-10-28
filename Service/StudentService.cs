namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System.Text.RegularExpressions;

    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
                throw new ArgumentException();
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (!(r.IsMatch(student.StudentId))) {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            this.repository.InsertStudent(student, ref errors);
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(student.StudentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.UpdateStudent(student, ref errors);
        }

        public Student GetStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            return this.repository.GetStudentDetail(id, ref errors);
        }

        public void DeleteStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.DeleteStudent(id, ref errors);
        }

        public List<Student> GetStudentList(ref List<string> errors)
        {
            return this.repository.GetStudentList(ref errors);
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            this.repository.EnrollSchedule(studentId, scheduleId, ref errors);
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            this.repository.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        public List<Enrollment> GetEnrollments(string studentId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            return this.repository.GetEnrollments(studentId);
        }

        public void UpdateGradeChangeRequest(string studentId, int scheduleId, bool requestChange, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            List<Enrollment> e = this.repository.GetEnrollments(studentId);
            var enrollment = e.Find(x => x.ScheduleId == scheduleId);
            if (string.IsNullOrEmpty(enrollment.Grade))
            {
                errors.Add("Cannot modify the grade change request of an enrollment without a grade.");
            }

            this.repository.UpdateGradeChangeRequest(studentId, scheduleId, requestChange, ref errors);
        }

        public void UpdateGradingOption(string studentId, int scheduleId, string gradingOpt, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0 || string.IsNullOrEmpty(gradingOpt))
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            List<Enrollment> e = this.repository.GetEnrollments(studentId);
            var enrollment = e.Find(x => x.ScheduleId == scheduleId);
            if (!string.IsNullOrEmpty(enrollment.Grade))
            {
                errors.Add("Cannot modify the grading option of an enrollment with a grade.");
            }

            this.repository.UpdateGradingOption(studentId, scheduleId, gradingOpt, ref errors);
        }

        public float CalculateGpa(string studentId, List<Enrollment> enrollments, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            if (enrollments == null)
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();                
            }

            if (enrollments.Count == 0)
            {
                return 0.0f;
            }

            var sum = 0.0f;

            foreach (var enrollment in enrollments)
            {
                sum += enrollment.GradeValue;
            }

            return sum / enrollments.Count;
        }
    }
}
