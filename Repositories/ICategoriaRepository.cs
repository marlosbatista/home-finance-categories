using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using home_finance_categories.Entities;

namespace home_finance_categories.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetCategoriaAsync(Guid id);
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Task CreateCategoriaAsync(Categoria categoria);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(Guid id);
    }
}