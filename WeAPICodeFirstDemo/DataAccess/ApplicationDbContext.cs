using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPICodeFirstDemo.Models;

namespace WebAPICodeFirstDemo.DataAccess
{
    //ApplicationDbContext class inherits from DbContext which is part of Entity Framework.
    //Base class DbContext provides the functionality to interact with the database.
    public class ApplicationDbContext : DbContext
    {
        // This constructor calls the base class constructor with the name of the database.
        public ApplicationDbContext() : base("WebApiCrudDBConn")
        { }

        // Creating table from model - class Employee.
        // Inside DbSet we have to pass type of the model class.
        // Table name will be same as the class name, in our case it is Employees
        public DbSet<Employee> Employees { get; set; }

    }
}