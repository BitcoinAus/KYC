using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers.API
{
    [Route("api/[controller]")]
    public class DriversController : Controller
    {
		private const string url = "https://sandbox.rapidid.com.au/dvs/driverLicence";
		private const string api_key = "075c4cccb5144349bd94035b29c387c5067375d978e9caed2d0709a8f73274ef";

        [HttpPost]
        public async Task Post(Models.RaidID.DriversRequest request)
        {
			var payload = JsonConvert.SerializeObject(request);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
			var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
			httpContent.Headers.Add("token", api_key);

            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(url, httpContent);

                // If the response contains content we want to read it!
                if (httpResponse.Content != null && httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                }
            }
        }
    }
}
