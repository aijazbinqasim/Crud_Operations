using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operations.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Required")]
        public string? Description { get; set; }

        [NotMapped]
        public string? Department { get; set; }
    }
}
