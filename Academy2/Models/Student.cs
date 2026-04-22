using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy2.Models
{
    public class Student:Human
    {
        [Key]
        [Required]
        [ForeignKey(nameof(Group))]
        public int group { get; set; }

        // Nav.properties

        public Group? Group { get; set; }
    }
}
