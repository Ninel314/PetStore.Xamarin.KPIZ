using PetstoreAPI.Api;
using Refit;

namespace PetstoreAPI.Factories
{
    public static class PetStoreApiFactory
    {
        private const string PetApiUrl = "https://petstore.swagger.io";
        
        public static IPetApi Create()
        {
            return RestService.For<IPetApi>(PetApiUrl);
        }
    }
}