using Commons.Models.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using MyShopSystem.API.Services.Intefaceis;

namespace MyShopSystem.API.Controllers
{
    
    public class ProductController(IProductService productService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetProductListDTO>>> GetAllProduct()
        {
            var products = await productService.GetAllProduct();
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetProductDTO>> GetProduct(int Id)
        {
            var product = await productService.GetProduct(Id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<GetProductDTO>> AddProduct([FromBody] CreateProductDTO product)
        {
            var newProduct = await productService.CreateProduct(product);
            return Ok(newProduct);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] GetProductDTO updateProduct)
        {
            await productService.UpdateProduct(updateProduct);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            await productService.DeleteProduct(Id);
            return NoContent();
        }
    }
}
