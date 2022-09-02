using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DataAccess.Store;
using Company.Entities;
using Company.Services.Interface;
using Company.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Company.Services.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly CompanyContext _context;
        private readonly IUnitOfWork _uow;
        public EmployeeService(CompanyContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        } 
        public async Task<Employee> Create(Employee employee)
        {
           _context.Employees.Add(employee);
           _context.Entry(employee).State = EntityState.Added;
           _context.SaveChanges();
           return employee;
        }
        public async Task<Employee> Delete(int employeeId)
        {
            var r = await GetEmployeeById(employeeId);
            _context.Remove(r);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(c => c.Id == employeeId);
        }
        public async Task<List<Employee>> GetEmployees()
        {
            //return _context.Employees.Include(d=> d.Department);
             try
            {
                 var employees =  _context.Employees.Include(s=>s.Department).Select(
                     b=> new Employee()
                     {
                        Id = b.Id,
                        EmployeeName = b.EmployeeName,
                        Age = b.Age,
                        Salary = b.Salary,
                        DepartmentId = b.DepartmentId,
                        Department = b.Department
                     }).ToList();
                var employeesList = await _uow.Repository<Employee>().ListAllAsync();

                return employees;
            }
            catch (System.Exception ex)
            {               
                throw ex;
            }
        }
        public async Task<Employee> Update(Employee employee)
        {
           _context.Employees.Attach(employee);
           _context.Entry(employee).State = EntityState.Modified;
           _context.SaveChanges();
           return employee;
        }       
    }   
}