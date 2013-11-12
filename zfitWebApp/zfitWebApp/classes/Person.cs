using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zfit
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public void Add()
        {
            // Magic happens here.
            var x = new Person(); 
        }
    }
}