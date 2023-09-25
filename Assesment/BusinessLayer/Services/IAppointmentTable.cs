using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace BusinessLayer.Services
{
    internal interface I
    {
        

Task<IEnumerable<AppointmentTable>> GetAll(Expression<Func<AppointmentTable, bool>> expression = null, List<string> Include = null);

        Task<int> Create(AppointmentTable AppointmentTable);

        Task<AppointmentTable> Edit(long? id);







        Task<int> Edit(long? id, AppointmentTable AppointmentTable);

        Task<AppointmentTable> Delete(long? id, List<string> includes = null, Expression<Func<AppointmentTable, bool>> expression = null);

        Task<int> DeleteConfirmed(long? id, string? name = null);

        Task<AppointmentTable> Details(long? id, List<string> includes = null, Expression<Func<AppointmentTable, bool>> expression = null);





        bool Exists(long? id, Expression<Func<AppointmentTable, bool>> expression = null);
    }
}