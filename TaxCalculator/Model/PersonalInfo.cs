namespace Skillup.TaxCalculator.Model
{
    /// <summary>
    /// To Get and Set the personal info of the user.
    /// </summary>
    public class PersonalInfo
    {
        /// <summary>
        /// Property for Person Name
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Property for Person Date of Birth
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// Property for Person gender
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Constructor to set the property of PersonalInfo class.
        /// </summary>
        /// <param name="strPersonName"></param>
        /// <param name="strDOB"></param>
        /// <param name="cGender"></param>
        public PersonalInfo(string strPersonName, string strDOB, char cGender)
        {
            PersonName = strPersonName;
            DOB = strDOB;
            Gender = cGender;
        }
    }
}