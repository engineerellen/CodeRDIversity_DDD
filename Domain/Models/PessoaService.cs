using Domain.Interfaces;

namespace Domain.Models
{
    public class PessoaService
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public void Save(Pessoa pessoa)
        {
            var pessoaExistente = _repository.GetById(pessoa.ID);

            if (pessoaExistente == null)
            {
                pessoaExistente = new Pessoa(pessoa.Nome, pessoa.Email);
                _repository.Save(pessoaExistente);
            }
            else
                _repository.Update(pessoaExistente);
        }
    }
}