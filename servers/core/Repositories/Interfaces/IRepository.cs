namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}