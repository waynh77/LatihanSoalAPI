using LatihanSoalAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatihanSoalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public TransaksiController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var transaksi = await _myDbContext.Transaksi
                .AsNoTracking()
                .AsQueryable()
                .Include(e => e.Pelanggan)
                .Include(e => e.TransaksiDetail)
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                .ThenInclude(e=>e.Produk)
                .ToListAsync();
            return Ok(transaksi);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAsyncOne(int id)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            var transaksi = await _myDbContext.Transaksi
                .Where(e => e.Id == id)
                .AsNoTracking()
                .AsQueryable()
                .Include(e => e.Pelanggan)
                .Include(e => e.TransaksiDetail)
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
                .ThenInclude(e => e.Produk)
                .ToListAsync();
            return Ok(transaksi);
        }

    }
}
