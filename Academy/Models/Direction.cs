using Academy.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

//using System.ComponentModel.DataAnnotations.Schema;


namespace Academy.Models
{
    [Index(nameof(direction_name), IsUnique = true)]
    public class Direction
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte direction_id { get; set; }
        [Required]
        [UniqueDirectionName(ErrorMessage = "Error!!!")]
        public string? direction_name { get; set; }
        //public override bool Equals(object? other)
        //{
        //    return this.direction_name.Equals((other as Direction).direction_name);
        //}
        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(direction_name);
        //}
    }
}
