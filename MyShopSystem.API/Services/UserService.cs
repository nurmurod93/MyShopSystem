using Commons.Models.UserDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class UserService(ApplicationDbContext context) : IUserService
    {
        public async Task<GetUserDTO> CreateUser(CreateUserDTO createUser)
        {
            var newEntity = new User()
            {
                Id = createUser.Id,
                Username = createUser.Username,
                PasswordHash = createUser.PasswordHash,
                Role = createUser.Role,
            };
            var entry = await context.Users.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetUserDTO
            {
                Id = newEntity.Id,
                Username = newEntity.Username,
                PasswordHash = newEntity.PasswordHash,
                Role = newEntity.Role,
            };
        }

        public async Task DeleteUser(int Id)
        {
            var data = await context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (data != null)
            {
                context.Users.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public Task<List<GetUserListDTO>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDTO> GetUser(int Id)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<GetUserListDTO>> GetAllUser()
        //{
        //    var data = await context.Users.Include(u => u.Company).ToListAsync();
        //    if (data is null && !data.Any()) return [];
        //    var allUser = new List<GetUserListDTO>();
        //    foreach (var user in data)
        //    {
        //        allUser.Add(new GetUserListDTO
        //        {
        //            Id = user.Id,
        //            Username = user.Username,
        //            PasswordHash = user.PasswordHash,
        //            Role = user.Role,
        //        });
        //    }
        //    return allUser;
        //}

        //public async Task<GetUserDTO> GetUser(int Id)
        //{
        //    var data = await context.Users.Include(u => u.Company).FirstorDefaultAsync(u => u.Id == Id);
        //    if (data != null)
        //    {
        //        return new GetUserDTO()
        //        {
        //            Id = data.Id,
        //            Username = data.Username,
        //            PasswordHash = data.PasswordHash,
        //            Role = data.Role,
        //        };
        //    }
        //    else
        //        throw new Exception("Not found!");
        //}

        public async Task UpdateUser(GetUserDTO updateUser)
        {
            var old = await context.Users.FirstOrDefaultAsync(u => u.Id == updateUser.Id);
            if (old != null)
            {
                old.Username = updateUser.Username;
                old.PasswordHash = updateUser.PasswordHash;
                old.Role = updateUser.Role;

                context.Users.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
