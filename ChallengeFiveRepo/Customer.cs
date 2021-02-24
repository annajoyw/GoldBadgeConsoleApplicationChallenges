using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Customer () { }

        public Customer(int id, string firstName, string lastName, string type, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Email = email;
        }
    }
}
