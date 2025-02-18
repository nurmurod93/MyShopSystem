using Commons.Models.UserDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IUserService
    {
        Task<List<GetUserListDTO>> GetAllUser();
        Task<GetUserDTO> GetUser(int Id);
        Task<GetUserDTO> CreateUser(CreateUserDTO createUser);
        Task UpdateUser(GetUserDTO updateUser);
        Task DeleteUser(int Id);
    }
}
