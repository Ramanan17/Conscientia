using System.ComponentModel.DataAnnotations.Schema;

namespace Dhanak.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


    }
}