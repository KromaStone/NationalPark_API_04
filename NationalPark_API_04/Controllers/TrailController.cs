using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationalPark_API_04.IRepository;
using NationalPark_API_04.Model;
using NationalPark_API_04.Model.DTOs;

namespace NationalPark_API_04.Controllers
{
    [Route("api/Trail")]
    [ApiController]
    public class TrailController : Controller
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository trailRepository, IMapper mapper)    
        {
            _trailRepository = trailRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult GetTrails()
        {
            return Ok(_trailRepository.GetTrails().Select(_mapper.Map<Trail, TrailDTO>));

        }

        [HttpGet("{trailId:int}",Name ="GetTrail")]
        public IActionResult GetTrail(int trailId)
        {
            var trail= _trailRepository.GetTrail(trailId);
            if (trail == null) return NotFound();
            var trailDto = _mapper.Map<TrailDTO>(trail);
            return Ok(trailDto);
        }

        [HttpPost]
        public IActionResult CreateTrail([FromBody] TrailDTO trailDTO)
        {
            if (trailDTO == null) return BadRequest();
            if(_trailRepository.TrailExists(trailDTO.Id))
            {
                ModelState.AddModelError("", "Trail in Db!!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (!ModelState.IsValid) return BadRequest();
            var trail = _mapper.Map<Trail>(trailDTO);
            if(!_trailRepository.CreateTrail(trail))
            {
                ModelState.AddModelError("",$"Sonmething went wrong while save data : {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("GetTrail", new { trailId = trail.Id },trail);  
        }
        [HttpPut]
        public IActionResult UpdateTrail([FromBody]TrailDTO trailDTO )
        {
            if (trailDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var trail =_mapper.Map<Trail>(trailDTO);
            if(!_trailRepository.UpdateTrail(trail))
            {
                ModelState.AddModelError("", $"Sonmething went wrong while update data : {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
        [HttpDelete("{trailId:int}")]
        public IActionResult DeleteTrail(int trailId)
        {
            if (!_trailRepository.TrailExists(trailId)) return NotFound();
            var trail = _trailRepository.GetTrail(trailId);
            if(trail == null) return NotFound();
            if (!_trailRepository.DeleteTrail(trail))
            {
                ModelState.AddModelError("", $"Sonmething went wrong while delete data : {trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
