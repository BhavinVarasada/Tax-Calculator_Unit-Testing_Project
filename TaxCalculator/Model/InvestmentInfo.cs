namespace Skillup.TaxCalculator.Model
{
    /// <summary>
    /// To get and set the Investment info of the user.
    /// </summary>
    public class InvestmentInfo
    {
        /// <summary>
        /// Property for User Income.
        /// </summary>
        public decimal Income { get; set; }

        /// <summary>
        /// Property for User Investment.
        /// </summary>
        public decimal Investment { get; set; }

        /// <summary>
        /// Property for User HouseLoan.
        /// </summary>
        public decimal HouseLoan { get; set; }

        /// <summary>
        /// Constructor for set the properties of Investment info class.
        /// </summary>
        /// <param name="decIncome"></param>
        /// <param name="decInvestment"></param>
        /// <param name="decHouseloan"></param>
        public InvestmentInfo(decimal decIncome, decimal decInvestment, decimal decHouseloan)
        {
            Income = decIncome;
            Investment = decInvestment;
            HouseLoan = decHouseloan;
        }
    }
}
