using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivitySignUpDAL.Models;
using ActivitySignUpDAL.Services.Interfaces;

namespace ActivitySignUpRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        // GET: api/Subscriptions
        [HttpGet("AllSubscriptions")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetAll()
        {
            return await _subscriptionRepository.GetAll();
        }

        // GET: api/Subscriptions/5
        [HttpGet("GetSubscriptionById/{id}")]
        public async Task<ActionResult<Subscription>> GetById(int id)
        {
            var subscription = await _subscriptionRepository.GetById(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return subscription;
        }

        // PUT: api/Subscriptions/5
        [HttpPut("UpdateSubscription/{id}")]
        public async Task<ActionResult<Subscription>> Put(int id, Subscription subscription)
        {
            if (id != subscription.SubscriptionId)
            {
                return BadRequest();
            }

            try
            {
                return await _subscriptionRepository.Update(subscription);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Subscriptions
        [HttpPost("CreateSubscription")]
        public async Task<ActionResult<Subscription>> Post(Subscription subscription)
        {
            return await _subscriptionRepository.Create(subscription);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("DeleteSubscription/{id}")]
        public async Task<ActionResult<Subscription>> Delete(int id)
        {
            var subscription = await _subscriptionRepository.GetById(id);
            if (subscription == null)
            {
                return NotFound();
            }

            await _subscriptionRepository.Delete(subscription);

            return subscription;
        }

        private bool SubscriptionExists(int id)
        {
            return _subscriptionRepository.GetById(id).Result != null;
        }
    }
}