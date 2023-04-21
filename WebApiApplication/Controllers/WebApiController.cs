using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApplication.DataDbContext;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class WebApiController : ControllerBase
    {
        private readonly WebDataDbContext _context;

        public WebApiController(WebDataDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void AddRequest(Request request)
        {
            _context.Add(request);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteRequest(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Request> GetRequests() => _context.Requests;

        [HttpGet("{id}")]
        public Request GetRequestId(int id)
        {
            return (Request)_context.Requests.Where(request => request.Id == id);
        }

        [HttpPut]
        public void UpdateRequest(Request request)
        {            
            _context.Entry(request).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}