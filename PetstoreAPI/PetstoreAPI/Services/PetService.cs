using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PetstoreAPI.Api;
using BinanceApiDemo.Data;
using Newtonsoft.Json;
using PetstoreAPI.Data;
using Refit;

namespace PetstoreAPI.Services
{
    public class PetService : IPetService
    {
        private readonly IPetApi _petApi;

        public PetService(IPetApi petApi)
        {
            _petApi = petApi;
        }
        
        public async Task<Response<Pet[]>> FindPetsByStatus(string status)
        {
            try
            {
               var response = await _petApi.GetAvaliablePets(status);

                if (response.IsSuccessStatusCode)
                {
                    return Response<Pet[]>.Success(response.Content);
                }
                else
                    return Response<Pet[]>.Fail("failed to get pets");
            }
            catch (ApiException refitException)
            {
                // DEMO
                return Response<Pet[]>.Fail(refitException.Message);
            }
            catch (Exception exception)
            {
                return Response<Pet[]>.Fail(exception.Message);
            }
        }

        public async Task<Response<Inventory[]>> GetStoreInventory()
        {
            try
            {
                var response = await _petApi.GetStoreInventory();

                if (response.IsSuccessStatusCode)
                {
                    return Response<Inventory[]>.Success(response.Content);
                }
                else
                    return Response<Inventory[]>.Fail("failed to get pets");
            }
            catch (ApiException refitException)
            {
                // DEMO
                return Response<Inventory[]>.Fail(refitException.Message);
            }
            catch (Exception exception)
            {
                return Response<Inventory[]>.Fail(exception.Message);
            }
        }
    }
}