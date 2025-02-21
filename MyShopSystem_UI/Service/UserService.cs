using Commons.Models.UserDTO;

namespace MyShopSystem_UI.Service
{
    public interface IUserService
    {
        public Task<List<GetUserListDTO>> GetAllUser();
        public Task<GetUserDTO> GetUser(int Id);
        public Task<GetUserDTO> CreateUser(CreateUserDTO createUser);
        public Task UpdateUser(GetUserDTO updateUser);
        public Task DeleteUser(int Id);
    }

    public class UserService(IConfiguration configuration) : IUserService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _baseUrl = configuration["BackendUrl"] + "/user";
        public async Task<GetUserDTO> CreateUser(CreateUserDTO createUser)
        {
            var response = await client.PostAsJsonAsync(_baseUrl + "/CreateUser", createUser);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetUserDTO>();
        }

        public async Task DeleteUser(int Id)
        {
            var response = await client.DeleteAsync($"{_baseUrl}/DeleteUser/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetUserListDTO>> GetAllUser()
        {
            var response = await client.GetAsync(_baseUrl + "/GetAllUser");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<GetUserListDTO>>();
            return data;
        }

        public async Task<GetUserDTO> GetUser(int Id)
        {
            var response = await client.GetAsync($"{_baseUrl}/GetUser/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<GetUserDTO>();
        }

        public async Task UpdateUser(GetUserDTO updateUser)
        {
            var response = await client.PutAsJsonAsync($"{_baseUrl}/UpdateUser", updateUser);
            response.EnsureSuccessStatusCode();
        }
    }
}
