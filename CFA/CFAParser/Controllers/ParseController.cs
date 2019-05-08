using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Services;

namespace CFAParser.Controllers
{
    public class ParseController : ApiController
    {
        private IParseService _parseService;

        public ParseController(IParseService parseServicecs)
        {
            _parseService = parseServicecs;
        }

        // POST: api/Parse
        [HttpPost]
        [Route("api/Parse")]
        public IHttpActionResult Post(ParseIOS value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _parseService.SetInput(value.value);
            try
            {
                var group = _parseService.ParseGroup();
                Contents content = new Contents(group.Score(0), group.CharCount);
                return Ok(content);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
