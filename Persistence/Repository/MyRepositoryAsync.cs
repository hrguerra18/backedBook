
using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public MyRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
