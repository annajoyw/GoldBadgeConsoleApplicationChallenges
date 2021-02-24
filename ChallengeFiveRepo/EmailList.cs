using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public class EmailList
    {
        public List<Customer> CurrentCustomerEmail { get; set; } = new List<Customer>();
        public List<Customer> PastCustomerEmail { get; set; } = new List<Customer>();
        public List<Customer> PotentialCustomerEmail { get; set; } = new List<Customer>();

        public EmailList() { }

        public EmailList(List<Customer> currentCustomerEmail, List<Customer> pastCustomerEmail, List<Customer> potentialCustomerEmail)
        {
            CurrentCustomerEmail = currentCustomerEmail;
            PastCustomerEmail = pastCustomerEmail;
            PotentialCustomerEmail = potentialCustomerEmail;
        }
    }
}
