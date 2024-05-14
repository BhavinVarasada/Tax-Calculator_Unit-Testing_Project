﻿namespace Skillup.TaxCalculator.Model
{
    /// <summary>
    /// To define tax slab amount and rates for senior citizen.
    /// </summary>
    public class TaxCalcForSeniorCitizen : TaxCalculator
    {
        /// <summary>
        /// Constructor of TaxCalcForSeniorCitizen class with its base class.
        /// </summary>
        public TaxCalcForSeniorCitizen(decimal decSlab1Amount, decimal decSlab2Amount, decimal decSlab3Amount, int nSlab2TaxRate, int nSlab3TaxRate, int nSlab4TaxRate)
                                     : base(decSlab1Amount, decSlab2Amount, decSlab3Amount, nSlab2TaxRate, nSlab3TaxRate, nSlab4TaxRate)
        {
        }      
    }
}