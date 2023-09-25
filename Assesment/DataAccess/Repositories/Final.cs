using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Final : IFinal
    {
        public Task<int> Create(TModel appointment)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Delete(long? id, List<string> includes = null, Expression<Func<TModel, bool>> expression = null, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteConfirmed(long? id, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Details(long? id, List<string> includes = null, Expression<Func<TModel, bool>> expression = null, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Edit(long? id, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> Edit(long? id, TModel appointment, string? name = null)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long? id, Expression<Func<TModel, bool>> expression = null, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>> expression = null, List<string> Include = null)
        {
            throw new NotImplementedException();
        }

        public TModel GetData(string disease)
        {
            throw new NotImplementedException();
        }
    }
}
