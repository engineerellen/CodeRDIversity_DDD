using Domain.Models;
using Infra.Context;

namespace Infra.Repositories
{
    public class PessoaRepository : Repository<Pessoa>
    {
        public PessoaRepository(AppDbContext context) : base(context)
        {
        }

        public override Pessoa? GetById(int id)
        {
            var query = _context.Set<Pessoa>().Where(p => p.ID == id);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }


        public override IEnumerable<Pessoa> GetAll()
        {
            var query = _context.Set<Pessoa>();

            return query.Any() ? query.ToList() : new List<Pessoa>();
        }
    }
}
