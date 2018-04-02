using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BountyApi.Models;

namespace BountyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BountyController : Controller
    {
        private readonly BountyContext _context;

        public BountyController(BountyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Bounty> GetAll()
        {
            return _context.Bounties.ToList();
        }

        [HttpGet("{id}", Name = "GetBounty")]
        public IActionResult GetById(long id)
        {
            var bounty = _context.Bounties.FirstOrDefault(x => x.Id == id);
            if (bounty == null)
                return NotFound();
            return new ObjectResult(bounty);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Bounty bounty)
        {
            // Check that serialization was successful
            if (bounty == null)
                return BadRequest();

            // Check if the client passed an Id
            if (bounty.Id > 0)
                ModelState.AddModelError("Id", "Model Ids are automatically generated. Do not pass an Id on creation.");

            // Validate inputs
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Add bounty
            _context.Bounties.Add(bounty);
            _context.SaveChanges();

            return CreatedAtRoute("GetBounty", new { id = bounty.Id }, bounty);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Bounty bounty)
        {
            // Check that serialization was successful
            if (bounty == null)
                return BadRequest();

            // Check that the id parameter matches the model's id
            if (bounty.Id != id)
                ModelState.AddModelError("Id", "The Id passed does not match the Id of the bounty data.");

            // Validate inputs
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Retrieve the entity to update
            var b = _context.Bounties.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return NotFound();

            // Update data
            b.Name = bounty.Name;
            b.Description = bounty.Description;
            b.AliveReward = bounty.AliveReward;
            b.DeadReward = bounty.DeadReward;
            b.Captured = bounty.Captured;

            // Persist
            _context.Bounties.Update(b);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            // Retrieve the entity to remove
            var bounty = _context.Bounties.FirstOrDefault(x => x.Id == id);
            if (bounty == null)
                return NotFound();

            // Remove it
            _context.Bounties.Remove(bounty);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}