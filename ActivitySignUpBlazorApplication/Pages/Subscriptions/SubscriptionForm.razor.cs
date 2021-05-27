using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ActivitySignUpBlazorApplication.Pages.Subscriptions
{
    public partial class SubscriptionForm
    {
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        private Subscription Subscription { get; set; } = new();
        private IEnumerable<Activity> Activities { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Load all activities
            Activities = await new Client(HttpClient).AllActivitiesAsync();
        }

        private async void HandleValidSubmit()
        {
            await new Client(HttpClient).CreateSubscriptionAsync(Subscription);
            NavigationManager.NavigateTo("subscriptions");
        }
    }
}
