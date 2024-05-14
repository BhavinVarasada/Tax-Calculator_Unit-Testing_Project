using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skillup.TaxCalculator.Model;
using Skillup.TaxCalculator.Utility;

namespace Skillup.UnitTestProject
{
    /// <summary>
    /// Test Methods to Test the Testcases.
    /// </summary>
    [TestClass]
    public class TaxCalculatorTests
    {
        private TaxCalculator.TaxCalculator objTaxCalculator;

        // To Intialize the Object for Test methods.
        [TestInitialize]
        public void Initialize()
        {
            objTaxCalculator = new TaxCalculator.TaxCalculator();
        }

        [DataTestMethod]
        // 1 TestCase
        [DataRow("aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeef", "", '\0', 0, 0, 0, "E01", "Input is out of text limit", 0, 0, 0)]
        // 2 TestCase
        [DataRow("", "", '\0', 0, 0, 0, "E02", "Input not given for Name", 0, 0, 0)]
        // 3 TestCase
        [DataRow("aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeee1", "", '\0', 0, 0, 0, "E03", "Input contains invalid characters.", 0, 0, 0)]
        // 4 TestCase
        [DataRow("aaaaaaaaaabbbbbbbbb%bccccccccccdddddddddeeeeeeeeee", "", '\0', 0, 0, 0, "E03", "Input contains invalid characters.", 0, 0, 0)]
        // 5 TestCase
        [DataRow("Manak Seervi", "31/12/1899", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 6 TestCase
        [DataRow("Manak Seervi", "01/01/2011", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 7 TestCase
        [DataRow("Manak Seervi", "31/12/1909", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 8 TestCase
        [DataRow("Manak Seervi", "01/01/2001", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 9 TestCase
        [DataRow("Manak Seervi", "1899/12/31", '\0', 0, 0, 0, "E05", "Birth year is out of range.", 0, 0, 0)]
        // 10 TestCase
        [DataRow("Manak Seervi", "2011-01-01", '\0', 0, 0, 0, "E05", "Birth year is out of range.", 0, 0, 0)]
        // 11 TestCase
        [DataRow("Manak Seervi", "", '\0', 0, 0, 0, "E06", "Input not given for date of birth.", 0, 0, 0)]
        // 12 TestCase
        [DataRow("Manak Seervi", "1990-5-01", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 13 TestCase
        [DataRow("Manak Seervi", "1990-05-1", '\0', 0, 0, 0, "E04", "Date format is invalid.", 0, 0, 0)]
        // 14 TestCase
        [DataRow("Manak Seervi", "1990-05-01", 'K', 0, 0, 0, "E07", "Invalid Input", 0, 0, 0)]
        // 15 TestCase
        [DataRow("Manak Seervi", "1990-05-01", '\0', 0, 0, 0, "E08", "Input not given for gender.", 0, 0, 0)]
        // 16 TestCase
        [DataRow("Manak Seervi", "1990-05-01", 'm', -5000, 0, 0, "E07", "Invalid Input", 0, 0, 0)]
        // 17 TestCase
        [DataRow("Manak Seervi", "1990-05-01", 'M', 100000, -10000, 0, "E07", "Invalid Input", 0, 0, 0)]
        // 18 TestCase
        [DataRow("Manak Seervi", "1990-05-01", 'f', 100000, 10000, -1, "E07", "Invalid Input", 0, 0, 0)]
        // 25 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 100000, 150000, 0, "E12", "Investment cannot be more than Income.", 0, 0, 0)]
        // 26 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 100000, 50000, 70000, "E13", "Investment combined with house loan/rent cannot be more than Income.", 0, 0, 0)]
        // 27 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 100000, 50000, 5000, "", "", 54000, 46000, 0)]
        // 28 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 100000, 50000, 5000, "", "", 54000, 46000, 0)]
        // 29 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 100000, 50000, 5000, "", "", 54000, 46000, 0)]
        // 30 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 440000, 100000, 50000, "", "", 140000, 300000, 14000)]
        // 31 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 450000, 100000, 50000, "", "", 140000, 310000, 16000)]
        // 32 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 800000, 110000, 50000, "", "", 140000, 660000, 102000)]
        // 33 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 440000, 100000, 50000, "", "", 140000, 300000, 11000)]
        // 34 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 450000, 100000, 50000, "", "", 140000, 310000, 13000)]
        // 35 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 800000, 110000, 50000, "", "", 140000, 660000, 99000)]
        // 36 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 440000, 100000, 50000, "", "", 140000, 300000, 6000)]
        // 37 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'M', 450000, 100000, 50000, "", "", 140000, 310000, 8000)]
        // 38 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 800000, 110000, 50000, "", "", 140000, 660000, 94000)]
        // 39 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 450000, 100000, 0, "", "", 100000, 350000, 16000)]
        // 40 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 800000, 110000, 0, "", "", 100000, 700000, 114000)]
        // 41 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 450000, 100000, 0, "", "", 100000, 350000, 21000)]
        // 42 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 450000, 0, 50000, "", "", 40000, 410000, 28000)]
        // 43 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 800000, 0, 50000, "", "", 40000, 760000, 132000)]
        // 44 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 450000, 0, 50000, "", "", 40000, 410000, 33000)]
        // 45 TestCase
        [DataRow("Manak Seervi", "1960/05/01", 'F', 450000, 0, 0, "", "", 0, 450000, 36000)]
        // 46 TestCase
        [DataRow("Manak Seervi", "1990/05/01", 'M', 800000, 0, 0, "", "", 0, 800000, 144000)]
        // 47 TestCase
        [DataRow("Manak Seervi", "2000/05/01", 'F', 450000, 0, 0, "", "", 0, 450000, 41000)]
        // 51 TestCase
        [DataRow("Hitesh Patel", "1978/11/20", 'M', 600000, 10000, 100000, "", "", 90000, 510000, 56000)]
        // 52 TestCase
        [DataRow("Bhavin Patel", "2003/06/16", 'M', 400000, 20000, 21000, "", "", 36800, 363200, 26640)]
        // 53 TestCase
        [DataRow("Manak Seervi", "1979/07/01", 'F', 500000, 10000, 10000, "", "", 18000, 482000, 47400)]
        // 54 TestCase
        [DataRow("Manak Seervi", "1965/07/01", 'M', 160000, 100000, 10000, "", "", 108000, 52000, 0)]
        // 55 TestCase
        [DataRow("Manak Seervi", "1999/05/01", 'M', 1000000, 100000, 160000, "", "", 228000, 772000, 135600)]
        // 56 TestCase
        [DataRow("Manak Seervi", "1979/07/01", 'F', 1000000, 100000, 160000, "", "", 228000, 772000, 132600)]
        // 57 TestCase
        [DataRow("Manak Seervi", "1959/07/01", 'F', 450000, 0, 0, "", "", 0, 450000, 36000)]
        // 58 TestCase
        [DataRow("Manak Seervi", "2000/08/05", 'M', 400000, 8000, 16000, "", "", 20800, 379200, 29840)]
        // 59 TestCase
        [DataRow("Manak Seervi", "2002/10/10", 'M', 240000, 0, 0, "", "", 0, 240000, 8000)]
        // 60 TestCase
        [DataRow("Manak Seervi", "1976/02/17", 'M', 150000, 5000, 10000, "", "", 13000, 137000, 0)]
        // 61 TestCase
        [DataRow("Manak Seervi", "1954/06/21", 'M', 300000, 5000, 0, "", "", 5000, 295000, 5500)]       
        public void GeneralTestMethod(string strPersonName, string strDOB, char cGender, int nIncome, int nInvestment, int nHouseLoan,
                                      string strExpectedErrorCode, string strErrorMessage, int nNonTaxableAmount, int nTaxableAmount, int nTotalTax)
        {
            PersonalInfo objPersonalInfo = new PersonalInfo(strPersonName, strDOB, cGender);
            InvestmentInfo objInvestMentInfo = new InvestmentInfo(nIncome, nInvestment, nHouseLoan);
            string strResult = objTaxCalculator.CalculateTaxDetails(objPersonalInfo, objInvestMentInfo, out objTaxCalculator);
            Assert.AreEqual(strExpectedErrorCode, strResult, strErrorMessage);

            if (strResult == string.Empty)
            {
                Assert.AreEqual(nNonTaxableAmount, objTaxCalculator.NonTaxableAmount);
                Assert.AreEqual(nTaxableAmount, objTaxCalculator.TaxableAmount);
                Assert.AreEqual(nTotalTax, objTaxCalculator.TotalTax);
            }
        }

        [DataTestMethod]
        // 22 TestCase
        [DataRow("30&0a0", "E07", "Invalid Input")]
        // 48 TestCase
        [DataRow("", "E09", "Input not given for Income")]
        public void Method22And48(string strIncome, string strExpectedErrorCode, string strErrorMessage)
        {
            Utilities.IsValidIncome(strIncome, out _, out string strErrorCode);
            Assert.AreEqual(strExpectedErrorCode, strErrorCode, strErrorMessage);
        }

        [DataTestMethod]
        // 23 TestCase
        [DataRow("50%00a", 10000, "E07", "Invalid Input")]
        // 49 TestCase
        [DataRow("", 100000, "E10", "Input not given for Investment.")]
        public void Method23And49(string strInvestment, int nIncome, string strExpectedErrorCode, string strErrorMessage)
        {
            Utilities.IsValidInvestment(strInvestment, nIncome, out _, out string strErrorCode);
            Assert.AreEqual(strExpectedErrorCode, strErrorCode, strErrorMessage);
        }

        [DataTestMethod]
        // 24 TestCase
        [DataRow("20$0%", 100000, 10000, "E07", "Invalid Input")]
        // 50 TestCase
        [DataRow("", 100000, 450000, "E11", "Input not given for house loan/rent.")]
        public void Method24And50(string strHomeLoan, int nIncome, int nInvestment, string strExpectedErrorCode, string strErrorMessage)
        {
            Utilities.IsValidHomeLoan(strHomeLoan, nIncome, nInvestment, out _, out string strErrorCode);
            Assert.AreEqual(strExpectedErrorCode, strErrorCode, strErrorMessage);
        }
    }
}