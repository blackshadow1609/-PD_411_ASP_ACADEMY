using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy2.Models
{
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Важно!
        [Column(TypeName = "SMALLINT")]
        public int discipline_id { get; set; }

        [Required]
        [StringLength(150)]
        public string discipline_name { get; set; } = string.Empty;  // Убрал ? и добавил инициализацию

        [Required]
        [Column(TypeName = "TINYINT")]
        [Range(1, 255)]
        public int number_of_lessons { get; set; }

        // Navigation property
        public virtual ICollection<TeacherDisciplineRelation> TeachersRelations { get; set; } = new List<TeacherDisciplineRelation>();
    }
}