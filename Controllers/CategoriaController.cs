using System;
using System.Linq;
using System.Collections.Generic;
using home_finance_categories.Entities;
using home_finance_categories.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using home_finance_categories.Dtos;
using System.Threading.Tasks;

namespace home_finance_categories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaRepository repository;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
        {
            var categorias = (await repository.GetCategoriasAsync())
                                              .Select(categoria => categoria.AsDto());
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss)")}: Retrieved {categorias.Count()} categorias");

            return categorias;
        }

        // GET /categoria/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaAsync(Guid id)
        {
            var categoria = await repository.GetCategoriaAsync(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return categoria.AsDto();
        }

        // POST /categoria
        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> CreateCategoriaAsync(CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = new Categoria() {
                Id = Guid.NewGuid(),
                Nome = categoriaDto.Nome,
                DataCriacao = DateTimeOffset.UtcNow
            };
            await repository.CreateCategoriaAsync(categoria);

            return CreatedAtAction(nameof(GetCategoriaAsync), new { id = categoria.Id }, categoria.AsDto());
        }

        // PUT /categorias/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoriaAsync(Guid id, UpdateCategoriaDto categoriaDto)
        {
            var existingCategoria = await repository.GetCategoriaAsync(id);

            if (existingCategoria is null)
            {
                return NotFound();
            }

            Categoria updatedCategoria = existingCategoria with {
                Nome = categoriaDto.Nome
            };

            await repository.UpdateCategoriaAsync(updatedCategoria);
            return NoContent();
        }

        // DELETE /categoria/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria(Guid id)
        {
            var existingItem = await repository.GetCategoriaAsync(id);

            if (existingItem is null) {
                return NotFound();
            }

            await repository.DeleteCategoriaAsync(id);
            
            return NoContent();
        }
    }
}