using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnjazDemo.Models;
using EnjazDemo.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace EnjazDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,editor")]
    public class EditorController : ControllerBase
    {
        private readonly EnjazDemoContext _context;
        private readonly String host = Path.Combine(Directory.GetCurrentDirectory() , "Attachment");

        public EditorController(EnjazDemoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult add([FromBody] AttachmentForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attach = new Attachment()
            {
                nationIdentity = form.nationIdentity,
                fullName = form.fullName,
                carArabicChar = form.carArabicChar,
                carEnglishChar = form.carEnglishChar,
                carNumber = form.carNumber,
                drivingLicenseNumber = form.drivingLicenseNumber
            };

            

            _context.Attachments.Add(attach);
            _context.SaveChanges();
            return Ok();

        }

    }
}