using PetstoreAPI.Factories;
using PetstoreAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using PetstoreAPI.Services;

namespace PetstoreAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            On<iOS>().SetUseSafeArea(true);

            var petstoreApi = PetStoreApiFactory.Create();
            var petstoreService = new PetService(petstoreApi);
            BindingContext = new MainPageViewModel(petstoreService);
        }
    }
}
