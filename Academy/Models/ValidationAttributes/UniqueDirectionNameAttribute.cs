//using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;
//using Academy.Data;

//namespace Academy.Models.ValidationAttributes

//{
//    public class UniqueDirectionNameAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return ValidationResult.Success;
//            string directionName = value.ToString();
//            IDbContextFactory<AcademyContext> dbContextFactory = validationContext.GetService<IDbContextFactory<AcademyContext>>();
//            if (dbContextFactory == null) return new ValidationResult("Error!!!");
//            using (var context = dbContextFactory.CreateDbContext())
//            {
//                var exists = context.Directions.Any(d => d.direction_name.ToLower() == directionName.ToLower());
//                if (exists) return new ValidationResult(ErrorMessage ?? $"Driection '{directionName}' already exists");
//            }
//            return ValidationResult.Success;
//        }

//    }
//}
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Academy.Data;

namespace Academy.Models.ValidationAttributes
{
    public class UniqueDirectionNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) { return ValidationResult.Success; }

            string directionName = value.ToString()!;
            var dbContextFactory = validationContext.GetService<IDbContextFactory<AcademyContext>>();
            if (dbContextFactory == null) { return new ValidationResult("Database context factory not available"); }

            using var context = dbContextFactory.CreateDbContext();
            if (context == null) { return new ValidationResult("Database context not available"); }
            var exists = context.Directions
                .Any(d => d.direction_name != null &&
                          d.direction_name.ToLower() == directionName.ToLower());

            if (exists)
            {
                return new ValidationResult(ErrorMessage ?? $"Direction '{directionName}' already exists");
            }

            return ValidationResult.Success;
        }
    }
}