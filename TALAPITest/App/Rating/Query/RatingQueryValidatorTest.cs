using FluentValidation.TestHelper;
using NUnit.Framework;
using TALWebAPI.App.Rating.Queries;

namespace TALAPITest.App.Rating.Query
{
    [TestFixture]
    class RatingQueryValidatorTest
    {
        private readonly RatingQueryValidator _ratingQueryValidator;
        public RatingQueryValidatorTest()
        {
            _ratingQueryValidator = new RatingQueryValidator();
        }

        /// <summary>
        /// Tests that 0 or negative occupation id should not be accepted (ShouldHaveValidationErrorFor).
        /// </summary>
        /// <param name="occupationId">The Occupation id passed by the test case.</param>        
        [TestCase(0)]
        [TestCase(-1)]
        public void RatingQueryValidator_OccupationIdOutsideRange_HasValidation(int occupationId)
        {
            var model = new RatingQuery() { OccupationId = occupationId };
            var result = _ratingQueryValidator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.OccupationId);
        }

        /// <summary>
        /// Tests that no validation error should be thrown if the occupation id is within the range.
        /// </summary>
        /// <param name="occupationId">The occupation id integer as passed by the test case.</param>        
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(10000000)]
        [TestCase(2147483647)]
        public void RatingQueryValidator_OccupationIdWithinRange_ShouldNotHaveValidationError(int occupationId)
        {
            var model = new RatingQuery() { OccupationId = occupationId };
            var result = _ratingQueryValidator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.OccupationId);
        }
    }
}
