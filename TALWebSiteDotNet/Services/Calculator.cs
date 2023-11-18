using TALWebSiteDotNet.Models;
namespace TALWebSiteDotNet.Services
{
    public static class Calculator
    {
        /// <summary>
        /// For any given individual the monthly premium is calculated using the below formula (provided by TAL):
        /// Death Premium = (Death Cover amount *Occupation Rating Factor *Age) / 1000 * 12
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public static decimal? CalculatePremium(PremiumCalculatorInputs inputs)
        {            
            var premium = (inputs.SI * inputs.OccupationRatingFactor * inputs.Age) / 1000 * 12;
            return premium;
        }
    }
}