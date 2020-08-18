using Microsoft.AspNet.Identity;
using NewsApp.Library.Models;
using NewsApp.Library.Services;
using NewsAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAppApi.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("api/User/GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var users = GetService.GetUserService().Get();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("api/User/UpdateUserRole")]
        public IHttpActionResult UpdateUserRole(string userId, string roleId)
        {
            try
            {
                GetService.GetUserService().UpdateUserRoles(userId, roleId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator")]
        [Route("api/User/GetById")]
        [HttpGet]
        public IHttpActionResult GetById(string id)
       {
            try
            {
                var user = GetService.GetUserService().GetUserById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        public IHttpActionResult GetOwnId()
        {
            try
            {
                var userId = RequestContext.Principal.Identity.GetUserId();

                return Ok(userId);
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("api/User/Register")]
        public IHttpActionResult Register(RegistrationModel registrationModel)
        {
            try
            {
                var response = GetService.GetRegistrationService().Register(registrationModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        } 
    }
}
