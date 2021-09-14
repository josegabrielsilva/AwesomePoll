namespace AwesomePoll.Core.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        int Insert(T entity);
        int Update(T entity);
        T GetById(int id);
    }
}
