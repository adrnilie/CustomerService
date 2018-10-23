using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Interfaces;
using CustomerService.Models;
using CustomerService.Repositories;
using CustomerService.ViewModels;
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
        public async Task DeleteCustomerByIdShouldRemoveCustomerFromList()
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
            await customerRepository.DeleteCustomer(2);
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

        [Test]
        public async Task AddOrUpdateCustomerShouldAddDesiredRecordToTheList()
        {
            // Arrange
            var initialCustomersDataList = new List<Customer>()
            {
                new Customer(1, "test1", "test1", "test1", "test1", "test1"),
                new Customer(2, "test2", "test2", "test2", "test2", "test2"),
                new Customer(3, "test3", "test3", "test3", "test3", "test3")
            };
            var customerToInsert = new CustomerViewModel("test4", "test4", "test4", "test4", "test4");
            var expectedData = new List<Customer>()
            {
                new Customer(1, "test1", "test1", "test1", "test1", "test1"),
                new Customer(2, "test2", "test2", "test2", "test2", "test2"),
                new Customer(3, "test3", "test3", "test3", "test3", "test3"),
                new Customer(4, "test4", "test4", "test4", "test4", "test4")

            };
            var expectedId = 4;
            dataProviderMock.Setup(s => s.InitializeCustomers()).ReturnsAsync(initialCustomersDataList);
            customerRepository = new CustomerRepository(dataProviderMock.Object);

            // Act
            var actualUserId = await customerRepository.AddOrUpdateCustomer(customerToInsert);
            var actualData = customerRepository.GetAllCustomers().Result.ToList();

            // Assert
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            Assert.That(actualUserId, Is.EqualTo(expectedId));
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

        [Test]
        public async Task AddOrUpdateCustomerShouldUpdateItemInList()
        {
            // Arrange
            var initialCustomersDataList = new List<Customer>()
            {
                new Customer(1, "test1", "test1", "test1", "test1", "test1"),
                new Customer(2, "test2", "test2", "test2", "testEmail", "test2"),
                new Customer(3, "test3", "test3", "test3", "test3", "test3")
            };
            var customerToInsert = new CustomerViewModel("test4", "test4", "test4", "testEmail", "test4");
            var expectedData = new List<Customer>()
            {
                new Customer(1, "test1", "test1", "test1", "test1", "test1"),
                new Customer(2, "test4", "test4", "test4", "testEmail", "test4"),
                new Customer(3, "test3", "test3", "test3", "test3", "test3")
            };
            var expectedId = 2;
            dataProviderMock.Setup(s => s.InitializeCustomers()).ReturnsAsync(initialCustomersDataList);
            customerRepository = new CustomerRepository(dataProviderMock.Object);

            // Act
            var actualUserId = await customerRepository.AddOrUpdateCustomer(customerToInsert);
            var actualData = customerRepository.GetAllCustomers().Result.ToList();

            // Assert
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            Assert.That(actualUserId, Is.EqualTo(expectedId));
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
