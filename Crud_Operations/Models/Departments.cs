using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class Departments
    {
        [Key]
        public int ID { get; set; }
        public string Department { get; set; }
    }
}
