using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Carr
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Column(TypeName = "nvarchar(25)")]
        [Display(Name = "Model")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        public string Model { get; set; }

        //[Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "This Field is required.")]
        public decimal Price { get; set; }
    }
}