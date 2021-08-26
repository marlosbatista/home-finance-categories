using home_finance_categories.Dtos;
using home_finance_categories.Entities;

namespace home_finance_categories
{
    public static class Extensions {
        public static CategoriaDto AsDto(this Categoria categoria)
        {
            return new CategoriaDto {
                Id = categoria.Id,
                Nome = categoria.Nome,
                DataCriacao = categoria.DataCriacao
            };
        }
    }
}