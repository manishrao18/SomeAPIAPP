using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SomeAPIAPP.Data.Contracts;
using SomeAPIAPP.DTOs;
// Not required as the data push-pull will be done by DTO object and not by the model.
using SomeAPIAPP.Models; 

namespace SomeAPIAPP.Controllers
{
    [Route("api/someapis")]
    [ApiController]
    public class SomeAPIController: ControllerBase
    {
        private readonly ISomeAPIAppRepo _repository ;
        private readonly IMapper _mapper;

        public SomeAPIController(ISomeAPIAppRepo repository, IMapper mapper) 
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        // GET api/someapis
        [HttpGet]
        public ActionResult <IEnumerable<SomeAPIAppReadDTO>> GetAllAPIs()
        {
            var apiItems = _repository.GetAllAPIs();
            return Ok(_mapper.Map<IEnumerable<SomeAPIAppReadDTO>>(apiItems));
        }
        // GET api/someapis/{id}
        [HttpGet("{id}", Name="GetAPIDetailByID")]
        public ActionResult <SomeAPIAppReadDTO> GetAPIDetailByID(int id)
        {
            var apiItem = _repository.GetAPIDetailByID(id);
            if(apiItem != null)
            {
                return Ok(_mapper.Map<SomeAPIAppReadDTO>(apiItem));
            }
            return NotFound();
        }
        // POST api/someapis
        [HttpPost]
        public ActionResult <SomeAPIAppReadDTO> AddAPIDetail(SomeAPIAppAddDTO apiAddDTO)
        {
            if(apiAddDTO!=null)
            {
                var apiModel = _mapper.Map<SomeAPIModel>(apiAddDTO);
                // we can have validation enforced on this.
                _repository.AddAPIDetail(apiModel);
                _repository.SaveChanges();
                // return appropriate details
                var apiReadDTO = _mapper.Map<SomeAPIAppReadDTO>(apiModel);
                return CreatedAtRoute(nameof(GetAPIDetailByID), new {ID = apiReadDTO.ID}, apiReadDTO);
                //return Ok(apiReadDTO);
            }
            return BadRequest();
        }
        // PUT api/someapis/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAPIDetail(int id, SomeAPIAppUpdateDTO apiUpdateDTO)
        {
            var requestAPIModel = _repository.GetAPIDetailByID(id);
            if(requestAPIModel == null)
            {
                return NotFound();
            }
            _mapper.Map(apiUpdateDTO, requestAPIModel);
            _repository.UpdateAPIDetail(requestAPIModel);
            _repository.SaveChanges();

            return NoContent();
        }
        // PATCH api/someapis/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialAPIDetailUpdate(int id, JsonPatchDocument<SomeAPIAppUpdateDTO> patchDocument)
        {
            var requestAPIModel = _repository.GetAPIDetailByID(id);
            if(requestAPIModel == null)
            {
                return NotFound();
            }
            var apiDetailToPatch = _mapper.Map<SomeAPIAppUpdateDTO>(requestAPIModel);
            patchDocument.ApplyTo(apiDetailToPatch, ModelState);

            if(! TryValidateModel(apiDetailToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(apiDetailToPatch, requestAPIModel);
            _repository.UpdateAPIDetail(requestAPIModel);
            _repository.SaveChanges();
            
            return NoContent();
        }

        //DELETE api/someapis/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAPI(int id)
        {
            var requestAPIModel = _repository.GetAPIDetailByID(id);
            if(requestAPIModel == null)
            {
                return NotFound();
            }            
            _repository.DeleteAPIDetail(requestAPIModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}