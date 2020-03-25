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
        public IActionResult CreateReadStatus([FromBody]CreateModel model)
        {
            // map model to entity
            var readStatus = _mapper.Map<ReadStatus>(model);

            try
            {
                // create read status
                _readStatusService.Create(readStatus);
                return Ok("Successfully saved read status.");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult UpdateReadStatus()
        {
            return Ok("Successfully updated read status.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Successfully deleted read status.");
        }
    }
}
