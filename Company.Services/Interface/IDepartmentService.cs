using System.Collections.Generic;
using System.Threading.Tasks;
using Company.Entities;

namespace Company.Services.Interface
{
    public interface IDepartmentService
    {
        Task<Department> Create(Department department);

        Task<Department> Update(Department department);

        Task<Department> Delete(int departmentId);

        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int departmentId);
    }
}