using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mountain_moment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mountain_moment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        GalleryContext db;
        private readonly ILogger<AlbumsController> _logger;

        public AlbumsController(ILogger<AlbumsController> logger, GalleryContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            return await db.Albums.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> Get(int id)
        {
            Album user = await db.Albums.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
        [HttpPost]
        public async Task<ActionResult<Album>> Post(Album album)
        {
            if (album == null)
            {
                return BadRequest();
            }

            db.Albums.Add(album);
            await db.SaveChangesAsync();
            return Ok(album);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> Delete(int id)
        {
            Album album = db.Albums.FirstOrDefault(x => x.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            db.Albums.Remove(album);
            await db.SaveChangesAsync();
            return Ok(album);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
