using System;
using System.Linq;
using System.Collections.Generic;
using home_finance_categories.Entities;
using home_finance_categories.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using home_finance_categories.Dtos;

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

        [HttpGet]
        public IEnumerable<CategoriaDto> GetCategorias()
        {
            var categorias = repository.GetCategorias().Select(categoria => categoria.AsDto());
            return categorias;
        }

        // GET /categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoriaDto> GetCategoria(Guid id)
        {
            var categoria = repository.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return categoria.AsDto();
        }

        // POST /categoria
        [HttpPost]
        public ActionResult<CategoriaDto> CreateCategoria(CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = new Categoria() {
                Id = Guid.NewGuid(),
                Nome = categoriaDto.Nome,
                DataCriacao = DateTimeOffset.UtcNow
            };
            repository.CreateCategoria(categoria);

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria.AsDto());
        }

        // PUT /categorias/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategoria(Guid id, UpdateCategoriaDto categoriaDto)
        {
            var existingCategoria = repository.GetCategoria(id);

            if (existingCategoria is null)
            {
                return NotFound();
            }

            Categoria updatedCategoria = existingCategoria with {
                Nome = categoriaDto.Nome
            };

            repository.UpdateCategoria(updatedCategoria);
            return NoContent();
        }

        // DELETE /categoria/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategoria(Guid id)
        {
            var existingItem = repository.GetCategoria(id);

            if (existingItem is null) {
                return NotFound();
            }

            repository.DeleteCategoria(id);
            return NoContent();
        }
    }
}
