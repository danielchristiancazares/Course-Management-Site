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
    public class AdminServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertAdminTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.InsertAdmin(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertAdminTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);
            var admin = new Admin { Email = string.Empty, FirstName = string.Empty, LastName = string.Empty, Password = string.Empty };

            //// Act
            adminService.InsertAdmin(admin, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteAdminTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.DeleteAdmin(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateAdminTest()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.UpdateAdmin(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateAdminTest2()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);
            var admin = new Admin { Email = string.Empty, FirstName = string.Empty, LastName = string.Empty, Password = string.Empty };

            //// Act
            adminService.UpdateAdmin(admin, ref errors);

            //// Assert
            Assert.AreEqual(4, errors.Count);
        }
    }
}
