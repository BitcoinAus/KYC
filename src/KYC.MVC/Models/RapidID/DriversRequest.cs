using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace KYC.MVC.Models.RapidID
{
    public class DriversRequest
    {
        [DisplayName("Birth Date YYYY-MM-DD")]
		[RegularExpression(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))", ErrorMessage = "Invalid Birth Date")]
        public String BirthDate { get; set; }

        [DisplayName("Given Name")]
        public String GivenName { get; set; }

        [DisplayName("Family Name")]
        public String FamilyName { get; set; }

        [DisplayName("Licence Number")]
        public String LicenceNumber { get; set; }

        [DisplayName("State of Issue")]
        public String StateOfIssue { get; set; }

        public DriversRequest()
        {
        }
    }
}
