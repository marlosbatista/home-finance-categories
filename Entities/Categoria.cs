using System;

namespace home_finance_categories.Entities
{
    public record Categoria
    {
        public Guid Id { get; init; }
        public string Nome { get; set; }
        public DateTimeOffset DataCriacao { get; init; }
    }
}