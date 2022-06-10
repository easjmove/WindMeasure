using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindMeasureAPI.Managers;
using WindMeasureAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WindMeasureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindMeasureController : ControllerBase
    {
        private IWindMeasureManager _manager;

        public WindMeasureController(WindMeasureContext context)
        {
            //_manager = new WindMeasureManager();
            _manager = new WindMeasureManagerDB(context);
        }

        // GET: api/<WindMeasureController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<WindMeasureData>> Get([FromQuery] int minimumSpeed)
        {
            IEnumerable<WindMeasureData> result = _manager.GetAll(minimumSpeed);
            if (result.Count() > 0)
            {
                return Ok(result);
            } else if (minimumSpeed > 0)
            {
                return NotFound("No measurements fulfill your filter");
            }
            return NoContent();
        }

        // POST api/<WindMeasureController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post([FromBody] WindMeasureData newMeasure)
        {
            WindMeasureData result = _manager.Add(newMeasure);
            return Created("/" + result.Id, result);
        }
    }
}
