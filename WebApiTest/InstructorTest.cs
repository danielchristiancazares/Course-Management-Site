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
    public class InstructorTest
    {
        [TestMethod]
        public void GetInstructorInfoGetTest()
        {
            var instructorController = new InstructorController();
            var instructorInfo = instructorController.GetInstructorInfo("1");
            Assert.AreEqual("1", instructorInfo.InstructorId);
            Assert.AreEqual("Isaac", instructorInfo.FirstName);
            Assert.AreEqual("Chu", instructorInfo.LastName);
            Assert.AreEqual("Adjunct Faculty", instructorInfo.Title);
        }

        [TestMethod]
        public void InsertStudentPostTest()
        {
            var instructorController = new InstructorController();
            var newInstructor = instructorController.InsertInstructor(
                    new Instructor
                    {
                        InstructorId = "2",
                        FirstName = "Danny",
                        LastName = "Boy",
                        Title = "New Professor"
                    });
            var instructorInfo = instructorController.GetInstructorInfo("2");
            Assert.AreEqual("2", instructorInfo.InstructorId);
            Assert.AreEqual("Danny", instructorInfo.FirstName);
            Assert.AreEqual("Boy", instructorInfo.LastName);
            Assert.AreEqual("New Professor", instructorInfo.Title);
        }

        [TestMethod]
        public void DeleteStudentPostTest()
        {
            var instructorController = new InstructorController();
            var deleteInstructor = instructorController.DeleteInstructor("2");

            Assert.AreEqual("ok", deleteInstructor);
        }
    }
}