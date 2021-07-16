using System;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }
        
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);

            if (thing == null) return NotFound();
            return Ok(thing);
        }

        private ActionResult<AppUser> Ok(AppUser thing)
        {
            throw new NotImplementedException();
        }

        private ActionResult<AppUser> NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
                var thing = _context.Users.Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
        }

        private ActionResult<string> StatusCode(int v1, string v2)
        {
            throw new NotImplementedException();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }

        private ActionResult<string> BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}