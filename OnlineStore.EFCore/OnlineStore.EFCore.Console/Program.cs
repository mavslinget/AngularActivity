using System;
using System.Linq;
using System.Collections.Generic;
using OnlineStore.EFCore.Domain.Models;
using OnlineStore.EFCore.Infra;

namespace OnlineStore.EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Create Record
            var context = new OnlineStoreDbContext();

            var tmg = new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Technology Management",
                IsActive = true
            };

            var bdg = new Department
            {
                DepartmentID = Guid.NewGuid(),
                DepartmentName = "Business Developement",
                IsActive = true
            };

            

            context.Departments.Add(tmg);
            context.Departments.Add(bdg);
            context.SaveChanges();

            var john = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "John",
                MiddleName = "C",
                LastName = "Fajardo",
                Department = bdg
            };

            var jervie = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Jervie",
                MiddleName = "C",
                LastName = "Vitriolo",
                Department = tmg
            };

            context.Employees.Add(john);
            context.Employees.Add(jervie);
            context.SaveChanges();

            var mav = new Customer
            {
                CustomerID = Guid.NewGuid(),
                CustomerName = "Maverick",
                CreditLimit = 1000,
                IsActive = true

            };

            var ag = new Customer
            {
                CustomerID = Guid.NewGuid(),
                CustomerName = "Ag",
                CreditLimit = 10000,
                IsActive = true

            };

            context.Customers.Add(mav);
            context.Customers.Add(ag);
            context.SaveChanges();
            #endregion

            #region Delete Record

            var arup = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Arup",
                MiddleName = "C",
                LastName = "Maity",
                Department = tmg
            };

            context.Employees.Add(arup);
            context.SaveChanges();

            arup = context.Employees.Find(arup.EmployeeID);
            context.Employees.Remove(arup);
            context.SaveChanges();

            


            #endregion

            #region Update Record
            var benjoe = new Employee
            {
                EmployeeID = Guid.NewGuid(),
                FirstName = "Ben",
                MiddleName = "C",
                LastName = "Guevarra",
                Department = bdg
            };

            context.Employees.Add(benjoe);
            context.SaveChanges();

            benjoe = context.Employees.Find(benjoe.EmployeeID);
            benjoe.MiddleName = "De Jesus";
            context.Employees.Update(benjoe);
            context.SaveChanges();

           


            #endregion

            #region Retrieve Records
            var departments =  from d in context.Departments //E-Sql or Entity Sql
                               select d; 
     

            var page2 = departments.Skip(40).Take(40).ToList();

            var tmgEmployees = from e in context.Employees
                               join d in context.Departments
                               on e.DepartmentID equals d.DepartmentID
                               where d.DepartmentName.Equals("Technology Management")
                            
                               orderby e.LastName descending
                               select new
                               {
                                   Fullname = e.FirstName + " " +
                                              e.MiddleName.Substring(0, 1) + ". " +
                                              e.LastName,
                                   Department = d.DepartmentName

                               };
      

            var result = tmgEmployees.ToList();

            #endregion

            context.Dispose();



        }
    }
}
