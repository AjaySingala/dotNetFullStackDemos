using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class CustomerList : IEnumerable<Customer>
    {
        private Customer[] customers;

        public CustomerList(Customer[] customersArray)
        {
            customers = new Customer[customersArray.Length];
            for (int i = 0; i < customersArray.Length; i++)
            {
                customers[i] = customersArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("Inside IEnumerableGetEnumerator()...");
            return new CustomerEnumerator(this);
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            Console.WriteLine("Inside IEnumerable<Customer>.GetEnumerator()...");
            foreach (var customer in customers)
            {
                yield return customer;
            }
        }

        // Define an inner class for the enumerator.
        class CustomerEnumerator : IEnumerator<Customer>
        {
            CustomerList collection;
            int currentIndex = -1;

            public CustomerEnumerator(CustomerList collection)
            {
                this.collection = collection;
            }

            public Customer Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started!");
                    if (currentIndex == collection.customers.Length)
                        throw new InvalidOperationException("Past end of list!");
                    return collection.customers[currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                Console.WriteLine("Inside MoveNext...");

                if (currentIndex >= collection.customers.Length - 1) return false;
                return ++currentIndex < collection.customers.Length;
            }

            public void Reset() { currentIndex = -1; }
        }

    }
}
