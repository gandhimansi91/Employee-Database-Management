using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }

        public List<Employee> GetEmployees()
        {
            var lstEmployees = _SqlServerContext.Employees.ToList();
            return lstEmployees;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _SqlServerContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public Employee AddEmployee(Employee employee) 
        {
            _SqlServerContext.Employees.Add(employee);
            _SqlServerContext.SaveChanges();
            return employee;
        }
    }

}
