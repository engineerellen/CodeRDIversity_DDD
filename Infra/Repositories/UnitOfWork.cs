using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit() =>
            _context.SaveChanges();
    }
}