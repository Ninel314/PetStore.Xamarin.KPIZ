using System.Threading.Tasks;
using PetstoreAPI.Data;
using PetstoreAPI.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace PetstoreAPI
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IPetService _petService;

        private Pet[] _pets;
        private string _error;
        private  string _status = "available";

        public MainPageViewModel(IPetService petService)
        {
            _petService = petService;

            Task.Run(InitAsync);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }


        public Pet[] Pets
        {
            get => _pets;
            set => SetProperty(ref _pets, value);
        }

        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        public async Task InitAsync()
        {
            var ticketsResponse = await _petService.FindPetsByStatus(_status);
            if (ticketsResponse.IsSuccessful)
            {
                Pets = ticketsResponse.Data;
            }
            else
            {
                Error = ticketsResponse.Error;
            }
        }
    }
}