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
    public class DepartmentService: IDepartmentService
    {
        private readonly CompanyContext _context;
        private readonly IUnitOfWork _uow;
        public DepartmentService(CompanyContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        } 
        public async Task<Department> Create(Department department)
        {
           _context.Departments
           .Add(department);
           _context.Entry(department).State = EntityState.Added;
           _context.SaveChanges();
           return department;
        }
        public async Task<Department> Delete(int departmentId)
        {
            var r = await GetDepartmentById(departmentId);
            _context.Remove(r);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return _context.Departments.Include(e=>e.Employees).FirstOrDefault(c => c.Id == departmentId);
        }
        public async Task<List<Department>> GetDepartments()
        {
            return _context.Departments.Include(e=>e.Employees).ToList();
        }
        //     try
        //     {
        //          var departments =  _context.Departments.Include(s=>s.Employees).Select(
        //              b=> new Department()
        //              {
        //                 Id = b.Id,
        //                 DepartmentName = b.DepartmentName,
        //                 Description = b.Description,
        //                 Employees = b.Employees
        //              }).ToList();
        //         var departmentsList = await _uow.Repository<Department>().ListAllAsync();

        //         return departments;
        //     }
        //     catch (System.Exception ex)
        //     {               
        //         throw ex;
        //     }
        // }
        public async Task<Department> Update(Department department)
        {
           _context.Departments.Attach(department);
           _context.Entry(department).State = EntityState.Modified;
           _context.SaveChanges();
           return department;
        }  

        
    }   
}