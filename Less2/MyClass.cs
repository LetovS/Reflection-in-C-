using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    public class MyClass
    {
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public int Age { get; set; }
        //public void Add()
        //{

        //}
        public void Add(string a, string b, string c, string d)
        {

        }
        public void Add(string a, string b, string c)
        {

        }
        public void Add(string a)
        {

        }
        public void Add(string a, string b)
        {

        }
        
        
        public void Add(params string[] arr)
        {

        }
    }
}
