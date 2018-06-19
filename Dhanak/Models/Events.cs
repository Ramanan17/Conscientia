using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dhanak.Models
{
    [Table("Events")]

    public class Events
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string EventName { get; set; }
        [Required]
        public Category Category { get; set; }
       
        public string OrganizerName { get; set; }
        public string OrganizerEmail { get; set; }
       
        public string OrganizerPhone { get; set; }
        public string  CoOrdinatorName { get; set; }
        public string CoOrdinatorPhone { get; set; }
        public string Description { get; set; }
    }
}
