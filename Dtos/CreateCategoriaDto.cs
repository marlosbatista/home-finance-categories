using System.ComponentModel.DataAnnotations;

namespace home_finance_categories
{
    public record CreateCategoriaDto
    {
        [Required]
        public string Nome { get; init; }
    }
}