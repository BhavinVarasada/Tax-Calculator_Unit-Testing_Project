using Skillup.TaxCalculator.Model;
using Skillup.TaxCalculator.Utility;
using System;

namespace Skillup.TaxCalculator
{
    /// <summary>
    /// Main TaxCalculator library to calculate tax.
    /// </summary>
    public class TaxCalculator
    {
        public decimal NonTaxableAmount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Property to store first TaxSlab as per the age and gender.
        /// </summary>
        private static decimal Slab1Amount { get; set; }

        /// <summary>
        /// Property to store Second TaxSlab as per the age and gender.
        /// </summary>
        private static decimal Slab2Amount { get; set; }

        /// <summary>
        /// Property to store Third TaxSlab as per the age and gender.
        /// </summary>
        private static decimal Slab3Amount { get; set; }

        /// <summary>
        /// Property to store second TaxSlab Rates as per the age and gender.
        /// </summary>
        private static int Slab2TaxRate { get; set; }

        /// <summary>
        /// Property to store Third TaxSlab Rates as per the age and gender.
        /// </summary>
        private static int Slab3TaxRate { get; set; }

        /// <summary>
        /// Property to store Fourth TaxSlab Rates as per the age and gender.
        /// </summary>
        private static int Slab4TaxRate { get; set; }

        // Default Constructor of TaxCalculator class.
        public TaxCalculator()
        {
        }

        // Constructor to set the slab amount and taxrates.
        public TaxCalculator(decimal decSlab1Amount, decimal decSlab2Amount, decimal decSlab3Amount, int nSlab2TaxRate, int nSlab3TaxRate, int nSlab4TaxRate)
        {
            Slab1Amount = decSlab1Amount;
            Slab2Amount = decSlab2Amount;
            Slab3Amount = decSlab3Amount;
            Slab2TaxRate = nSlab2TaxRate;
            Slab3TaxRate = nSlab3TaxRate;
            Slab4TaxRate = nSlab4TaxRate;
        }

        #region Calculate Tax Details
        /// <summary>
        /// To calculate the Tax Details of the user as per given input.
        /// </summary>
        /// <param name="objPersonalInfo"></param>
        /// <param name="objInvestmentInfo"></param>
        /// <param name="objTaxInfo"></param>
        /// <returns></returns>
        public string CalculateTaxDetails(PersonalInfo objPersonalInfo, InvestmentInfo objInvestmentInfo, out TaxCalculator objTaxInfo)
        {
            objTaxInfo = new TaxCalculator();

            // To check given name is valid or not.
            if (!Utilities.IsValidName(objPersonalInfo.PersonName, out string strErrorCode))
            {
                return strErrorCode;
            }

            // To check given Date of Birth is valid or not.
            if (!Utilities.IsValidDOB(objPersonalInfo.DOB, out int nAge, out strErrorCode))
            {
                return strErrorCode;
            }

            // To check given Gender is valid or not.
            if (!Utilities.IsValidGender(objPersonalInfo.Gender, out strErrorCode))
            {
                return strErrorCode;
            }

            // To check given Income is valid or not.
            if (!Utilities.IsValidIncome(objInvestmentInfo.Income.ToString(), out decimal decIncome, out strErrorCode))
            {
                return strErrorCode;
            }

            // To check given Investment is valid or not.
            if (!Utilities.IsValidInvestment(objInvestmentInfo.Investment.ToString(), decIncome, out decimal decInvestment, out strErrorCode))
            {
                return strErrorCode;
            }

            // To check given HomeLoan is valid or not.
            if (!Utilities.IsValidHomeLoan(objInvestmentInfo.HouseLoan.ToString(), decIncome, decInvestment, out decimal decHomeLoan, out strErrorCode))
            {
                return strErrorCode;
            }

            // Method call to calculate only taxable amount from total amount.
            decimal decTaxableAmount = CalcTaxableAmount(objInvestmentInfo, out decimal decNonTaxableAmount);
            objTaxInfo.TaxableAmount = decTaxableAmount;
            objTaxInfo.NonTaxableAmount = decNonTaxableAmount;

            // If age is more then limit then calculate tax as per the seniorcitizen taxslab.
            if (nAge >= Constant.AGE_LIMIT_FOR_SENIOR_CITIZEN)
            {
                new TaxCalcForSeniorCitizen(Constant.SENIOR_CITIZEN_SLAB_1_UPPER_RANGE, Constant.SENIOR_CITIZEN_SLAB_2_UPPER_RANGE, Constant.SENIOR_CITIZEN_SLAB_3_UPPER_RANGE,
                                            Constant.SENIOR_CITIZEN_SLAB_2_TAX_RATE, Constant.SENIOR_CITIZEN_SLAB_3_TAX_RATE, Constant.SENIOR_CITIZEN_SLAB_4_TAX_RATE);
            }
            // If gender is Male then calculate tax as per the Male taxslab.
            else if (Gender.M.ToString() == objPersonalInfo.Gender.ToString())
            {
                new TaxCalcForMale(Constant.MALE_SLAB_1_UPPER_RANGE, Constant.MALE_SLAB_2_UPPER_RANGE, Constant.MALE_SLAB_3_UPPER_RANGE,
                                   Constant.MALE_SLAB_2_TAX_RATE, Constant.MALE_SLAB_3_TAX_RATE, Constant.MALE_SLAB_4_TAX_RATE);
            }
            // If gender is Female then calculate tax as per the Female taxslab.
            else
            {
                new TaxCalcForFemale(Constant.FEMALE_SLAB_1_UPPER_RANGE, Constant.FEMALE_SLAB_2_UPPER_RANGE, Constant.FEMALE_SLAB_3_UPPER_RANGE,
                                     Constant.FEMALE_SLAB_2_TAX_RATE, Constant.FEMALE_SLAB_3_TAX_RATE, Constant.FEMALE_SLAB_4_TAX_RATE);
            }

            // To Calculate the totalTax as per the slab.
            objTaxInfo.TotalTax = CalcTotalTax(decTaxableAmount);
            return string.Empty;
        }
        #endregion

