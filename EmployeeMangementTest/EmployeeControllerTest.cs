using EmployeeMangement.EmployeeData;
using EmployeeMangement.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tasks.Controllers;
using Tasks.Models;
using Xunit;

namespace EmployeeMangementTest
{
    public class EmployeeControllerTest
    {
        EmployeeController _controller;
        IEmployeeRepository _repository;
        EmployeeContext _context;

        public EmployeeControllerTest()
        {
            _repository = new EmployeeRepository(_context);
            _controller = new EmployeeController(_repository);
        }
        [Fact]
        public void GetAllTest()
        {
            var result = _controller.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Employee>>(list.Value);

            var employeeList = list.Value as List<EmployeeModel>;
            Assert.Equal(4,employeeList.Count);
        }
    }
}
