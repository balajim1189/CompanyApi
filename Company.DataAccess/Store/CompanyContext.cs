using Microsoft.EntityFrameworkCore;
using Company.Entities;

namespace Company.DataAccess.Store
{
    public class CompanyContext : DbContext
    {        
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server = localhost; database = company; username = root; password = Sriram@1998");

        }

        #region DbSet
        public virtual DbSet<Employee> Employees{ get; set; }
        public virtual DbSet<Department> Departments { get; set; }
      
        #endregion DbSet      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);               
        }
    }
}