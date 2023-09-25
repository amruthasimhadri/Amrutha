using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IFinal
    {
        Task<int> Create(TModel appointment);
        Task<TModel> Edit(long? id, string? name = null);
        Task<int> Edit(long? id, TModel appointment, string? name = null);
        Task<TModel> Delete(long? id, List<string> includes = null, Expression<Func<TModel, bool>> expression = null, string? name = null);
        Task<int> DeleteConfirmed(long? id, string? name = null);
        Task<TModel> Details(long? id, List<string> includes = null, Expression<Func<TModel, bool>> expression = null, string? name = null);
        bool Exists(long? id, Expression<Func<TModel, bool>> expression = null, string? name = null);
        TModel GetData(string disease);
        Task<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>> expression = null, List<string> Include = null);
    }
}