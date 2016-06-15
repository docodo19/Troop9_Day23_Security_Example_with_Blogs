using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotDog.Services;
using Microsoft.AspNetCore.Identity;
using HotDog.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HotDog.API
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IBlogService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        public BlogController(
            IBlogService service, 
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: api/blog/getactiveblogs
        [HttpGet]
        [Route("getactiveblogs")]
        public IActionResult GetActiveBlogs()
        {
            var blogs = _service.GetAllActiveBlogs();
            return Ok(blogs);
        }

        // GET: api/blog/getuserblogs
        [HttpGet]
        [Route("getuserblogs")]
        [Authorize]
        public IActionResult GetUserBlogs()
        {
            var userId = _userManager.GetUserId(this.User);
            var blogs = _service.GetUserBlogs(userId);
            return Ok(blogs);
        }

        // GET: api/blog/getallblogs
        [HttpGet]
        [Route("getallblogs")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAllBlogs()
        {
            var blogs = _service.GetAllBlogs();
            return Ok(blogs);
        }






        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
