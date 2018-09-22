using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KYC.MVC.Models.RaidID
{
    public class PassportRequest
    {
        [DisplayName("Birth Date YYYY-MM-DD")]
		[RegularExpression(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))", ErrorMessage = "Invalid Birth Date")]
        public String BirthDate { get; set; }

        [DisplayName("Given Name")]
        public String GivenName { get; set; }

        [DisplayName("Middle Name")]
        public String MiddleName { get; set; }

        [DisplayName("Family Name")]
        public String FamilyName { get; set; }

        [DisplayName("Travel Document Number")]
        public String TravelDocumentNumber { get; set; }

        public String Gender { get; set; }

        public PassportRequest()
        {
        }
    }
}
