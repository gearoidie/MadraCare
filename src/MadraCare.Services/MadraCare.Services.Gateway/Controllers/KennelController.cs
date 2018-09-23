using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MadraCare.Services.Gateway.Controllers
{
          
    [Route("[controller]")]
    [ApiController]
    public class KennelController : ControllerBase
    {
      
        /// <summary>
        /// Returns all kennels
        /// </summary>
        /// <remarks>
        /// Sample request:   
        ///
        ///     GET /kennels
        ///
        /// </remarks>
        /// <returns>All kennels</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="500">An error occurred</response>   
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok("Test string");
        }
    }
}
