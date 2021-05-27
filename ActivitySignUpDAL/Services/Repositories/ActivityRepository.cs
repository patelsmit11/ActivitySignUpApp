using ActivitySignUpDAL.Data;
using ActivitySignUpDAL.Models;
using ActivitySignUpDAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivitySignUpDAL.Services.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityDbContext _dbContext;

        public ActivityRepository(ActivityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Activity> Create(Activity activity)
        {
            _dbContext.Add(activity);
            await _dbContext.SaveChangesAsync();
            return activity;
        }

        public async Task Delete(Activity activity)
        {
            activity.Deleted = true;
            await Update(activity);
        }

        public async Task<List<Activity>> GetAll()
        {
            return await _dbContext.Activities.Where(t => !t.Deleted).ToListAsync();
        }

        public async Task<Activity> GetById(int id)
        {
            return await _dbContext.Activities.FirstOrDefaultAsync(f => f.ActivityId == id && !f.Deleted);
        }

        public async Task<Activity> Update(Activity activity)
        {
            _dbContext.Update(activity);
            await _dbContext.SaveChangesAsync();
            return activity;
        }
    }
}
