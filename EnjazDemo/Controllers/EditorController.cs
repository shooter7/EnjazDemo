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
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> add([FromForm]AttachmentForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attachmentUrl =form.fullName+"_" +form.carNumber+form.carEnglishChar;
            var fileUrl= DateTimeOffset.Now.ToUnixTimeMilliseconds() + "";

            Directory.CreateDirectory(Path.Combine(host, attachmentUrl));
            Directory.CreateDirectory(Path.Combine(host,attachmentUrl,fileUrl));

            var attach = new Attachment()
            {
                nationIdentity = form.nationIdentity,
                fullName = form.fullName,
                carArabicChar = form.carArabicChar,
                carEnglishChar = form.carEnglishChar,
                carNumber = form.carNumber,
                drivingLicenseNumber = form.drivingLicenseNumber,
                attachmentUrl = attachmentUrl,
                fileUrl = fileUrl
            };

            foreach (var itemFile in form.FileList)
            {
                var path = Path.Combine(host,attachmentUrl,fileUrl,itemFile.FileName);
                using (var stream=new FileStream(path,FileMode.Create))
                {
                    await itemFile.CopyToAsync(stream);
                }
            }

            _context.Attachments.Add(attach);
            _context.SaveChanges();
            return Ok();
        }


        [Route("delete-attachment")]
        public async Task<IActionResult> deleteAttachment(Guid guid)
        {
            if (guid == null)
                return BadRequest();
            var item =await _context.Attachments.FirstOrDefaultAsync(x => x.Guid == guid);
            if (item==null)
                return NotFound();
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("delete seccesfully");

        }


    }
}