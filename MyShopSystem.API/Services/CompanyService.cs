using Commons.Models.CompanyDTO;
using Microsoft.EntityFrameworkCore;
using MyShopSystem.API.Data;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Services
{
    public class CompanyService(ApplicationDbContext context) : ICompanyService
    {
        public async Task<GetCompanyDTO> CreateCompany(CreateCompanyDTO company)
        {
            var newEntity = new Company()
            {
                Name = company.Name,
            };

            var entry = await context.Companies.AddAsync(newEntity);
            await context.SaveChangesAsync();

            return new GetCompanyDTO()
            {
                Name = newEntity.Name,
            };
        }

        public async Task DeleteCompany(int Id)
        {
            var data = await context.Companies.FirstOrDefaultAsync(x => x.Id == Id);
            if(data != null)
            {
                context.Companies.Remove(data);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<GetCompanyListDTO>> GetAllCompany()
        {
            var data = await context.Companies.Include(a => a.Branches).ToListAsync();
            if (data is null && !data.Any()) return [];
            var allCompanyDTO = new List<GetCompanyListDTO>();
            foreach (var companys in data)
            {
                allCompanyDTO.Add(new GetCompanyListDTO
                {
                    Id = companys.Id,
                    Name = companys.Name,
                });
            }
            return allCompanyDTO;
        }

        public async Task<GetCompanyDTO> GetCompany(int Id)
        {
            var data = await context.Companies.Include(c => c.Branches).FirstOrDefaultAsync(a => a.Id == Id);
            if (data != null)
            {
                return new GetCompanyDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                };
            }
            else
                throw new Exception("Not found!");
        }

        public async Task UpdateCompany(GetCompanyDTO company)
        {
            var old = await context.Companies.FirstOrDefaultAsync(a => a.Id == company.Id);
            if(old != null)
            {
                old.Name = company.Name;

                context.Companies.Update(old);
                await context.SaveChangesAsync();
            }
        }
    }
}
