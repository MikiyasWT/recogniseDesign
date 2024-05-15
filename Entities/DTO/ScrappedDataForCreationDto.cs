using System.ComponentModel.DataAnnotations;
namespace Entities.Dto
{
 public class ScrappedDataForCreationDto
    {


        [Required(ErrorMessage ="product name is a required field")]
        public string Title { get; set; }  
        public string Seller { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
    }
}

