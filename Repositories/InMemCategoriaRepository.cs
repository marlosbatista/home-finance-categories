using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using home_finance_categories.Entities;

namespace home_finance_categories.Repositories
{
    public class InMemCategoriaRepository : ICategoriaRepository
    {
        private readonly List<Categoria> categorias = new()
        {
            new Categoria { Id = Guid.NewGuid(), Nome = "Lazer", DataCriacao = DateTimeOffset.UtcNow },
            new Categoria { Id = Guid.NewGuid(), Nome = "Educação", DataCriacao = DateTimeOffset.UtcNow },
            new Categoria { Id = Guid.NewGuid(), Nome = "Casa", DataCriacao = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await Task.FromResult(categorias);
        }

        public async Task<Categoria> GetCategoriaAsync(Guid id)
        {
            var categoria = categorias.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(categoria);
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            categorias.Add(categoria);
            await Task.CompletedTask;
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            var index = categorias.FindIndex(existingCategoria => existingCategoria.Id == categoria.Id);
            categorias[index] = categoria;
            await Task.CompletedTask;
        }

        public async Task DeleteCategoriaAsync(Guid id)
        {
            var index = categorias.FindIndex(existingCategoria => existingCategoria.Id == id);
            categorias.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}