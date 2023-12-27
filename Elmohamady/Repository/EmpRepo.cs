using Elmohamady.Data;
using Elmohamady.Models;
using Elmohamady.Repository.Base;

namespace Elmohamady.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(AppDbContext context) : base(context)
        {
            context = _context;

        }
        private readonly AppDbContext  _context;

        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
