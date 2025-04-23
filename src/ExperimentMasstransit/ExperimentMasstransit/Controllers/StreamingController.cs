using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ExperimentMasstransit.Controllers
{
    [Route("api/stream")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        public readonly IUnitofWork _streamingRepository;

        public StreamingController(
            IUnitofWork streamingRepository
            )
        {
            this._streamingRepository = streamingRepository;
        }

        [Route("streams/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(StreamedFiles),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
           var repository= this._streamingRepository.GetRepository<StreamedFiles>();
           return Ok(await Task.Run(()=> repository.Get(s => s.Id == id)));
        }

        public 


    }
}
