using FluentValidation;
namespace TALWebAPI.App.Rating.Queries
{
    public class RatingQueryValidator : AbstractValidator<RatingQuery>
    {
        public RatingQueryValidator()
        {
            RuleFor(x => x.OccupationId)
                .NotEmpty()
                .InclusiveBetween(1, 2147483647).WithMessage("Occupation id must be an integer value of the available range.");
        }
    }
}
