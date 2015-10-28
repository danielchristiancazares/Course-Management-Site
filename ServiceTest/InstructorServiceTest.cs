namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class InstructorServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.InsertInstructor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            var instructor = new Instructor { InstructorId = string.Empty };

            //// Act
            instructorService.InsertInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            var instructor = new Instructor { FirstName = string.Empty };

            //// Act
            instructorService.InsertInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorTest4()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            var instructor = new Instructor { LastName = string.Empty };

            //// Act
            instructorService.InsertInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteInstructorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.DeleteInstructor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
