using ActivitySignUpBlazorApplication.ActivitySignUpRestAPI;
using FluentValidation;

namespace ActivitySignUpBlazorApplication.DataValidators
{
    public class SubscriptionValidator : AbstractValidator<Subscription>
    {
        public SubscriptionValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("'First Name' must not be empty.").MaximumLength(255);
            RuleFor(q => q.LastName).NotEmpty().WithMessage("'Last Name' must not be empty.").MaximumLength(255);
            RuleFor(q => q.Email).EmailAddress().NotEmpty().WithMessage("'Email' must not be empty.").MaximumLength(255);
            RuleFor(q => q.ActivityId).NotEmpty().WithMessage("'Activity Type' must not be empty.");
        }
    }
}
