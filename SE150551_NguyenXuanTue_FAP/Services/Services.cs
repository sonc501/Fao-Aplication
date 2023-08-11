using Repository;

namespace Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly RepositoryBase<T> _repository;

        public Service(RepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(T item)
        {
            _repository.Add(item);
        }

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }

        public T GetById(object id)
        {
            return _repository.getById(id);
        }
    }
}