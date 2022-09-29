using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //Dependency injection to get data from the database
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Endpoint to get all the users in the database
        //The api calls will be asynchronous

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
        {
          return await _context.Users.ToListAsync();    
        }

        //Endpoint to get a specfic user in the database
        //The calls in here are also async

        //api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id)
        {
          return await _context.Users.FindAsync(id);  
 
        }


    }
}