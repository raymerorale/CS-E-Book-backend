using System;
using System.Collections;
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
using WebApi.Models.UserChapter;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserChapterController : ControllerBase
    {
        private IUserChapterService _userChapterService;

        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserChapterController(
            IUserChapterService userChapterService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userChapterService = userChapterService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUserChapter([FromBody]CreateUserChapterModel model)
        {
            // map model to entity
            var userChapter = _mapper.Map<UserChapter>(model);

            try
            {
                // create user chapter
                _userChapterService.Create(userChapter);
                return Ok(new {
                    data = userChapter,
                    message = "Successfully saved user chapter."
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
            var userChapter = _userChapterService.GetAll();
            var model = _mapper.Map<IList<UserChapter>>(userChapter);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userChapter = _userChapterService.GetById(id);
            var model = _mapper.Map<UserChapterModel>(userChapter);
            return Ok(model);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var userChapter = _userChapterService.GetByUserId(userId);
            // var model = _mapper.Map<IList<UserChapterModel>>(userChapter);

            ArrayList userChapterIds = new ArrayList();

            foreach (UserChapter user in userChapter) {
                userChapterIds.Add(user.ChapterId);
            }

            return Ok(new{ userChapterIdsEnabled = userChapterIds });
        }

        [AllowAnonymous]

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateUserChapterModel model)
        {
            // map model to entity and set id
            var userChapter = _mapper.Map<UserChapter>(model);
            userChapter.Id = id;

            try
            {
                // update user chapter
                _userChapterService.Update(userChapter);
                return Ok(new {
                    data = userChapter,
                    message = "Successfully updated user chapter."
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("user/{userId}/chapter/{chapterId}")]
        public IActionResult UpdateByUserIdAndChapterId(int userId, int chapterId, [FromBody]UpdateUserChapterModel model)
        {
            // map model to entity and set id
            var userChapter = _mapper.Map<UserChapter>(model);
            userChapter.UserId = userId;
            userChapter.ChapterId = chapterId;

            try
            {
                // update user chapter
                var updatedUserChapter = _userChapterService.UpdateByUserIdAndChapterId(userChapter);
                return Ok(new {
                    data = updatedUserChapter,
                    message = "Successfully updated user chapter."
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
            _userChapterService.Delete(id);
            return Ok(new {
                message = "Successfully deleted user chapter."
            });
        }

        [HttpDelete()]
        public IActionResult DeleteAll()
        {
            _userChapterService.DeleteAll();
            return Ok(new {
                message = "Successfully deleted all chapters."
            });
        }
    }
}
