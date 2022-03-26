using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectMoodAnaly7
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            this.Id = 45;
            this.Name = "";
        }

        public Customer(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        //Method To Print Id
        public void PrintId()
        {
            this.Id = 89;
            Console.WriteLine("Id is : {0}", this.Id);
        }

        //Method To Print Name
        public void PrintName()
        {
            this.Name = "ABC";
            Console.WriteLine("Name is : {0}", this.Name);
        }
    }
}