        #region Calculate Taxable Amount
        /// <summary>
        /// To Calculate the Total Taxable Amount.
        /// </summary>
        /// <param name="objInvestmentInfo"></param>
        /// <param name="decNonTaxableAmount"></param>
        /// <returns></returns>
        private decimal CalcTaxableAmount(InvestmentInfo objInvestmentInfo, out decimal decNonTaxableAmount)
        {
            decimal decHomeLoanExemption = (objInvestmentInfo.HouseLoan * (decimal)Constant.HOMELOAN_EXEMPTION_PERCENTAGE) / Constant.CONVERT_TO_PERCENTAGE;
            decimal decIncomeExemption = (objInvestmentInfo.Income * (decimal)Constant.INCOME_EXEMPTION_PERCENTAGE) / Constant.CONVERT_TO_PERCENTAGE;

            decimal decNonTaxable = Math.Min(decHomeLoanExemption, decIncomeExemption);
            decimal decNonTaxableInvestment = objInvestmentInfo.Investment > Constant.NON_TAXABLE_INVESTMENT ? Constant.NON_TAXABLE_INVESTMENT : objInvestmentInfo.Investment;

            decNonTaxableAmount = decNonTaxable + decNonTaxableInvestment;
            decimal decTaxableAmount = objInvestmentInfo.Income - decNonTaxableAmount;
            return decTaxableAmount;
        }
        #endregion

        #region Calculate Total Tax
        /// <summary>
        /// To Calculate Total Tax from the Taxable Amount.
        /// </summary>
        /// <param name="decTaxableAmount"></param>
        /// <returns></returns>
        private decimal CalcTotalTax(decimal decTaxableAmount)
        {
            // Array for storing SlabAmounts.
            decimal[] decarrUpperRanges = { Slab1Amount, Slab2Amount, Slab3Amount };
            // Array for Storing TaxRates.
            int[] narrTaxRates = { Slab2TaxRate, Slab3TaxRate, Slab4TaxRate };
            decimal decTotalTax = 0;

            // Main Logic for Tax Calculation.
            if (!(decTaxableAmount < decarrUpperRanges[0]))
            {
                for (int i = 0; i < decarrUpperRanges.Length; i++)
                {
                    if (decTaxableAmount < decarrUpperRanges[i])
                    {
                        decTotalTax += (decTaxableAmount * narrTaxRates[i]) / Constant.CONVERT_TO_PERCENTAGE;
                        decTaxableAmount = 0;
                    }
                    else if (decTaxableAmount > decarrUpperRanges[i])
                    {
                        if (i == 0)
                        {
                            decTaxableAmount -= decarrUpperRanges[0];
                        }
                        decimal decSlabAmount = Math.Min(decTaxableAmount, decarrUpperRanges[i + 1] - decarrUpperRanges[i]);
                        decTotalTax += decSlabAmount * narrTaxRates[i] / Constant.CONVERT_TO_PERCENTAGE;
                        decTaxableAmount -= decSlabAmount;
                    }
                }
            }
            return decTotalTax;
        }
        #endregion
    }
}