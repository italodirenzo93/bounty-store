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

            if (_context.Bounties.Count() == 0)
            {
                _context.Bounties.Add(new Bounty
                {
                    Name = "Filthy Hands Floyd",
                    Description = "He's green and he's pissed!",
                    AliveReward = 900,
                    DeadReward = 300,
                    Captured = false
                });
                _context.SaveChanges();
            }
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
            if (bounty == null)
                return BadRequest();

            _context.Bounties.Add(bounty);
            _context.SaveChanges();

            return CreatedAtRoute("GetBounty", new { id = bounty.Id }, bounty);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Bounty bounty)
        {
            if (bounty == null || bounty.Id != id)
                return BadRequest();

            var b = _context.Bounties.FirstOrDefault(x => x.Id == id);
            if (b == null)
                return NotFound();

            b.Name = bounty.Name;
            b.Description = bounty.Description;
            b.AliveReward = bounty.AliveReward;
            b.DeadReward = bounty.DeadReward;
            b.Captured = bounty.Captured;

            _context.Bounties.Update(b);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var bounty = _context.Bounties.FirstOrDefault(x => x.Id == id);
            if (bounty == null)
            {
                return NotFound();
            }

            _context.Bounties.Remove(bounty);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}