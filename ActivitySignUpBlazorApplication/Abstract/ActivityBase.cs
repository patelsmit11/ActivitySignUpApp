using Microsoft.Extensions.Configuration;

namespace ActivitySignUpBlazorApplication.Abstract
{
    public abstract class ActivityBase
    {
        public string BaseUrl { get { return Configuration["AppConfig:Sites:API"]; } }
        public static IConfiguration Configuration;
    }
}
