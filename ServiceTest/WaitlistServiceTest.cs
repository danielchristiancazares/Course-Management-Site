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
    public class WaitlistServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertWaitlistErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IWaitlistRepository>();
            var waitlistservice = new WaitlistService(mockRepository.Object);

            //// Act
            waitlistservice.InsertWaitlist(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertWaitlistErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IWaitlistRepository>();
            var waitlistservice = new WaitlistService(mockRepository.Object);
            var waitlist = new Waitlist { StudentId = string.Empty };

            //// Act
            waitlistservice.InsertWaitlist(waitlist, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertWaitlistaErrorTest3()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IWaitlistRepository>();
            var waitlistservice = new WaitlistService(mockRepository.Object);
            var waitlist = new Waitlist { ScheduleId = string.Empty };

            //// Act
            waitlistservice.InsertWaitlist(waitlist, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteWaitlistErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IWaitlistRepository>();
            var waitlistservice = new WaitlistService(mockRepository.Object);
            var waitlist = new Waitlist { StudentId = string.Empty, ScheduleId = string.Empty };

            //// Act
            waitlistservice.DeleteWaitlist(waitlist, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
