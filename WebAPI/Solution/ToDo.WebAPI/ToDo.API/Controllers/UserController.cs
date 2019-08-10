using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.API.Controllers
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [Route("user/authenticate")]
    [AllowAnonymous]
    //[HttpPost]
    public async Task<IHttpActionResult> Authenticate([FromBody]User userParam)
    {
        var user = await _userService.Authenticate(userParam.UserName, userParam.Password);

        if (user == null)
            return BadRequest();

        return Ok(user);
    }

    [Route("user/register")]
    [AllowAnonymous]
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
            return BadRequest((new { message = ex.Message }).ToString());
        }

    }

}
