using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    class EmailListRepo
    {
        public List<Customer> _allCustomers = new List<Customer>();

        public List<Customer> _currentCustomer = new List<Customer>();

        public List<Customer> _pastCustomer = new List<Customer>();

        public List<Customer> _potentialCustomer = new List<Customer>();


        //add new customer
        public void AddNewCustomer(Customer customer)
        {
            _allCustomers.Add(customer);

            if (customer.Type == "current")
            {
                _currentCustomer.Add(customer);
            }

            if (customer.Type == "past")
            {
                _pastCustomer.Add(customer);
            }

            if (customer.Type == "potential")
            {
                _potentialCustomer.Add(customer);
            }
        }
        //see all customers/potential customers
        public List<Customer> SeeAllCustomers()
        {
            return _allCustomers;
        }

        //update customer (or anyone in the list)
        public bool UpdateExistingCustomer(int originalCustomer, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerById(originalCustomer);
            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Type = newCustomer.Type;

                return true;
            }
            else
                return false;
        }


        //delete customer
        public bool DeleteBadge(int id)
        {
            Customer customer = GetCustomerById(id);

            if (customer.Id != id)
                return false;

            int initialCount = _allCustomers.Count;

            _allCustomers.Remove(customer);
            _pastCustomer.Remove(customer);
            _currentCustomer.Remove(customer);
            _potentialCustomer.Remove(customer);

            if(initialCount > _allCustomers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper method
        public Customer GetCustomerById(int id)
        {
            foreach(var customer in _allCustomers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }




    }
}
