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
    public class ScheduleServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertToSchTest()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.InsertToSchedule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertToSchTest2()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);
            var schedule = new Schedule { Quarter = string.Empty, Year = string.Empty };

            //// Act
            scheduleService.InsertToSchedule(schedule, ref errors);

            //// Assert
            Assert.AreEqual(5, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteFromSchTest()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.DeleteFromSchedule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteFromSchTest2()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);
            var schedule = new Schedule { Quarter = string.Empty, Year = string.Empty };

            //// Act
            scheduleService.DeleteFromSchedule(schedule, ref errors);

            //// Assert
            Assert.AreEqual(5, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateSchTest()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            scheduleService.UpdateSchedule(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateSchTest2()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);
            var schedule = new Schedule { Quarter = string.Empty, Year = string.Empty};

            //// Act
            scheduleService.UpdateSchedule(schedule, ref errors);

            //// Assert
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSchTest()
        {
            //// Arrange
            var errors = new List<String>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);
            String year = string.Empty;
            String quarter = string.Empty;

            //// Act
            scheduleService.GetScheduleList(year, quarter, ref errors);

            //// Assert
            Assert.AreEqual(2, errors.Count);
        }
    }
}
