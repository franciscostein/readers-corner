namespace ReadersCorner.Core.Repositories.Interfaces
{
    public interface IRepository<TModel>
    {
        TModel Add(TModel model);
        TModel GetById(int id);
        List<TModel> GetAll();
        TModel Update(TModel model);
        void Delete(TModel model);
        bool SaveChanges();
    }
}