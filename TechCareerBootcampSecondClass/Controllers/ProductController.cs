using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerBootcampSecondClass.Models;

namespace TechCareerBootcampSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> products;
        //add 4 products to the list
        public ProductController()
        {
            products = new List<Product>();
            products.Add(new Product(1, "Sprite", 100,new Category(1,"Drink")));
            products.Add(new Product(2, "Beef", 200,new Category(2,"Meat")));
            products.Add(new Product(3, "Ice Tea", 300,new Category(1,"Drink")));
            products.Add(new Product(4, "Kitkat", 400,new Category(4,"Chocolate")));
        }
               
        Product product1 = new Product(1, "Product1", 100,new Category(1,"a"));


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

        //delete product by id
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
