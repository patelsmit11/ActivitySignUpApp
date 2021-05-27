using ActivitySignUpDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivitySignUpDAL.Services.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task<Activity> Create(Activity activity);
        Task<Activity> Update(Activity activity);
        Task Delete(Activity activity);
    }
}
