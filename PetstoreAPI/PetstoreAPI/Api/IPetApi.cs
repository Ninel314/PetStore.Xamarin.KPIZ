using System.Threading.Tasks;
using BinanceApiDemo.Data;
using PetstoreAPI.Data;
using Refit;

namespace PetstoreAPI.Api
{
    public interface IPetApi
    {
        [Get("/v2/pet/findByStatus")] 
        Task<ApiResponse<Pet[]>> GetAvaliablePets([Query("status")] string status = "", [Header("Accept")] string accept = "application/json");

        [Get("/v2/store/inventory")]
        Task<ApiResponse<Inventory[]>> GetStoreInventory([Header("Accept")] string accept = "application/json");
    }
}