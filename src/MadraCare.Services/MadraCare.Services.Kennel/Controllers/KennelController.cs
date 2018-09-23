using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MadraCare.Models;

namespace MadraCare.Services.Kennel.Controllers
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok(new List<MadraCare.Models.Kennel>(){ new MadraCare.Models.Kennel{
                Name = "Test Kennel"
            }});
        }
    }
}
