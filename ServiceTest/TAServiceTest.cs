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
    public class TaServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var taservice = new TaService(mockRepository.Object);

            //// Act
            taservice.InsertTA(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var taservice = new TaService(mockRepository.Object);
            var ta = new TA { TA_Id = string.Empty };

            //// Act
            taservice.InsertTA(ta, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTaErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var taservice = new TaService(mockRepository.Object); 
            var ta = new TA { TA_Id = string.Empty };

            //// Act
            taservice.DeleteTA(ta, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
