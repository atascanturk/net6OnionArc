using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net6OnionArc.Application.Repositories;
using net6OnionArc.Application.ViewModels.Products;
using net6OnionArc.Domain.Entities;
using System.Net;

namespace net6OnionArc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok();
            // await _productWriteRepository.AddRangeAsync(new()
            //  {
            //      new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //      new() { Id = Guid.NewGuid(), Name = "Product2", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //      new() { Id = Guid.NewGuid(), Name = "Product3", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 }
            //  });

            //await _productWriteRepository.SaveAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product vM_Create_Product)
        {
            if (ModelState.IsValid)
            {

            }

            await _productWriteRepository.AddAsync(new Product
            {
                Name = vM_Create_Product.Name,
                Price = vM_Create_Product.Price,
                Stock = vM_Create_Product.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (string id)
        {
            await _productWriteRepository.DeleteByIdAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }

}
