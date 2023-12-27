using Elmohamady.Models;

namespace Elmohamady.Repository.Base
{
    public interface IEmpRepo : IRepository<Employee>
    {
        void setPayRoll(Employee employee);

        decimal getSalary(Employee employee);

    }
}
