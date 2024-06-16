using Services.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilSimulator.Tests
{
    [TestClass]
    public class ApiTest
    {
        private HttpClient _httpClient;
        private GetTheApi _getTheApi;

        [TestInitialize]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _getTheApi = new GetTheApi(_httpClient);
        }

        [TestMethod]
        public async Task FetchApidata_ShouldReturnRandomUser()
        {
            //ACT
            var result = await _getTheApi.FetchApiData();

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.First));
            Assert.IsFalse(string.IsNullOrEmpty(result.Last));
            Assert.IsFalse(string.IsNullOrEmpty(result.Title));

        }
    }
}
