using ActivitySignUpDAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivitySignUpDAL.Services.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAll();
        Task<Subscription> GetById(int id);
        Task<Subscription> Create(Subscription subscription);
        Task<Subscription> Update(Subscription subscription);
        Task Delete(Subscription subscription);
    }
}
