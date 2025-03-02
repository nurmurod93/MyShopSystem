namespace MyShopSystem_UI.Service
{
    public class AutherticationService
    {
        private readonly HttpClient client;

        public AutherticationService(HttpClient httpClient)
        {
            this.client = httpClient;
        }
        public async Task<bool> RegisterAsync(string email, string password)
        {
            var result = await client.PostAsJsonAsync("api/account/register", new { Email = email, Password = password });
            return result.IsSuccessStatusCode;
        }
        public async Task<string?> loginAsync(string email, string password)
        {
            var response = await client.PostAsJsonAsync("api/account/login", new { Email = email, Password = password});
            if(response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            return null;
        }
    }
}
