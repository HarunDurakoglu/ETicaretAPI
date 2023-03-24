using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.Controllers
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
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 50},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 10, CreatedDate = DateTime.UtcNow, Stock = 500},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 1000, CreatedDate = DateTime.UtcNow, Stock = 5000}
            });

            await _productWriteRepository.SaveAsync();
        }

    }
}
