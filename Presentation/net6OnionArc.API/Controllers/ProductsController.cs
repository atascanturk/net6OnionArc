using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net6OnionArc.Application.Repositories;
using net6OnionArc.Application.RequestParameters;
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
        readonly private IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IWebHostEnvironment webHostEnvironment)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;   
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {

            var totalCount = _productReadRepository.GetAll(false).Count();

            var products = _productReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.ModifiedDate
            }).Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToList();

            return Ok(new
            {
                 totalCount,
                 products
            });
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(
                _webHostEnvironment.WebRootPath,"resource/product-images");

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath =Path.Combine(uploadPath, $"{file.Name.Replace(Path.GetExtension(file.FileName),"")}_{DateTime.Now.ToString("yyyyMMddhhmm")}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath,FileMode.Create,FileAccess.Write,FileShare.None,1024 * 1024, useAsync:false);

                await file.CopyToAsync(fileStream);

               await fileStream.FlushAsync();
            }

            return Ok();
        }
    }

}
