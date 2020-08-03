using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B5_ApiTutorial.Repository;
using B5_ApiTutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace B5_ApiTutorial.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentitiService _identitiService;
        public IdentityController(IIdentitiService identitiService)
        {
            _identitiService = identitiService;
        }

        [HttpPost]
        [Route("api/v1/identity/login")]
        public async Task<IActionResult> Reg([FromBody] UserRegRequest userRegRequest)
        {
            var au = await _identitiService.AuThenticationResultAsync(userRegRequest.Email, userRegRequest.Password);
            if(!au.success)
            {
                return BadRequest(new AuthenFailedResponses
                {
                    Error = au.Error
                });
            }
            return Ok(new RegistrationResponse
            {
                token = au.token
            });
        }
    }
}
