using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dhanak.Controllers.Resources;
using Dhanak.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dhanak.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly DhanakDbContext context;


        public CategoryController(DhanakDbContext context)
        {
            this.context = context;

        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await context.Category.ToListAsync();
            
            if (category == null)
            {
                return BadRequest();
            }


            return Ok(category);
        }
        [HttpGet("values/{id}")]
        public async Task<IActionResult> GetParticular(int id)
        {
            var category= await context.Category.SingleOrDefaultAsync(c => c.Id==id);
            return Ok(category);
        }
        // GET api/<controller>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var events =await context.Events.Include(m => m.Category).Where(m => m.Category.Id == id).ToListAsync();
            var results = new List<EventResource>();
            if (events == null)
            {
                return BadRequest();
            }
            int i = 0;
            var result = new EventResource()
            {
                CategoryId = 0,
                Organiser= new OrganiserResource() { Email = "email" },
                CoOrdinator = new CoOrdinatorResource() { Name = "name" }



            };
            foreach (var e in events)

            {
                result.EventId = e.Id;
                result.EventName = e.EventName;
                result.CategoryId = e.Category.Id;
                result.Organiser.Name = e.OrganizerName;
                result.Organiser.Email = e.OrganizerEmail;
                result.Organiser.Phone = e.OrganizerPhone;
                result.CoOrdinator.Name = e.CoOrdinatorName;
                result.CoOrdinator.Phone = e.OrganizerPhone;
                result.Description = e.Description;
                results.Add(result);
                i++;


            }

            return Ok(results);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
