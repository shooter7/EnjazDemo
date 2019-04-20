using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EnjazDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnjazDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,editor,viewer")]
    public class ViewerController : ControllerBase
    {

        private readonly EnjazDemoContext _context;
        private readonly String host = Path.Combine(Directory.GetCurrentDirectory(), "Attachment");

        public ViewerController(EnjazDemoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-all-attachments")]
        public async Task<IActionResult> getAllAttachments(int start, int end)
        {
            List<AttachmentDto> list = new List<AttachmentDto>();
            var attachmentList = await _context.Attachments.Skip(start).Take(end).AsNoTracking().ToArrayAsync();
            foreach (var itme in attachmentList)
            {

                var imgsPath = Path.Combine(host, itme.attachmentUrl, itme.fileUrl);

                list.Add(new AttachmentDto()
                {
                    Guid = itme.Guid,
                    fullName = itme.fullName,
                    nationIdentity = itme.nationIdentity,
                    carNumber = itme.carNumber,
                    carArabicChar = itme.carArabicChar,
                    carEnglishChar = itme.carEnglishChar,
                    drivingLicenseNumber = itme.drivingLicenseNumber,
                    imgs = Directory.GetFiles(imgsPath)
                });

            }

            return Ok(list);
        }

        [Route("download")]
        public async Task<IActionResult> download(string path)
        {
            //            var imgs = Directory.GetFiles(host);
            //            var path = Path.Combine(host, "catogery.png");
            //            var path = Path.Combine(host, name);

            //            path = path.Replace("\\\\", "\\");

            var memory = new MemoryStream();
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }

            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
            };
        }
    }
}