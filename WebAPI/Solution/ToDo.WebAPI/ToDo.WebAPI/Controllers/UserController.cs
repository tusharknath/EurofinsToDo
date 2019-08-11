using AutoMapper;
using System.Threading.Tasks;
using System.Web.Http;
using ToDo.DomainLayer;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.DTOs;
using ToDo.WebAPI.EF.Data.Model;

namespace ToDo.WebAPI.Controllers
{
    //[BasicAuthentication]
    public class UserController : ApiController
    {        

        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [Route("user/authenticate")]
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody]User userParam)
        {
            var user =  await _userService.Authenticate(userParam.UserName, userParam.Password);

            if (user == null)
                return BadRequest("Invalid User Name or Password");
            
            return Ok(_mapper.Map<UserGetDTO>(user));
        }

        [Route("user/register")]
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost]

        public async Task<IHttpActionResult> Register([FromBody]User userDTO)
        {
            try
            {
                // save 
                var user = await _userService.Register(userDTO);

                if (user == null)
                    return BadRequest();

                return Ok(user);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message.ToString());
            }

        }

        [Route("user/getUserPassword")]
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost]

        public IHttpActionResult ForgotPassword([FromBody]User userDTO)
        {
            try
            {
                // save 
                var userPassword = _userService.ForgotPassword(userDTO);

                if (userPassword == null)
                    return BadRequest("Invalid User Name");

                return Ok(userPassword);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest("Internal Server Error");
            }

        }

    }
}
