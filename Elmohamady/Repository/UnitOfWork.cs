using Elmohamady.Data;
using Elmohamady.Models;
using Elmohamady.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update;
using System.Linq.Expressions;

namespace Elmohamady.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context);
            emplyees = new EmpRepo (_context);
        }
        private readonly AppDbContext _context;


        public IRepository<Category> categories {  get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmpRepo emplyees { get; private set; }
        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
