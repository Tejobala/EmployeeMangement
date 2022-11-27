using EmployeeMangement.EmployeeData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Models;

namespace EmployeeMangement.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetByIdAsync();
        Task<EmployeeModel> GetByIdAsync(int employeeId);
        Task<int> AddEmployeeAsync(EmployeeModel employeeModel);
        Task UpdateEmployeeAsync(int employeeId, EmployeeModel employeeModel);
        Task DeleteEmployeeAsync(int employeeId);
    }
}