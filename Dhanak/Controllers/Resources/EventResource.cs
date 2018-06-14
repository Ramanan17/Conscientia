using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dhanak.Controllers.Resources
{
    public class EventResource
    {
        public int EventId { get; set; }
        
        public string EventName { get; set; }
    
        public int CategoryId { get; set; }

        public OrganiserResource OrganiserResource { get; set; }

        public CoOrdinatorResource CoOrdinatorResource { get; set; }
       
       
    }
}
