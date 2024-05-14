namespace Skillup.TaxCalculator.Utility
{
    /// <summary>
    /// Define all constants here.
    /// </summary>
    public class Constant
    {
        public const string PATTERN_PERSON_NAME                             = @"^[a-zA-Z ]+$";     
        public const string SLASH_DATE_FORMAT                               = "yyyy/MM/dd";
        public const string DASH_DATE_FORMAT                                = "yyyy-MM-dd";       

        public const int MINIMUM_PERSON_NAME_LENGTH                         = 1;
        public const int MAXIMUM_PERSON_NAME_LENGTH                         = 50;
        public const int MINIMUM_BIRTH_YEAR_RANGE                           = 1900;
        public const int MAXIMUM_BIRTH_YEAR_RANGE                           = 2010;
        public const int POSITIVE_MINIMUM_RANGE                             = 0;
        public const int CONVERT_TO_PERCENTAGE                              = 100;
        public const int AGE_LIMIT_FOR_SENIOR_CITIZEN                       = 60;
        public const double HOMELOAN_EXEMPTION_PERCENTAGE                   = 80;
        public const double INCOME_EXEMPTION_PERCENTAGE                     = 20;
        public const decimal NON_TAXABLE_INVESTMENT                         = 100000;

        public const decimal MALE_SLAB_1_UPPER_RANGE                        = 160000;
        public const decimal MALE_SLAB_2_UPPER_RANGE                        = 300000;
        public const decimal MALE_SLAB_3_UPPER_RANGE                        = 500000;
        public const int     MALE_SLAB_2_TAX_RATE                           = 10;
        public const int     MALE_SLAB_3_TAX_RATE                           = 20;
        public const int     MALE_SLAB_4_TAX_RATE                           = 30;

        public const decimal FEMALE_SLAB_1_UPPER_RANGE                      = 190000;
        public const decimal FEMALE_SLAB_2_UPPER_RANGE                      = 300000;
        public const decimal FEMALE_SLAB_3_UPPER_RANGE                      = 500000;
        public const int     FEMALE_SLAB_2_TAX_RATE                         = 10;
        public const int     FEMALE_SLAB_3_TAX_RATE                         = 20;
        public const int     FEMALE_SLAB_4_TAX_RATE                         = 30;

        public const decimal SENIOR_CITIZEN_SLAB_1_UPPER_RANGE              = 240000;
        public const decimal SENIOR_CITIZEN_SLAB_2_UPPER_RANGE              = 300000;
        public const decimal SENIOR_CITIZEN_SLAB_3_UPPER_RANGE              = 500000;
        public const int     SENIOR_CITIZEN_SLAB_2_TAX_RATE                 = 10;
        public const int     SENIOR_CITIZEN_SLAB_3_TAX_RATE                 = 20;
        public const int     SENIOR_CITIZEN_SLAB_4_TAX_RATE                 = 30;
    }
}