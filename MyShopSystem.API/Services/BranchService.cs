using Commons.Models.BranchDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class BranchService(ApplicationDbContext context) : IBranchService
    {
        public async Task<GetBranchDTO> CreateBranch(CreateBranchDTO create)
        {
            var newEntity = new Branch()
            {
                Name = create.Name,
                Location = create.Location,
                CompanyId = create.CompanyId,
            };

            var entry = await context.Branches.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetBranchDTO()
            {
                Id = newEntity.Id,
                Name = newEntity.Name,
                Location = newEntity.Location,
            };
        }

        public async Task DeleteBranch(int Id)
        {
            var data = await context.Branches.FirstOrDefaultAsync(b => b.Id == Id);
            if(data != null)
            {
                context.Branches.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetBranchListDTO>> GetAllBranch()
        {
            var data = await context.Branches.Include(b => b.Company).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allBranch = new List<GetBranchListDTO>();

            foreach(var branches  in data)
            {
                allBranch.Add(new GetBranchListDTO
                {
                    Id = branches.Id,
                    Name = branches.Name,
                    Location = branches.Location,
                });
            }
            return allBranch;
        }

        public async Task<GetBranchDTO> GetBranch(int Id)
        {
            var data = await context.Branches.Include(b => b.Company).FirstOrDefaultAsync(a => a.Id == Id);
            if (data != null)
            {
                return new GetBranchDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Location = data.Location,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateBranch(GetBranchDTO branch)
        {
            var old = await context.Branches.FirstOrDefaultAsync(f => f.Id == branch.Id);
            if (old != null)
            {
                old.Name = branch.Name;
                old.Location = branch.Location;

                context.Branches.Remove(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
