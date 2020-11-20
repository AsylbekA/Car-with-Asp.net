using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        //Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Column(TypeName = "nvarchar(25)")]
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(25, ErrorMessage = "Maximum 25 characters only.")]
        public string Surname { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}