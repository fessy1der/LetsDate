using LetsDateAPI.Data;
using LetsDateAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsDateAPI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ApplicationDbContext _ctx;

        public UsersController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users =await _ctx.Users.ToListAsync();
            return users;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user =await _ctx.Users.FindAsync(id);
            return user;
        }
    }
}
