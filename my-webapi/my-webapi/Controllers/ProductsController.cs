using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_webapi.Models;

namespace my_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductByID(string id) 
        {
            try
            {
                var result = products.SingleOrDefault(hh => hh.productID == Guid.Parse(id)); // Find in list products, if condition true, return product else return null
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    success = true, data = result
                });
            } catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM) 
        {
            var product = new Product
            {
                productID = Guid.NewGuid(),
                productName = productVM.productName,
                ProductPrice = productVM.ProductPrice
            };
            products.Add(product);
            return Ok(new
            {
                Success = true, Data = product
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, Product editedProd)
        {
            try
            {
                var result = products.SingleOrDefault(prod => prod.productID == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                if (id != result.productID.ToString()) 
                {
                    return BadRequest();
                }
                result.productName = editedProd.productName;
                result.ProductPrice = editedProd.ProductPrice;
                return Ok(new
                {
                    success = true, data = result
                });
            }catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = products.SingleOrDefault(prod => prod.productID == Guid.Parse(id));
                if (result == null)
                {
                    return NotFound();
                }
                products.Remove(result);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
