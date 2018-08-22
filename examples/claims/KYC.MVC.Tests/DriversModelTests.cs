using System;
using Xunit;

namespace KYC.MVC.Tests
{
    public class DriversModelTests
    {
        [Fact]
        public void Should_JSON_Drivers()
        {
			Models.Drivers model = new Models.Drivers()
			{
				BirthDate = "1985-02-08",
                FamilyName = "Lee",
                GivenName = "Mary",
                LicenceNumber = "94977000",
                StateOfIssue = "ACT",
                CountryCode = "AUS"
			};

			var actual = model.ToClaim();

			//Assert.Equal(actual.Value, "a9dc32cc4b5416158dabefae23c8c6bd000841755a58e4c29e920af2705df604");

			Assert.NotEmpty(actual.Value);
        }
    }
}
