using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICodeFirstDemo.DataAccess;
using WebAPICodeFirstDemo.Models;

namespace WebAPICodeFirstDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        // Here we will get all employees
        public HttpResponseMessage Get()
        {
            // Using the ApplicationDbContext to interact with the database
            // 'using' statement ensures to dispose/release any type of resource or connection we are making to db or a file after using it.
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees.ToList());
            }
        }

        // Here we will get employee by id
        public HttpResponseMessage Get(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                // Using LINQ to query the database for an employee with the specified id
                // Trying to find emp in the database with the given id, ** so emp is coming from database **
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);  
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found in the database");
                }
            }
        }

        // Here we will create a new employee
        public HttpResponseMessage Post(Employee employee)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                // Check if the employee object is null
                if (employee != null)
                {
                    // Creating a new employee record in the database
                    dbContext.Employees.Add(employee);

                    // Saving the changes to the database
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                }
                // If the employee object is null, return a bad request response
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide proper input data to create an employee.");
                }
            }
        }

        // Here we will update an existing employee
        public HttpResponseMessage Put(int id, Employee employee)
        {
            using(ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if(emp != null)
                {
                    // emp is coming from the database and employee is coming from the request body
                    // We are updating the properties of emp with the values from employee
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.City = employee.City;
                    emp.IsActive = employee.IsActive;

                    // Saving the changes to the database
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                // If the emp by id is not found, return a not found response
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found in the database. Update failed.");
                }

            }
        }
        public HttpResponseMessage Delete(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                // Trying to find employee by id in the database
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if(emp != null)
                {
                    dbContext.Employees.Remove(emp);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found in the database. Delete failed.");
                }
            }
        }

    }
}
