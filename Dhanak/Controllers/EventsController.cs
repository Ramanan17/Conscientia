using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dhanak.Controllers.Resources;
using Dhanak.Models;
using Dhanak.Persistence;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var results = new List<EventResource>();

            var events = await context.Events.Include(m =>m.Category).ToListAsync();
            if (events == null)
            {
                return BadRequest();
            }
            int i = 0;
           

            foreach (var e in events)

          {
              var result = new EventResource()
              {
                  CategoryId = 0,
                  Organiser = new OrganiserResource() { Email = "email" },
                  CoOrdinator = new CoOrdinatorResource() { Name = "name" }



              };
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

            return Ok(events);


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
                Organiser = new OrganiserResource() { Email = "email" },
                CoOrdinator = new CoOrdinatorResource() { Name = "name" }



            };
            result.EventId = e.Id;
            result.EventName = e.EventName;
            result.CategoryId = e.Category.Id;
            result.Organiser.Name = e.OrganizerName;
            result.Organiser.Email = e.OrganizerEmail;
            result.Organiser.Phone = e.OrganizerPhone;
            result.CoOrdinator.Name = e.CoOrdinatorName;
            result.CoOrdinator.Phone = e.OrganizerPhone;
            result.Description = e.Description;

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
                OrganizerName = resource.Organiser.Name,
                OrganizerEmail=resource.Organiser.Email,
                OrganizerPhone = resource.Organiser.Phone,
                CoOrdinatorName = resource.CoOrdinator.Name,
                CoOrdinatorPhone = resource.CoOrdinator.Phone,
                Description = resource.Description




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
            e.OrganizerName = resource.Organiser.Name;
            e.OrganizerEmail = resource.Organiser.Email;
            e.OrganizerPhone = resource.Organiser.Phone;
            e.CoOrdinatorName = resource.CoOrdinator.Name;
            e.CoOrdinatorPhone = resource.CoOrdinator.Phone;
            e.Description = resource.Description;

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
