using System.Threading.Tasks;
using PetstoreAPI.Data;

namespace PetstoreAPI.Services
{
    public interface IPetService
    {
        Task<Response<Pet[]>> FindPetsByStatus(string status);
    }
}