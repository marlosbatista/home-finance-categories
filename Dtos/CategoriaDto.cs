using System;

namespace home_finance_categories.Dtos
{
    public record CategoriaDto
    {
        public Guid Id { get; init; }
        public string Nome { get; set; }
        public DateTimeOffset DataCriacao { get; init; }
    }
}