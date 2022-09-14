using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalApp.Models.EntityModels;
using PersonalApp.Models.PersonalInfos;
using PersonalApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalApp.Controllers.API
{
    [Route("api/PersonalInfos")]
    [ApiController]
    public class PersonalInfosController : ControllerBase
    {
        IPersonalInfoService _personalInfoService;
        IMapper _mapper;
        public PersonalInfosController(IPersonalInfoService personalInfoService, IMapper mapper)
        {
            _personalInfoService = personalInfoService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPersonalInfos()
        {
            var infos = _personalInfoService.GetAll();
            if (infos == null)
            {
                return NoContent();
            }
            return Ok(infos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int? id,string email)
        {
            if (id==null)
            {
                return BadRequest("Please Provide a valid id!!");
            }
            var ExpectPerson = _personalInfoService.GetById((int)id);
            if (ExpectPerson==null)
            {
                return NoContent();
            }
            return Ok(ExpectPerson);
        }
        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonalCreate model)
        {
            if (ModelState.IsValid)
            {
                var newPerson = _mapper.Map<PersonalInfo>(model);
               var isAdd= _personalInfoService.Add(newPerson);
                if (isAdd)
                {
                    return Created($"api/PersonalInfos/{newPerson.Id}", newPerson);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult EditPerson(int? id, PersonalInfoEditVM model)
        {
            if (id==null)
            {
                return BadRequest("Please provide id!!");
            }
            var personData = _personalInfoService.GetById((int)id);
            if (personData==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _mapper.Map(model, personData);
                var isUpdate = _personalInfoService.Update(personData);
                if (isUpdate)
                {
                    return Ok(personData);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
