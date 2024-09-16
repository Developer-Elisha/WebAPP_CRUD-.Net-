using System.ComponentModel.DataAnnotations;

namespace CRUD_AspDotNet.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
