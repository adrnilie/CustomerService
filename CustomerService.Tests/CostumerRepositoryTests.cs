using System.Collections.Generic;
using System.Linq;
using CustomerService.Interfaces;
using CustomerService.Models;
using CustomerService.Repositories;
using Moq;
using NUnit.Framework;

namespace CustomerService.Tests
{
    [TestFixture]
    public class CostumerRepositoryTests
    {
        private Mock<IDataProvider> dataProviderMock;
        private CustomerRepository customerRepository;

        [SetUp]
        public void Init()
        {
            dataProviderMock = new Mock<IDataProvider>();
        }

        [Test]
        public void GetAllCustomersShouldReturnExpectedData()
        {
            // Arrange
            var expectedCustomers = new List<Customer>()
            {
                new Customer(1, "test", "test", "test", "test", "test"),
                new Customer(2, "test", "test", "test", "test", "test"),
                new Customer(3, "test", "test", "test", "test", "test")
            };
            dataProviderMock.Setup(s => s.InitializeCustomers()).ReturnsAsync(expectedCustomers);
            customerRepository = new CustomerRepository(dataProviderMock.Object);

            // Act
            var data = customerRepository.GetAllCustomers().Result;

            // Assert
            Assert.That(data, Is.EqualTo(expectedCustomers));
            Assert.That(data.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetAllCustomersShouldReturnAnEmptyList()
        {
            // Arrange
            var expectedResult = new List<Customer>();
            dataProviderMock.Setup(s => s.InitializeCustomers()).ReturnsAsync(expectedResult);
            customerRepository = new CustomerRepository(dataProviderMock.Object);

            // Act
            var data = customerRepository.GetAllCustomers().Result;

            // Assert
            Assert.That(data, Is.Empty);
            Assert.That(data.Count(), Is.Zero);
        }
    }
}
