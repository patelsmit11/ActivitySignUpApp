using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using FluentValidation;

namespace ActivitySignUpBlazorApplication.DataValidators
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(q => q.ActivityName).NotEmpty().WithMessage("'Activity Name' must not be empty.").MaximumLength(255);
            RuleFor(q => q.ActivityType).NotEmpty().WithMessage("'Activity Type' must not be empty.");
        }
    }
}
