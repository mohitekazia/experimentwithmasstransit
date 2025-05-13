using Entities;
using ExperimentMasstransit.DTO;
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


        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(StreamedFiles),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
           var repository= this._streamingRepository.GetRepository<StreamedFiles>();
           return Ok(await Task.Run(()=> repository.Get(s => s.Id == id)));
        }


        [HttpPost]
        public async Task<int> Post([FromBody]StreamedFiles files)
        {
            var repository = this._streamingRepository.GetRepository<StreamedFiles>();
            await Task.Run(() => repository.Insert(files));
            return await _streamingRepository.SaveAsync();
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<int> Put([FromRoute]int id, StreamFileObject file)
        {
            var repository = this._streamingRepository.GetRepository<StreamedFiles>();
            var streamFile= repository.Get(s=>s.Id == id);
            if (streamFile != null)
            {
                streamFile.FileName = file.FileName;
                await Task.Run(() => repository.Update(streamFile));
            }

            return await _streamingRepository.SaveAsync();

        }




    }
}
