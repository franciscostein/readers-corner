namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IRepository<TModel>
    {
        TModel GetById(int id);
        List<TModel> GetAll();
        TModel Add(TModel entity);
        TModel Update(TModel entity);
        bool Delete(int id);
    }
}