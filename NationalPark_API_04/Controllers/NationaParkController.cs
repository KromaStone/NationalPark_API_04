using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalPark_API_04.IRepository;
using NationalPark_API_04.IRepository.Repository;
using NationalPark_API_04.Model;
using NationalPark_API_04.Model.DTOs;

namespace NationalPark_API_04.Controllers
{
    [Route("api/NationalPark")]
    [ApiController]
    [Authorize]
    
    public class NationaParkController : Controller
    {
        private readonly INationalParkRepository _nationalparkRepository;
        private readonly IMapper _mapper;
        public NationaParkController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _nationalparkRepository = nationalParkRepository;
            _mapper = mapper;
            
        }

        [HttpGet] // this is called end Point
        public IActionResult GetNationalPark()
        {
            var nationalParkDto = _nationalparkRepository.GetNationalParks().Select(_mapper.Map<NationalPark,NationalParkDTO>);
            return Ok(nationalParkDto); // 200 - success response status code 
        }


        //GetNationalPark se koi lena dena nhi hai, the end point are responsible 
        //("{nationalParkId:int}") this is parameter
        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nationalPark=_nationalparkRepository.GetNationalPark(nationalParkId);
            if(nationalPark==null) return NotFound(); //404 - notfound status code 
            var nationalParkDto = _mapper.Map<NationalParkDTO>(nationalPark);
            return Ok(nationalParkDto);
        }


        [HttpPost]
        public IActionResult CreateNationalPark([FromBody]NationalParkDTO nationalParkDTO) //[FromBody] is used when the data is coming from client
        {
            if(nationalParkDTO==null) return BadRequest();//400
            if(_nationalparkRepository.NationalParkExists(nationalParkDTO.Name))
            {
                ModelState.AddModelError("", "National Park in Db |||");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(!ModelState.IsValid) return BadRequest();
            var nationalPark = _mapper.Map<NationalParkDTO, NationalPark>(nationalParkDTO);
            if(!_nationalparkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while save Data : {nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //return Ok();
            return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalPark.Id }, nationalPark);
        }


        [HttpPut]
        public IActionResult UpdateNationalParl([FromBody]NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var nationalPark = _mapper.Map<NationalPark>(nationalParkDTO);
            if (!_nationalparkRepository.UpdateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while update data:{nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent(); //204
        }



        [HttpDelete("{nationalParkId:int}")]
        public IActionResult DeleteNationalPark(int nationalParkId)
        {
            if (!_nationalparkRepository.NationalParkExists(nationalParkId)) return NotFound();
            var nationalPark = _nationalparkRepository.GetNationalPark(nationalParkId);
            if(nationalPark == null) return NotFound();
            if(!_nationalparkRepository.DeleteNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong while delete Data : {nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

    }
}
