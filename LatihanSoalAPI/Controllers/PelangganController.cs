using LatihanSoalAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatihanSoalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelangganController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public PelangganController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pelanggan = await _myDbContext.MsPelanggan.ToListAsync();
            return Ok(pelanggan);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsyncOne(int id)
        {
            var pelanggan = await _myDbContext.MsPelanggan.FindAsync(id);
            return Ok(pelanggan);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MsPelanggan pelanggan)
        {
            _myDbContext.MsPelanggan.Add(pelanggan);
            await _myDbContext.SaveChangesAsync();
            return Created($"/get-pelanggan-by-id?id={pelanggan.Id}", pelanggan);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(MsPelanggan pelangganToUpdate)
        {
            _myDbContext.MsPelanggan.Update(pelangganToUpdate);
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pelangganToDelete = await _myDbContext.MsPelanggan.FindAsync(id);
            if (pelangganToDelete == null)
            {
                return NotFound();
            }
            _myDbContext.MsPelanggan.Remove(pelangganToDelete);
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
