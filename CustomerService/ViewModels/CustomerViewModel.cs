using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(string name, string suffix, string iban, string email, string phone)
        {
            this.Name = name;
            this.Suffix = suffix;
            this.IBAN = iban;
            this.Email = email;
            this.Phone = phone;
        }

        public string Name { get; set; }
        public string Suffix { get; set; }
        public string IBAN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}