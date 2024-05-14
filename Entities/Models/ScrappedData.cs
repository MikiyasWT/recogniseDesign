using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
 public class ScrappedData
    {
        [Column("ProductId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Product name is 60 characters.")]
        public string Title { get; set; }  

        [Required(ErrorMessage = "Product seller name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Product seller name is 60 characters.")]
        public string Seller { get; set; }

        [Range(1.0, 4000.0, ErrorMessage = "The price must be between 1.0 and 4000.0 dollars.")]
        public double Price { get; set; }


        [MaxLength(140, ErrorMessage = "Maximum length for the Product Detail is 140 characters.")]
        public string Detail { get; set; }
    }
}