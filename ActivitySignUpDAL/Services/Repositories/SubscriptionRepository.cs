using ActivitySignUpDAL.Data;
using ActivitySignUpDAL.Models;
using ActivitySignUpDAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivitySignUpDAL.Services.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ActivityDbContext _dbContext;

        public SubscriptionRepository(ActivityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subscription> Create(Subscription subscription)
        {
            _dbContext.Add(subscription);
            await _dbContext.SaveChangesAsync();
            return subscription;
        }

        public async Task Delete(Subscription subscription)
        {
            _dbContext.Remove(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Subscription>> GetAll()
        {
            return await _dbContext.Subscriptions.Include(s => s.Activity).ToListAsync();
        }

        public async Task<Subscription> GetById(int id)
        {
            return await _dbContext.Subscriptions.FirstOrDefaultAsync(f => f.SubscriptionId == id);
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _dbContext.Update(subscription);
            await _dbContext.SaveChangesAsync();
            return subscription;
        }
    }
}
