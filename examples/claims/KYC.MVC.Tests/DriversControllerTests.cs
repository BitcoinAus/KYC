using System;
using Xunit;
using System.Threading.Tasks;

namespace KYC.MVC.Tests
{
    public class DriversControllerTests
    {
        [Fact]
        public async Task Should_Validate_Drivers()
        {
			Controllers.API.DriversController controller = new Controllers.API.DriversController();

			Models.RaidID.DriversRequest request = new Models.RaidID.DriversRequest() 
            { 
                BirthDate="1985-02-08", 
                GivenName = "Mary", 
                FamilyName = "Lee", 
                LicenceNumber = "94977000", 
                StateOfIssue = "ACT" 
            };

			await controller.Post(request);
        }
    }
}