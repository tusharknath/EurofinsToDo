using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ToDo.DomainLayer.Services;
using ToDo.DomainLayer.Services.Interface;
using ToDo.WebAPI.Authentication;
using ToDo.WebAPI.DTOs;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.WebAPI.Controllers
{
    [BasicAuthentication]
    public class UserTaskController : ApiController
    {
        private IUserTaskService _userTaskService;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskService userTaskService, IMapper mapper, IUserService userService)
        {
            _userTaskService = userTaskService;
            _userService = userService;
            _mapper = mapper;
        }


        // GET: api/UserTask
        public async Task<IEnumerable<UserTaskGetDTO>> Get()
        {
            var username = User.Identity.Name;
            int userID = 0;

            if (string.IsNullOrEmpty(username))
                return null;
            else
                userID = await _userService.GetUserID(username);

            var userTasks = await _userTaskService.GetAll(userID);

            return userTasks.Select(_mapper.Map<UserTask, UserTaskGetDTO>).ToList();
        }

        // GET: api/UserTask/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserTask
        public async Task<IHttpActionResult> Post([FromBody]UserTask dto)
        {
            var username = User.Identity.Name;
            int userID = 0;

            if (string.IsNullOrEmpty(username))
                return Unauthorized();
            else
                userID = await _userService.GetUserID(username);
             
            if (dto == null)
                return BadRequest("Post action with no arguments");

            if (string.IsNullOrEmpty(dto.Title))
                return BadRequest("Argument cannot be null");

            var uTask = new UserTask
            {
                User_ID = userID,
                Title = dto.Title,
                Created_At = DateTime.Now,
                IsComplete = false
            };

            var userTask = await _userTaskService.CreateUserTask(uTask);

            return Ok(_mapper.Map<UserTaskGetDTO>(userTask));
        }

        // PUT: api/UserTask/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]UserTask dto)
        {

            var username = User.Identity.Name;
            int userID = 0;

            if (string.IsNullOrEmpty(username))
                return Unauthorized();
            else
                userID = await _userService.GetUserID(username);

            if (dto == null)
                return BadRequest("Put/Update action with no arguments");

            var userTask = await _userTaskService.GetUserTaskByID(id);
            userTask.IsComplete = dto.IsComplete;

            var uTask = await _userTaskService.UpdateUserTask(userTask);

            return Ok(_mapper.Map<UserTaskGetDTO>(uTask));
        }
    

        // DELETE: api/UserTask/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            var username = User.Identity.Name;
            int userID = 0;

            if (string.IsNullOrEmpty(username))
                return Unauthorized();
            else
                userID = await _userService.GetUserID(username);

            var userTask = await _userTaskService.GetUserTaskByID(id);

            if (userTask == null)
                return NotFound();

            if (userTask.User_ID != userID)
                return Unauthorized();

            await _userTaskService.DeleteUserTask(id);

            return Ok();
        }
    }
}
