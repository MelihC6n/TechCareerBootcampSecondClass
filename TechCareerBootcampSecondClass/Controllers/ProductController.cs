using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerBootcampSecondClass.Models;

namespace TechCareerBootcampSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<Product> products;
        public ProductController()
        {
            if (products == null)
            {
            products = new List<Product>();
            products.Add(new Product(1, "Sprite", 100,new Category(1,"Drink")));
            products.Add(new Product(2, "Beef", 200,new Category(2,"Meat")));
            products.Add(new Product(3, "Ice Tea", 300,new Category(1,"Drink")));
            products.Add(new Product(4, "Kitkat", 400,new Category(3,"Chocolate")));
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id= products.Count + 1; 
            products.Add(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok(product);
        }
    }
}
