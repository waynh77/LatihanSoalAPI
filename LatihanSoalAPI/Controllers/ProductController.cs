using LatihanSoalAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatihanSoalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public ProductController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pelanggan = await _myDbContext.MsProduct.ToListAsync();
            return Ok(pelanggan);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsyncOne(int id)
        {
            var pelanggan = await _myDbContext.MsProduct.FindAsync(id);
            return Ok(pelanggan);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MsProduct pelanggan)
        {
            _myDbContext.MsProduct.Add(pelanggan);
            await _myDbContext.SaveChangesAsync();
            return Created($"/get-pelanggan-by-id?id={pelanggan.Id}", pelanggan);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(MsProduct pelangganToUpdate)
        {
            _myDbContext.MsProduct.Update(pelangganToUpdate);
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pelangganToDelete = await _myDbContext.MsProduct.FindAsync(id);
            if (pelangganToDelete == null)
            {
                return NotFound();
            }
            _myDbContext.MsProduct.Remove(pelangganToDelete);
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

