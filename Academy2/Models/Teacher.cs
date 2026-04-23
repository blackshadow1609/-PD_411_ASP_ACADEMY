using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy2.Models
{
    public class Teacher : Human
    {
        [Key]
        [Column(TypeName = "smallint")]
        public int teacher_id { get; set; }
        public DateOnly? work_since { get; set; } 
        [Column(TypeName = "smallmoney")]
        public decimal rate { get; set; }
    }
}