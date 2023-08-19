namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IRepository<TModel>
    {
        TModel GetById(int id);
        List<TModel> GetAll();
        TModel Add(TModel model);
        TModel Update(TModel model);
        bool Delete(int id);
    }
}