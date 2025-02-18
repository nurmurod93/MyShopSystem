using Commons.Models.WarehouseDTO;

namespace MyShopSystem.API.Services.Intefaceis
{
    public interface IWarehouceService
    {
        Task<List<GetWarehouseListDTO>> GetAllWarehouse();
        Task<GetWarehouseDTO> GetWarehouse(int Id);
        Task<GetWarehouseDTO> CreateWarehouse(CreateWarehouseDTO createWarehouse);
        Task UpdateWarehouse(GetWarehouseDTO updateWarehouse);
        Task DeleteWarehouse(int Id);
    }
}
