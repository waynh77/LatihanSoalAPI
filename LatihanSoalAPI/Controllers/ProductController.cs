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
        [Route("Save")]
        public async Task<ProcessResultT<MsProduct>> Save([FromBody] MsProduct Model)
        {
            var processResult = new ProcessResultT<MsProduct>();

            try
            {
                if (Model.Id == 0)
                {
                    _myDbContext.MsProduct.Add(Model);

                }
                else
                {
                    _myDbContext.MsProduct.Update(Model);
                }
                await _myDbContext.SaveChangesAsync();
                processResult.InsertSucceed();
            }
            catch (Exception e)
            {
                processResult.SetException(e);
            }

            return processResult;
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

        [HttpPost]
        [Route("Delete")]
        public async Task<ProcessResultT<MsProduct>> Delete([FromBody] MsProduct Model)
        {
            var processResult = new ProcessResultT<MsProduct>();

            try
            {
                var productToDelete = await _myDbContext.MsProduct.FindAsync(Model.Id);
                if (productToDelete == null)
                {
                    processResult.DeleteFailed();
                    return processResult;
                }

                _myDbContext.MsProduct.Remove(productToDelete);
                await _myDbContext.SaveChangesAsync();
                processResult.DeleteSucceed();
            }
            catch (Exception e)
            {
                processResult.SetException(e);
            }

            return processResult;
        }
    }
}

