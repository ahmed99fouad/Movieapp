using Elmohamady.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Elmohamady.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get; }
        IRepository<Item> items { get; }
        IEmpRepo emplyees { get; }
        int CommitChanges();
    }
}
