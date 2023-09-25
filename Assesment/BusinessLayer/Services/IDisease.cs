using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace BusinessLayer.Services
{
    internal interface IDisease
    {
        
Task<IEnumerable<Disease>> GetAll(Expression<Func<Disease, bool>> expression = null, List<string> Include = null);

        Task<int> Create(Disease Disease);

        Task<Disease> Edit(long? id);







        Task<int> Edit(long? id, Disease Disease);

        Task<Disease> Delete(long? id, List<string> includes = null, Expression<Func<Disease, bool>> expression = null);

        Task<int> DeleteConfirmed(long? id, string? name = null);

        Task<Disease> Details(long? id, List<string> includes = null, Expression<Func<Disease, bool>> expression = null);





        bool Exists(long? id, Expression<Func<Disease, bool>> expression = null);
    }
}