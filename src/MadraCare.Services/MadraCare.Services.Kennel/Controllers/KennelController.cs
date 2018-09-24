using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadraCare.Models;
using MadraCare.Services.Kennel.Store;
using Microsoft.AspNetCore.Mvc;

namespace MadraCare.Services.Kennel.Controllers
{
    [Route ("[controller]")]
    [ApiController]
    public class KennelController : ControllerBase
    {
        private readonly IKennelRepo _kennelRepo;

        public KennelController (IKennelRepo kennelRepo)
        {
            _kennelRepo = kennelRepo;
        }
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
        [Route("")]
        public async Task<IActionResult> Get ()
        {
            return Ok (await _kennelRepo.GetAllKennels ());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get (Guid id)
        {
            var kennel = await _kennelRepo.GetKennel (id);
            
            if (kennel == null)
                return NotFound ();

            return Ok (kennel);
        }

        /// <summary>
        /// Creates a new Kennel
        /// </summary>
        /// <remarks>
        /// Sample request:   
        ///
        ///     POST /Kennels
        ///     {
        ///         "name":"somename"
        ///     }
        ///
        /// </remarks>
        /// <returns>The created kennel</returns>
        /// <response code="201">Returns the newly created item</response>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post ([FromBody] Models.Kennel kennel)
        {
            var savedKennel = await _kennelRepo.Add (kennel);

            return Created ("https://localhost/", savedKennel);
        }
    }
}