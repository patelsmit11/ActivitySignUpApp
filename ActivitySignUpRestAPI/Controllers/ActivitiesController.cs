using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivitySignUpDAL.Models;
using ActivitySignUpDAL.Services.Interfaces;

namespace ActivitySignUpRestAPI.Controllers
{
    [Route("api/Activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        // GET: api/Activities
        [HttpGet("AllActivities")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAll()
        {
            return await _activityRepository.GetAll();
        }

        // GET: api/Activities/5
        [HttpGet("GetActivityById/{id}")]
        public async Task<ActionResult<Activity>> GetById(int id)
        {
            var activity = await _activityRepository.GetById(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        // PUT: api/Activities/5
        [HttpPut("UpdateActivity/{id}")]
        public async Task<ActionResult<Activity>> Update(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            try
            {
                return await _activityRepository.Update(activity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Activities
        [HttpPost("CreateActivity")]
        public async Task<ActionResult<Activity>> Create(Activity activity)
        {
            return await _activityRepository.Create(activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("DeleteActivity/{id}")]
        public async Task<ActionResult<Activity>> Delete(int id)
        {
            var activity = await _activityRepository.GetById(id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityRepository.Delete(activity);

            return activity;
        }

        private bool ActivityExists(int id)
        {
            return _activityRepository.GetById(id).Result != null;
        }
    }
}
