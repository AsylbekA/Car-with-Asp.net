using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        //[Column(TypeName = "nvarchar(25)")]
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}