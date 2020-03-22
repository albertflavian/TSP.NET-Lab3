using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelDesignFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            //TestPerson();
            //TesTOneToMany();
            Console.WriteLine("Done...");
            Console.ReadKey();
            
        }

        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                //Person p = new Person()
                //{
                //    FirstName = "Julie",
                //    LastName = "Andrew",
                //    MidleName = "T",
                //    PhoneNumber = "1234567890"
                //};
                //context.People.Add(p);
                //context.SaveChanges();
                //var items = context.People;
                //foreach (var x in items)
                //    Console.WriteLine("{0} {1}", x.Id, x.FirstName);

                Console.WriteLine("Insert new data...");
                Console.Write("First name: ");
                string firstName = Console.ReadLine();

                Console.Write("Midle name: ");
                string midleName = Console.ReadLine();

                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Phone number: ");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Waiting for the operation to be completed...");
                Person p = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MidleName = midleName,
                    PhoneNumber = phoneNumber
                };
                context.People.Add(p);
                context.SaveChanges();
                Thread.Sleep(1000);
                Console.Write("Operation completed ");

            }
        }

        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");
            using (Model1Container context =
           new Model1Container())
            {
                Customer c = new Customer()
                {
                    Name = "Customer 1",
                    City = "Iasi"
                };
                Order o1 = new Order()
                {
                    TotalValue = 200,
                    Date = DateTime.Now,
                    Customer = c
                };
                Order o2 = new Order()
                {
                    TotalValue = 300,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                   x.Id, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                       ox.Id, ox.Date, ox.TotalValue);
                }
            }
        }



    }
}
