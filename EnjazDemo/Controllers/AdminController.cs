using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnjazDemo.Models;
using EnjazDemo.Forms;
using Cipher = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace EnjazDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
//    [Authorize]
    public class AdminController : ControllerBase
    {

        private readonly EnjazDemoContext _context;

        public AdminController(EnjazDemoContext db)
        {
            _context = db;
        }

        [HttpPost]
        [Route("create-user")]
        public  async Task<IActionResult> CreateUser([FromBody]CreateUserForm userForm)
        {
            if (!ModelState.IsValid)
                BadRequest(ModelState);
            var user = new UserModel()
            {
                username = userForm.Username,
                password = Cipher.HashPassword(userForm.Password),
                Role = userForm.Role
            };
            _context.UserModels.Add(user);
            _context.SaveChanges();
            return Ok(user.Guid.ToString());
        }


        [HttpPost]
        [Route("delete-user")]
        public async Task<IActionResult> delete(Guid guid)
        {
            if (guid == null)
                return BadRequest();
            var user = await _context.UserModels.FirstOrDefaultAsync(x => x.Guid == guid);
            if (user == null)
                return NotFound();
            _context.Entry(user).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("seccesfully delete");
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> getAll(int start,int end)
        {

            List<UserModel> list = await _context.UserModels.Where(x=>x.Role!="admin").Skip(start).Take(end).AsNoTracking().ToListAsync();
            if (list.Count == 0)
                return NotFound();
            return Ok(list);
        }
    }
}