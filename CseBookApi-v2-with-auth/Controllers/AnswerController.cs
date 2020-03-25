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
using WebApi.Models.Answer;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private IAnswerService _answerService;

        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AnswerController(
            IAnswerService answerService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _answerService = answerService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateAnswer([FromBody]CreateAnswerModel model)
        {
            // map model to entity
            var answer = _mapper.Map<Answer>(model);

            try
            {
                // create user answer
                _answerService.Create(answer);
                return Ok(new {
                    data = answer,
                    message = "Successfully saved user answer."
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
            var answer = _answerService.GetAll();
            var model = _mapper.Map<IList<AnswerModel>>(answer);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var answer = _answerService.GetById(id);
            var model = _mapper.Map<AnswerModel>(answer);
            return Ok(model);
        }

        [AllowAnonymous]

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateAnswerModel model)
        {
            // map model to entity and set id
            var answer = _mapper.Map<Answer>(model);
            answer.Id = id;

            try
            {
                // update user answer
                _answerService.Update(answer);
                return Ok(new {
                    data = answer,
                    message = "Successfully updated user answer."
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
            _answerService.Delete(id);
            return Ok(new {
                message = "Successfully deleted user answer."
            });
        }
    }
}
