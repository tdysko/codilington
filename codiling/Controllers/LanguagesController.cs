using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codiling.Contexts;
using codiling.Models;
using Newtonsoft.Json;

namespace codiling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly codilingContext _context;
        private readonly JsonSerializerSettings _serializer = new JsonSerializerSettings();

        public LanguagesController(codilingContext context)
        {
            _context = context;
            _serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        // GET: api/Submissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            List<Language> languages = await _context.Languages.ToListAsync();

            return Ok(JsonConvert.SerializeObject(languages, _serializer));
        }
    }
}
