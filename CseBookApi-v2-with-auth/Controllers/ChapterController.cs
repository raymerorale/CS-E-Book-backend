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
using WebApi.Models.Chapter;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChapterController : ControllerBase
    {
        private IChapterService _chapterService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ChapterController(
            IChapterService chapterService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _chapterService = chapterService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Create([FromBody]CreateChapterModel model)
        {
            // map model to entity
            var chapter = _mapper.Map<Chapter>(model);

            try
            {
                // create chapter
                _chapterService.Create(chapter);
                return Ok(new {
                    data = chapter,
                    message = "Successfully created chapter."
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateChapterModel model)
        {
            // map model to entity and set id
            var chapter = _mapper.Map<Chapter>(model);
            chapter.Id = id;

            try
            {
                // update chapter
                _chapterService.Update(chapter);
                return Ok(new {
                    data = chapter,
                    message = "Successfully updated chapter."
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
            var chapters = _chapterService.GetAll();
            var model = _mapper.Map<IList<ChapterModel>>(chapters);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var chapter = _chapterService.GetById(id);
            var model = _mapper.Map<ChapterModel>(chapter);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _chapterService.Delete(id);
            return Ok(new {
                message = "Successfully deleted chapter."
            });
        }

        [HttpDelete()]
        public IActionResult DeleteAll()
        {
            _chapterService.DeleteAll();
            return Ok(new {
                message = "Successfully deleted all chapters."
            });
        }
    }
}
