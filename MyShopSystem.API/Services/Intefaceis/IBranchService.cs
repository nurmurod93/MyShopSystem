using Commons.Models.BranchDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IBranchService
    {
        Task<List<GetBranchListDTO>> GetAllBranch();
        Task<GetBranchDTO> GetBranch(int Id);
        Task<GetBranchDTO> CreateBranch(CreateBranchDTO create);
        Task UpdateBranch(GetBranchDTO branch);
        Task DeleteBranch(int Id);
    }
}
