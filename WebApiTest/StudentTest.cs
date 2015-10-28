/*
        public string UpdateGradeChangeRequest(string studentId, int scheduleId, bool requestChange)
        public string UpdateGradingOption(string studentId, int scheduleId, string gradingOpt)
*/
namespace WebApiTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using POCO;

    using WebApi.Controllers;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void GetStudentListGetTest()
        {
            var studentController = new StudentController();
            var studentList = studentController.GetStudentList();
        }

        [TestMethod]
        public void GetStudentInfoGetTest()
        {
            var studentController = new StudentController();
            var studentInfo = studentController.GetStudent("A000001");
            Assert.AreEqual("A000001", studentInfo.StudentId);
            Assert.AreEqual("123456789", studentInfo.SSN);
            Assert.AreEqual("John", studentInfo.FirstName);
            Assert.AreEqual("Doe", studentInfo.LastName);
            Assert.AreEqual("xxx1@ucsd.edu", studentInfo.Email);
            Assert.AreEqual("password", studentInfo.Password);
            Assert.AreEqual(9, studentInfo.ShoeSize);
            Assert.AreEqual(100, studentInfo.Weight);
            Assert.AreEqual(0, studentInfo.Age);
        }

        [TestMethod]
        public void InsertStudentPostTest()
        {
            var studentController = new StudentController();
            var newStudent = studentController.InsertStudent(
                    new Student 
                    {  
                        StudentId = "B000001", 
                        FirstName = "Isaac",
                        LastName = "Chu",
                        SSN = "987654321",
                        Email = "ichu@cs.ucsd.edu",
                        Password = "password",
                        ShoeSize = 10,
                        Weight = 175,
                        Age = 38
                    });
            var studentInfo = studentController.GetStudent("B000001");
            Assert.AreEqual("B000001", studentInfo.StudentId);
            Assert.AreEqual("987654321", studentInfo.SSN);
            Assert.AreEqual("Isaac", studentInfo.FirstName);
            Assert.AreEqual("Chu", studentInfo.LastName);
            Assert.AreEqual("ichu@cs.ucsd.edu", studentInfo.Email);
            Assert.AreEqual("password", studentInfo.Password);
            Assert.AreEqual(10, studentInfo.ShoeSize);
            Assert.AreEqual(175, studentInfo.Weight);
            Assert.AreEqual(38, studentInfo.Age);
        }

        [TestMethod]
        public void UpdateStudentPostTest()
        {
            var studentController = new StudentController();
            var getStudent = studentController.GetStudent("A0000111");
            getStudent.LastName = "Wain";
            var editStudent = studentController.UpdateStudent(getStudent);

            var studentInfo = studentController.GetStudent("A0000111");
            Assert.AreEqual("A0000111", studentInfo.StudentId);
            Assert.AreEqual("555-55-33", studentInfo.SSN);
            Assert.AreEqual("Bruce", studentInfo.FirstName);
            Assert.AreEqual("Wain", studentInfo.LastName);
            Assert.AreEqual("bwayne@ucsd.edu", studentInfo.Email);
            Assert.AreEqual("password", studentInfo.Password);
            Assert.AreEqual(10, studentInfo.ShoeSize);
            Assert.AreEqual(160, studentInfo.Weight);
            Assert.AreEqual(0, studentInfo.Age);
        }

        [TestMethod]
        public void DeleteStudentPostTest()
        {
            var studentController = new StudentController();
            var delStudent = studentController.DeleteStudent("B000001");

            Assert.AreEqual("ok", delStudent);
        }

        [TestMethod]
        public void EnrollSchedulePostTest()
        {
            var studentController = new StudentController();
            var enrollSchedule = studentController.EnrollSchedule("A0000111", 112);

            Assert.AreEqual("ok", enrollSchedule);
        }

        [TestMethod]
        public void EnrollSchedulePostTest2()
        {
            var studentController = new StudentController();
            var enrollSchedule = studentController.EnrollSchedule("A0000111", 112);

            Assert.AreEqual("error", enrollSchedule);
        }

        [TestMethod]
        public void DropEnrolledSchedulePostTest()
        {
            var studentController = new StudentController();
            var dropEnrolledSchedule = studentController.DropEnrolledSchedule("A0000111", 112);

            Assert.AreEqual("ok", dropEnrolledSchedule);
        }

        [TestMethod]
        public void GetEnrollmentsGetTest()
        {
            var studentController = new StudentController();
            var studentEnrollments = studentController.GetEnrollments("A000001");

            Assert.AreEqual(102, studentEnrollments[0].ScheduleId);
            Assert.AreEqual(111, studentEnrollments[1].ScheduleId);
            Assert.AreEqual(112, studentEnrollments[2].ScheduleId);
            Assert.AreEqual(116, studentEnrollments[3].ScheduleId);
        }

        [TestMethod]
        public void UpdateGradeChangeRequestPostTest()
        {
            var studentController = new StudentController();
            var studentGradeRequest = studentController.UpdateGradeChangeRequest("A000001",111,true);

            Assert.AreEqual("ok", studentGradeRequest);
        }

        [TestMethod]
        public void UpdateGradeChangeRequestPostTest2()
        {
            var studentController = new StudentController();
            var studentGradeRequest = studentController.UpdateGradeChangeRequest("A000001", 112, true);

            Assert.AreEqual("error", studentGradeRequest);
        }

        [TestMethod]
        public void UpdateGradingOptionPostTest()
        {
            var studentController = new StudentController();
            var studentGradeOpt = studentController.UpdateGradingOption("A000001",112,"P/NP");

            Assert.AreEqual("error", studentGradeOpt);
        }
    }
}