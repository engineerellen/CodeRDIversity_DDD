using Domain.Interfaces;

namespace Domain.Models
{
    public class PessoaService
    {
        private readonly IRepository<Pessoa> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PessoaService(IRepository<Pessoa> repository
                           , IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public Pessoa GetByID(int id) => _repository.GetById(id);

        public List<Pessoa> GetAll() => _repository.GetAll().ToList();

        public void Save(Pessoa pessoa)
        {
            var pessoaExistente = _repository.GetById(pessoa.ID);

            if (pessoaExistente is null)
            {
                pessoaExistente = new Pessoa(pessoa.Nome, pessoa.Email);
                _repository.Save(pessoaExistente);
                _unitOfWork.Commit();
            }
        }

        public void Update(Pessoa pessoa)
        {
            var pessoaExistente = _repository.GetById(pessoa.ID);

            if (pessoaExistente is not null)
            {
                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.Email = pessoa.Email;

                _repository.Update(pessoaExistente);
                _unitOfWork.Commit();
            }
        }

        public void Delete(int ID)
        {
            var pessoaExistente = _repository.GetById(ID);

            if (pessoaExistente is not null)
            {
                _repository.Delete(pessoaExistente);
                _unitOfWork.Commit();
            }
        }
    }
}