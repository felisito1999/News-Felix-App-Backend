using NewsApp.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAppApi.Controllers
{
    [Authorize]
    public class RolesController : ApiController
    {
        // GET: api/Roles
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Get()
        {
            try
            {
                var roles = GetService.GetRoleService().Get();

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles ="Administrator")]
        [Route("api/GetRolesNotInUser")]
        [HttpGet]
        public IHttpActionResult GetRolesNotInUser(string id)
        {
            try
            {
                var roles = GetService.GetRoleService().GetRolesNotInUser(id);

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST: api/Roles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Roles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Roles/5
        public void Delete(int id)
        {
        }
    }
}
