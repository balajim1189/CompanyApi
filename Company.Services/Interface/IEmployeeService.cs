using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Entities;

namespace Company.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Employee> Create(Employee employee);

        Task<Employee> Update(Employee employee);

        Task<Employee> Delete(int employeeId);

        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int employeeId);
    }
}