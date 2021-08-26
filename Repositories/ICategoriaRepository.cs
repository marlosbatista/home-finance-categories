using System;
using System.Collections.Generic;
using home_finance_categories.Entities;

namespace home_finance_categories.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria GetCategoria(Guid id);
        IEnumerable<Categoria> GetCategorias();
        void CreateCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void DeleteCategoria(Guid id);
    }
}