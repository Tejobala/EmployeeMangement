using EmployeeMangement.EmployeeData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Reflection.Metadata.BlobBuilder;

namespace EmployeeMangement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetByIdAsync()
        {

            var records = await _context.Employee.Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary,
                Location = x.Location,
                Department = x.Department,
                Qualification = x.Qualification,
                Created = x.Created,
                Updated = x.Updated,
            }).ToListAsync();
            return records;
        }
        public async Task<EmployeeModel> GetByIdAsync(int employeeId)
        {
            var records = await _context.Employee.Where(x => x.Id == employeeId).Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary,
                Location = x.Location,
                Department = x.Department,
                Qualification = x.Qualification,
                Created = x.Created,
                Updated = x.Updated,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<int> AddEmployeeAsync(EmployeeModel employeeModel)
        {
            var book = new Employee()
            {
                Name = employeeModel.Name,
                Salary = employeeModel.Salary,
                Location = employeeModel.Location,
                Department = employeeModel.Department,
                Qualification = employeeModel.Qualification,
                Created = DateTime.Now,
            };
            _context.Employee.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateEmployeeAsync(int employeeId, EmployeeModel employeeModel)
        {
            var employee = await _context.Employee.FindAsync(employeeId);
            if (employee != null)
            {
                employee.Name = employeeModel.Name;
                employee.Salary = employeeModel.Salary;
                employee.Location = employeeModel.Location;
                employee.Department = employeeModel.Department;
                employee.Qualification = employeeModel.Qualification;
                employee.Updated = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = new Employee()
            {
                Id = employeeId
            };
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

    }
}