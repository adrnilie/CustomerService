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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string IBAN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}