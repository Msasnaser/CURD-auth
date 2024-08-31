using Microsoft.CodeAnalysis.Elfie.Model;
using System.ComponentModel.DataAnnotations;

namespace CURD.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
