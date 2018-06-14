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
            return Ok();
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
                OrganiserResource = new OrganiserResource() { Email = "email" },
                CoOrdinatorResource = new CoOrdinatorResource() { Name = "name" }



            };
            foreach (var e in events)

            {

                result.EventName = e.EventName;
                result.CategoryId = e.Category.Id;
                result.OrganiserResource.Name = e.OrganizerName;
                result.OrganiserResource.Email = e.OrganizerEmail;
                result.OrganiserResource.Phone = e.OrganizerPhone;
                result.CoOrdinatorResource.Name = e.CoOrdinatorName;
                result.CoOrdinatorResource.Phone = e.OrganizerPhone;
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
