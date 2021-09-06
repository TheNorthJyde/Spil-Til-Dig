using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spil_Til_Dig.Backend.Attributes;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models.DTO;
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
        protected readonly IMapper mapper;
        public GenreController(IGenreSerivce genreSerivce, IMapper mapper)
        {
            this.genreSerivce = genreSerivce;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenre()
        {
            return Ok(mapper.Map<List<GenreDTO>>(await genreSerivce.GetAllGernres()));
        }

        [HttpPost]
        [ApiKey]
        public async Task<IActionResult> CreateGenre([FromBody] List<Genre> products)
        {
            await genreSerivce.AddGenreFromCMS(products);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ApiKey]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            await genreSerivce.DeleteGenreFromCMS(id);
            return Ok();
        }
    }
}
