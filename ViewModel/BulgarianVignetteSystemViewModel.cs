using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VignetteSystem.Model.Interfaces;
using VignetteSystem.Model.Services;

namespace VignetteSystem.ViewModel
{
    public partial class BulgarianVignetteSystemViewModel : ObservableObject
    {
        private readonly ICheckVignette _bulgarianVignetteChecking;

        [ObservableProperty]
        private string _plateNumber;

        private IEnumerable<string> _list_of_contries = new List<string> { "Bulgaria" };

        [ObservableProperty]
        private ObservableCollection<string> countries;

        public BulgarianVignetteSystemViewModel(ICheckVignette bulgarianVignetteChecking)
        {
            _bulgarianVignetteChecking = bulgarianVignetteChecking;
            Countries = new ObservableCollection<string>(_list_of_contries);
        }

        public BulgarianVignetteSystemViewModel()
        {
            
        }
            
        [RelayCommand]
        private async Task ActivateApi()
        {
            try
            {
                var response = await _bulgarianVignetteChecking.ConnectToAPIAsync(
                          $"https://check.bgtoll.bg/check/vignette/plate/BG/{PlateNumber}");

                if (response is not null)
                {
                    await App.Current.MainPage.DisplayAlert("Response", response.status, "OK");

                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        
    }
}
