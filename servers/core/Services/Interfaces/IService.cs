namespace ReadersCorner.Core.Services.Interfaces
{
    public interface IService<TModel>
    {
        TModel GetById(int id);
        List<TModel> GetAll();
        TModel Add(TModel model);
        TModel Update(int id, TModel model);
        bool Delete(int id);
    }
}