using CustomerService.ViewModels;

namespace CustomerService.Models
{
    public class Customer
    { 
        public Customer(int id, string name, string suffix, string iban, string email, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Suffix = suffix;
            this.IBAN = iban;
            this.Email = email;
            this.Phone = phone;
        }

        public Customer(int id, CustomerViewModel customerViewModel)
        {
            this.Id = id;
            this.Name = customerViewModel.Name;
            this.Suffix = customerViewModel.Suffix;
            this.IBAN = customerViewModel.IBAN;
            this.Email = customerViewModel.Email;
            this.Phone = customerViewModel.Phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string IBAN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}