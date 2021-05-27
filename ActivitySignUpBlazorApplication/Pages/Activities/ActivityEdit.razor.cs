using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace ActivitySignUpBlazorApplication.Pages.Activities
{
    public partial class ActivityEdit
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private HttpClient HttpClient { get; set; }
        [Parameter] public int ActivityId { get; set; }
        private Activity Activity { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            if (ActivityId > 0)
            {
                Activity = await new Client(HttpClient).GetActivityByIdAsync(ActivityId);
            }
        }

        private async void HandleValidSubmit()
        {
            //ActivityId is not null, update an existing record otherwise insert a new record.
            if (ActivityId > 0)
            {
                await new Client(HttpClient).UpdateActivityAsync(Activity.ActivityId, Activity);
            }
            else
            {
                await new Client(HttpClient).CreateActivityAsync(Activity);
            }
            NavigationManager.NavigateTo("activities");
        }
    }
}
