using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Categoria> GetCategorias()
        {
            return categorias;
        }

        public Categoria GetCategoria(Guid id)
        {
            return categorias.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateCategoria(Categoria categoria)
        {
            categorias.Add(categoria);
        }

        public void UpdateCategoria(Categoria categoria)
        {
            var index = categorias.FindIndex(existingCategoria => existingCategoria.Id == categoria.Id);
            categorias[index] = categoria;
        }

        public void DeleteCategoria(Guid id)
        {
            var index = categorias.FindIndex(existingCategoria => existingCategoria.Id == id);
            categorias.RemoveAt(index);
        }
    }
}