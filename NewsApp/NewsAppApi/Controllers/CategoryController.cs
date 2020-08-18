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
    public class CategoryController : ApiController
    {
        // GET: api/Category
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            try
            {
                var categories = GetService.GetCategoryService().Get();

                return Ok(new { categories });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET: api/Category/5
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = GetService.GetCategoryService().GetPublishedArticlesById(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
