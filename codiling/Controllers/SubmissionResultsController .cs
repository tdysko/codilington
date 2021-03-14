using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codiling.Contexts;
using codiling.Models;
using Newtonsoft.Json;

namespace codiling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionResultsController : ControllerBase
    {
        private readonly codilingContext _context;
        private readonly JsonSerializerSettings _serializer = new JsonSerializerSettings();

        public SubmissionResultsController(codilingContext context)
        {
            _context = context;
            _serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        // GET: api/SubmissionResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubmissionResult>>> GetSubmissions()
        {
            List<SubmissionResult> languages = await _context.SubmissionResults.ToListAsync();

            return Ok(JsonConvert.SerializeObject(languages, _serializer));
        }
    }
}
