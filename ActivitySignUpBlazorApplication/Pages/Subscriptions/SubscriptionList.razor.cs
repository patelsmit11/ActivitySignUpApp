using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ActivitySignUpBlazorApplication.Pages.Subscriptions
{
    public partial class SubscriptionList
    {
        [Inject] private HttpClient HttpClient { get; set; }
        private IEnumerable<Subscription> Subscriptions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Subscriptions = await new Client(HttpClient).AllSubscriptionsAsync();
        }
    }
}
