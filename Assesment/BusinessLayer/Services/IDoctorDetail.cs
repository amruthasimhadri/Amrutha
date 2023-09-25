using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace BusinessLayer.Services
{
    internal interface IDoctorDetail
    {
        

Task<IEnumerable<DoctorDetail>> GetAll(Expression<Func<DoctorDetail, bool>> expression = null, List<string> Include = null);

        Task<int> Create(DoctorDetail DoctorDetail);

        Task<DoctorDetail> Edit(long? id);







        Task<int> Edit(long? id, DoctorDetail DoctorDetail);

        Task<DoctorDetail> Delete(long? id, List<string> includes = null, Expression<Func<DoctorDetail, bool>> expression = null);

        Task<int> DeleteConfirmed(long? id, string? name = null);

        Task<DoctorDetail> Details(long? id, List<string> includes = null, Expression<Func<DoctorDetail, bool>> expression = null);





        bool Exists(long? id, Expression<Func<DoctorDetail, bool>> expression = null);
    }
}