using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using ActivitySignUpBlazorApplication.Shared.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ActivitySignUpBlazorApplication.Pages.Activities
{
    public partial class ActivityList
    {
        [Inject] private HttpClient HttpClient { get; set; }
        private List<Activity> Activities { get; set; }
        protected DeleteConfirmBase DeleteConfirmation { get; set; }
        private int ActivityId { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Activities = (await new Client(HttpClient).AllActivitiesAsync()).ToList();
        }

        protected void DeleteClick(int activityId)
        {
            ActivityId = activityId;
            DeleteConfirmation.Show();
        }

        protected async void ConfirmDeleteClick(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await new Client(HttpClient).DeleteActivityAsync(ActivityId);
                var activity = Activities.FirstOrDefault(q => q.ActivityId == ActivityId);
                if (activity != null)
                {
                    Activities.Remove(activity);
                }
                StateHasChanged();
            }
        }
    }
}
