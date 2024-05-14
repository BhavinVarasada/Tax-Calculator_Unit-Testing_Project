using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Skillup.TaxCalculator.Utility
{
    /// <summary>
    /// To check all inputs is valid or not.
    /// </summary>
    public class Utilities
    {
        #region Validate Name 
        /// <summary>
        /// To Check given Person Name is valid or not.
        /// </summary>
        /// <param name="strPersonName"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidName(string strPersonName, out string strErrorCode)
        {
            strErrorCode = string.Empty;

            // To check Name contains empty string or not.
            if (string.IsNullOrWhiteSpace(strPersonName))
            {
                // E02 for Person Name Empty
                strErrorCode = ErrorCode.E02.ToString();
                return false;
            }
            // To check name has valid length or not.
            else if (strPersonName.Length < Constant.MINIMUM_PERSON_NAME_LENGTH || strPersonName.Length > Constant.MAXIMUM_PERSON_NAME_LENGTH)
            {
                // E01 for Person name Limit
                strErrorCode = ErrorCode.E01.ToString();
                return false;
            }
            // To Check Name has Valid characteres or not.
            else if (!Regex.IsMatch(strPersonName, Constant.PATTERN_PERSON_NAME))
            {
                // E03 for Person Name Invalid Characteres.
                strErrorCode = ErrorCode.E03.ToString();
                return false;
            }
            return true;
        }
        #endregion

        #region Validate Date of Birth
        /// <summary>
        /// To Check given Date of Birth is valid or not.
        /// </summary>
        /// <param name="strDOB"></param>
        /// <param name="nAge"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidDOB(string strDOB, out int nAge, out string strErrorCode)
        {
            strErrorCode = string.Empty;
            nAge = 0;

            // To Check Date of Birth has empty string or not.
            if (string.IsNullOrWhiteSpace(strDOB))
            {
                // E06 for Date Empty
                strErrorCode = ErrorCode.E06.ToString();
                return false;
            }

            // // Try parsing the date string using the specified format.
            if (!DateTime.TryParseExact(strDOB, Constant.SLASH_DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtParsedDate) &&
                !DateTime.TryParseExact(strDOB, Constant.DASH_DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out dtParsedDate))
            {
                // E04 for Date Format Invalid
                strErrorCode = ErrorCode.E04.ToString();
                return false;
            }

            // To check Date of Birth is in range or not.
            if (dtParsedDate.Year < Constant.MINIMUM_BIRTH_YEAR_RANGE || dtParsedDate.Year > Constant.MAXIMUM_BIRTH_YEAR_RANGE)
            {
                // E05 for Date Out of Range
                strErrorCode = ErrorCode.E05.ToString();
                return false;
            }

            // To Calculate the age from the Date of Birth.           
            nAge = DateTime.Now.Year - dtParsedDate.Year;

            // Check if the birth month and day have passed this year
            if (dtParsedDate.Month > DateTime.Now.Month || (DateTime.Now.Month == DateTime.Now.Month && dtParsedDate.Day > DateTime.Now.Day))
            {
                nAge--;
            }

            return true;
        }
        #endregion

        #region Validate Gender
        /// <summary>
        /// To Check given Gender is valid or not.
        /// </summary>
        /// <param name="cGender"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidGender(char cGender, out string strErrorCode)
        {
            strErrorCode = string.Empty;

            // To Check Gender input is empty or not.
            if (cGender.Equals('\0'))
            {
                // E08 for Gender Empty
                strErrorCode = ErrorCode.E08.ToString();
                return false;
            }

            // To Check Gender is Male or Female.
            if (!Enum.TryParse(cGender.ToString(), true, out Gender _))
            {
                // E07 for Invalid Input
                strErrorCode = ErrorCode.E07.ToString();
                return false;
            }
            return true;
        }
        #endregion

        #region Validate Income Amount
        /// <summary>
        /// To Check given Income amount is valid or not.
        /// </summary>
        /// <param name="strIncome"></param>
        /// <param name="decIncome"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidIncome(string strIncome, out decimal decIncome, out string strErrorCode)
        {
            strErrorCode = string.Empty;
            decIncome = 0;

            // To Check Income has empty string or not.
            if (string.IsNullOrWhiteSpace(strIncome))
            {
                // E09 for Income Empty
                strErrorCode = ErrorCode.E09.ToString();
                return false;
            }

            // To check Income input has integer number or not and is in range or not.
            if (!decimal.TryParse(strIncome, out decIncome) || decIncome < Constant.POSITIVE_MINIMUM_RANGE)
            {
                // E07 for Invalid Input
                strErrorCode = ErrorCode.E07.ToString();
                return false;
            }
            return true;
        }
        #endregion

        #region Validate Investment Amount
        /// <summary>
        /// To Check given Investment amount is valid or not.
        /// </summary>
        /// <param name="strInvestment"></param>
        /// <param name="decIncome"></param>
        /// <param name="decInvestment"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidInvestment(string strInvestment, decimal decIncome, out decimal decInvestment, out string strErrorCode)
        {
            decInvestment = 0;
            strErrorCode = string.Empty;

            // To Check Investment has empty string or not.
            if (string.IsNullOrWhiteSpace(strInvestment))
            {
                // E10 for Investment Empty
                strErrorCode = ErrorCode.E10.ToString();
                return false;
            }

            //To check Investment input has integer number or not and is in range or not.
            if (!decimal.TryParse(strInvestment, out decInvestment) || decInvestment < Constant.POSITIVE_MINIMUM_RANGE)
            {
                // E07 for Invalid Input
                strErrorCode = ErrorCode.E07.ToString();
                return false;
            }

            // To check Investment is greater then from income or not.
            if (decInvestment > decIncome)
            {
                // E12 for Investment More Then Income
                strErrorCode = ErrorCode.E12.ToString();
                return false;
            }
            return true;
        }
        #endregion

        #region Validate HomeLoan Amount
        /// <summary>
        /// To Check given HomeLoan Amount is valid or not.
        /// </summary>
        /// <param name="strHomeLoan"></param>
        /// <param name="decIncome"></param>
        /// <param name="decInvestment"></param>
        /// <param name="decHomeLoan"></param>
        /// <param name="strErrorCode"></param>
        /// <returns></returns>
        public static bool IsValidHomeLoan(string strHomeLoan, decimal decIncome, decimal decInvestment, out decimal decHomeLoan, out string strErrorCode)
        {
            decHomeLoan = 0;
            strErrorCode = string.Empty;

            // To Check Home Loan has empty string or not.
            if (string.IsNullOrWhiteSpace(strHomeLoan))
            {
                // E11 for Home Loan Empty
                strErrorCode = ErrorCode.E11.ToString();
                return false;
            }

            // To check Home Loan input has integer number or not and is in range or not.
            if (!decimal.TryParse(strHomeLoan, out decHomeLoan) || decHomeLoan < Constant.POSITIVE_MINIMUM_RANGE)
            {
                // E07 for Invalid input
                strErrorCode = ErrorCode.E07.ToString();
                return false;
            }

            // To Check summation of investment and homeloan is grater then from income or not.
            if (decInvestment + decHomeLoan > decIncome)
            {
                // E13 for HomeLoan More Then Income
                strErrorCode = ErrorCode.E13.ToString();
                return false;
            }
            return true;
        }
        #endregion
    }
}