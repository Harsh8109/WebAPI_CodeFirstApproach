using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICodeFirstDemo.Models
{
    //Model is a class that represents the data structure of an entity in the application.
    //We will define properties in this class that correspond to the columns in the database table.
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

    }
}