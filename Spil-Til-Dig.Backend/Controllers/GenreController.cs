using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreSerivce genreSerivce;

        public GenreController(IGenreSerivce genreSerivce)
        {
            this.genreSerivce = genreSerivce;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromBody] List<Genre> products)
        {
            await genreSerivce.AddGenreFromCMS(products);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            await genreSerivce.DeleteGenreFromCMS(id);
            return Ok();
        }
    }
}
