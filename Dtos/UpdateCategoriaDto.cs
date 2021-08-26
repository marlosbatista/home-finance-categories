using System.ComponentModel.DataAnnotations;

namespace home_finance_categories
{
    public record UpdateCategoriaDto
    {
        [Required]
        public string Nome { get; set; }
    }
}