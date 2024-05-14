namespace Skillup.TaxCalculator.Model
{
    /// <summary>
    /// To define tax slab amount and rates for female.
    /// </summary>
    public class TaxCalcForFemale : TaxCalculator
    {
        /// <summary>
        /// Constructor of TaxCalcForFemale class with its base class.
        /// </summary>
        public TaxCalcForFemale(decimal decSlab1Amount, decimal decSlab2Amount, decimal decSlab3Amount, int nSlab2TaxRate, int nSlab3TaxRate, int nSlab4TaxRate)
                               : base(decSlab1Amount, decSlab2Amount, decSlab3Amount, nSlab2TaxRate, nSlab3TaxRate, nSlab4TaxRate)
        {
        }      
    }
}