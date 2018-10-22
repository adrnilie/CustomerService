using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private static CustomerRepository customerRepository;

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
            var data = customerRepository.GetAllCustomers().Result.ToList();

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
            var data = customerRepository.GetAllCustomers().Result.ToList();

            // Assert
            Assert.That(data, Is.Empty);
            Assert.That(data.Count(), Is.Zero);
        }

        [Test]
        public void DeleteCustomerByIdShouldRemoveCustomerFromList()
        {
            // Arrange
            var customersList = new List<Customer>()
            {
                new Customer(1, "test", "test", "test", "test", "test"),
                new Customer(2, "test", "test", "test", "test", "test"),
                new Customer(3, "test", "test", "test", "test", "test")
            };
            var expectedData = new List<Customer>()
            {
                new Customer(1, "test", "test", "test", "test", "test"),
                new Customer(3, "test", "test", "test", "test", "test")
            };
            dataProviderMock.Setup(s => s.InitializeCustomers()).ReturnsAsync(customersList);
            customerRepository = new CustomerRepository(dataProviderMock.Object);

            // Act
            customerRepository.DeleteCustomer(2);
            var actualData = customerRepository.GetAllCustomers().Result.ToList();

            // Assert
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            for (int i = 0; i < actualData.Count(); i++)
            {
                Assert.That(actualData[i].Id, Is.EqualTo(expectedData[i].Id));
                Assert.That(actualData[i].Name, Is.EqualTo(expectedData[i].Name));
                Assert.That(actualData[i].Email, Is.EqualTo(expectedData[i].Email));
                Assert.That(actualData[i].IBAN, Is.EqualTo(expectedData[i].IBAN));
                Assert.That(actualData[i].Phone, Is.EqualTo(expectedData[i].Phone));
                Assert.That(actualData[i].Suffix, Is.EqualTo(expectedData[i].Suffix));
            }
        }
    }
}
