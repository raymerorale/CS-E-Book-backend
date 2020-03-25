using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.ReadStatus;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReadStatusController : ControllerBase
    {
        private IReadStatusService _readStatusService;

        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ReadStatusController(
            IReadStatusService readStatusService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _readStatusService = readStatusService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateReadStatus([FromBody]CreateReadStatusModel model)
        {
            // map model to entity
            var readStatus = _mapper.Map<ReadStatus>(model);

            try
            {
                // create read status
                _readStatusService.Create(readStatus);
                return Ok(new {
                    data = readStatus,
                    message = "Successfully saved read status."
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var readStatus = _readStatusService.GetAll();
            var model = _mapper.Map<IList<ReadStatusModel>>(readStatus);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var readStatus = _readStatusService.GetById(id);
            var model = _mapper.Map<ReadStatusModel>(readStatus);
            return Ok(model);
        }

        [AllowAnonymous]

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateReadStatusModel model)
        {
            // map model to entity and set id
            var readStatus = _mapper.Map<ReadStatus>(model);
            readStatus.Id = id;

            try
            {
                // update read status 
                _readStatusService.Update(readStatus);
                return Ok(new {
                    data = readStatus,
                    message = "Successfully updated read status."
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _readStatusService.Delete(id);
            return Ok(new {
                message = "Successfully deleted read status."
            });
        }
    }
}
