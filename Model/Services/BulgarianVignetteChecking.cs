using System.Text.Json;
using VignetteSystem.Model.Interfaces;

namespace VignetteSystem.Model.Services
{
    public class BulgarianVignetteChecking : ICheckVignette
    {
        private readonly HttpClient _httpClient;

        public BulgarianVignetteChecking(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Vignette> ConnectToAPIAsync(string api)
        {
            try
            {
                // Example URL and content; replace with actual URL and content
                //place the input plate number in the placeholder
                var url = $"{api}/";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var vignetteResponse = JsonSerializer
                                          .Deserialize<VignetteResponse>(responseData);
                    if (vignetteResponse.vignette is null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Response", "Inactive", "OK");
                        return null;
                    }

                    return vignetteResponse.vignette;

                }
                else
                {
                    // Handle unsuccessful response
                    // Log or throw an exception based on status code
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // Log the exception or rethrow it as needed
                throw new Exception("An error occurred while connecting to the API", ex);
            }
        }
    }

}
