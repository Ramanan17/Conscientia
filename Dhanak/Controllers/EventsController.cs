using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dhanak.Controllers.Resources;
using Dhanak.Models;
using Dhanak.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dhanak.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly DhanakDbContext context;
      

        public EventsController(DhanakDbContext context)
        {
            this.context = context;
         
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = new List<EventResource>();

            var events = await context.Events.Include(m =>m.Category).ToListAsync();
            if (events == null)
            {
                return BadRequest();
            }
            int i = 0;
            var result = new EventResource()
            {
                CategoryId = 0,
                OrganiserResource = new OrganiserResource() { Email="email"},
                CoOrdinatorResource = new CoOrdinatorResource() { Name = "name"}



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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          var e= await context.Events.Include(m=>m.Category).SingleOrDefaultAsync(m =>m.Id==id);
            if (e == null)
            {
                return NotFound();
            }
            var result = new EventResource()
            {
                CategoryId = 0,
                OrganiserResource = new OrganiserResource() { Email = "email" },
                CoOrdinatorResource = new CoOrdinatorResource() { Name = "name" }



            };
            result.EventId = e.Id;
            result.EventName = e.EventName;
            result.CategoryId = e.Category.Id;
            result.OrganiserResource.Name = e.OrganizerName;
            result.OrganiserResource.Email = e.OrganizerEmail;
            result.OrganiserResource.Phone = e.OrganizerPhone;
            result.CoOrdinatorResource.Name = e.CoOrdinatorName;
            result.CoOrdinatorResource.Phone = e.OrganizerPhone;

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          //  var e = await context.Events.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == resource.EventId);
            var c = await context.Category.SingleOrDefaultAsync(m => m.Id == resource.CategoryId);
            var e = new Events()
            {
                EventName = resource.EventName,
                Category = c,
                OrganizerName = resource.OrganiserResource.Name,
                OrganizerEmail=resource.OrganiserResource.Email,
                OrganizerPhone = resource.OrganiserResource.Phone,
                CoOrdinatorName = resource.CoOrdinatorResource.Name,
                CoOrdinatorPhone = resource.CoOrdinatorResource.Phone,




            };
           await context.AddAsync(e);
            await context.SaveChangesAsync();
            return Ok(e);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EventResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var e = await context.Events.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == id);
            var c = await context.Category.SingleOrDefaultAsync(m => m.Id == resource.CategoryId);
            e.EventName = resource.EventName;
            e.Category = c;
            e.OrganizerName = resource.OrganiserResource.Name;
            e.OrganizerEmail = resource.OrganiserResource.Email;
            e.OrganizerPhone = resource.OrganiserResource.Phone;
            e.CoOrdinatorName = resource.CoOrdinatorResource.Name;
            e.CoOrdinatorPhone = resource.CoOrdinatorResource.Phone;

            await context.SaveChangesAsync();

            return Ok(e);


        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await context.Events.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == id);
            context.Remove(e);
            await context.SaveChangesAsync();
            return Ok(id);

        }
    }
}
