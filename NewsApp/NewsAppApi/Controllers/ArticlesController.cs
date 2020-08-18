using Microsoft.AspNet.Identity;
using NewsApp.Library.Models;
using NewsApp.Library.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace NewsAppApi.Controllers
{
    [Authorize]
    public class ArticlesController : ApiController
    {
        // GET: api/Articles
        [AllowAnonymous]
        public List<ArticleModel> Get()
        {
            try
            {
                var articles = GetService.GetArticleService().GetPublishedArticles();
                return articles;
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                return new List<ArticleModel> {  };
            }
        }

        // GET: api/Articles/5
        [AllowAnonymous]
        public ArticleModel GetPublishedArticlesById(int id)
        {
            try
            {
                var article = GetService.GetArticleService().GetPublishedArticlesById(id);
                if(article == null)
                {
                    article = new ArticleModel();
                }
                return article;
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                return new ArticleModel();
            }
        }
        [AllowAnonymous]
        [Route("api/GetAllArticlesById")]
        public IHttpActionResult GetAllArticlesById(int id)
        {
            try
            {
                var article = GetService.GetArticleService().GetAllArticlesById(id);

                if(article == null)
                {
                    article = new ArticleModel();
                }

                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [AllowAnonymous]
        [Route("api/Articles/GetArticlesByTitle")]
        public IHttpActionResult GetArticlesByTitle(string title, [FromUri] PagingParameterModel pagingparametermodel)
        {
            try
            {
                var source = GetService.GetArticleService().GetPublishedArticlesByTitle(title).OrderByDescending(x => x.ArticleId).AsQueryable();

                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int currentPage = pagingparametermodel.pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int pageSize = pagingparametermodel.pageSize;

                // Display TotalCount to Records to User  
                int totalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int totalPages = (int)Math.Ceiling(count / (double)pageSize);

                // Returns List of Customer after applying Paging   
                var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                // if CurrentPage is greater than 1 means it has previousPage  
                var previousPage = currentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage  
                var nextPage = currentPage < totalPages ? "Yes" : "No";

                // Object which we are going to send in header   
                var paginationMetadata = new
                {
                    totalCount = totalCount,
                    pageSize = pageSize,
                    currentPage = currentPage,
                    totalPages = totalPages,
                    previousPage,
                    nextPage
                };

                // Setting Header  
                HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
                // Returing List of Customers Collections  
                return Ok(new {items, totalPages });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("api/GetArticles")]
        [AllowAnonymous]
        public IHttpActionResult GetArticlesPagination([FromUri] PagingParameterModel pagingParameterModel)
        {
            try
            {
                var source = GetService.GetArticleService().GetPublishedArticles().OrderByDescending(x => x.ArticleId).AsQueryable();

                int count = source.Count();

                int currentPage = pagingParameterModel.pageNumber;

                int pageSize = pagingParameterModel.pageSize;

                int totalCount = count;

                int totalPages = (int)Math.Ceiling(count / (double)pageSize);

                var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                var previousPage = currentPage > 1 ? "Yes" : "No";

                var nextPage = currentPage < totalPages ? "Yes" : "No";

                var paginationMetadata = new
                {
                    totalCount = totalCount,
                    pageSize = pageSize,
                    currentPage = currentPage,
                    totalPages = totalPages,
                    previousPage,
                    nextPage
                };

                HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));

                return Ok(new { items, totalPages });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Articles/GetAllArticlesByCategory")]
        public IHttpActionResult GetAllArticlesByCategory(int categoryId, [FromUri] PagingParameterModel pagingParameterModel)
        {
            try
            {
                var source = GetService.GetArticleService().GetPublishedArticlesByCategory(categoryId).OrderByDescending(x => x.ArticleId).AsQueryable();

                int count = source.Count();

                int currentPage = pagingParameterModel.pageNumber;

                int pageSize = pagingParameterModel.pageSize;

                int totalCount = count;

                int totalPages = (int)Math.Ceiling(count / (double)pageSize);

                var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                var previousPage = currentPage > 1 ? "Yes" : "No";

                var nextPage = currentPage < totalPages ? "Yes" : "No";

                var paginationMetadata = new
                {
                    totalCount = totalCount,
                    pageSize = pageSize,
                    currentPage = currentPage,
                    totalPages = totalPages,
                    previousPage,
                    nextPage
                };

                HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));

                return Ok(new { items, totalPages });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Articles/GetAllArticlesByCategoryAndTitle")]
        public IHttpActionResult GetPublishedArticlesByCategoryAndTitle(int categoryId, string title, [FromUri]PagingParameterModel pagingParameterModel)
        {
            try
            {
                var source = GetService.GetArticleService().GetPublishedArticlesByCategoryAndTitle(categoryId, title).OrderByDescending(x => x.ArticleId).AsQueryable();

                int count = source.Count();

                int currentPage = pagingParameterModel.pageNumber;

                int pageSize = pagingParameterModel.pageSize;

                int totalCount = count;

                int totalPages = (int)Math.Ceiling(count / (double)pageSize);

                var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                var previousPage = currentPage > 1 ? "Yes" : "No";

                var nextPage = currentPage < totalPages ? "Yes" : "No";

                var paginationMetadata = new
                {
                    totalCount = totalCount,
                    pageSize = pageSize,
                    currentPage = currentPage,
                    totalPages = totalPages,
                    previousPage,
                    nextPage
                };

                HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));

                return Ok(new { items, totalPages });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //[Authorize(Roles = "Administrator, Editor")]
        [Authorize(Roles = "Standard, Administrator, Editor")]
        [HttpPost]
        [Route("api/Articles/AddPendingArticle")]
        public IHttpActionResult PostPendingArticle(ArticleModel articleModel)
        {
            try
            {
                articleModel.UploadedUserId = RequestContext.Principal.Identity.GetUserId();

                GetService.GetArticleService().Insert(articleModel);

                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator, Editor")]
        [HttpGet]
        [Route("api/Articles/GetUnpublishedArticles")]
        public IHttpActionResult GetUnpublishedArticles()
        {
            try
            {
                var unpublishedArticles = GetService.GetArticleService().GetUnpublishedArticles();

                return Ok(unpublishedArticles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator, Editor")]
        [HttpPut]
        [Route("api/Articles/PublishArticle")]
        public IHttpActionResult PublishArticle([FromUri] int articleId)
        {
            try
            {
                var userId = RequestContext.Principal.Identity.GetUserId();
                GetService.GetArticleService().PublishArticle(userId, articleId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator, Editor")]
        [HttpPut]
        [Route("api/UnpublishArticle")]
        public IHttpActionResult UnpublishArticle(int id)
        {
            try
            {
                GetService.GetArticleService().UnpublishArticle(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Administrator, Editor")]
        [HttpPut]
        [Route("api/Articles/UpdateArticle")]
        public IHttpActionResult UpdateArticle(ArticleModel articleModel)
        {
            try
            {
                //userId
                GetService.GetArticleService().Update(articleModel.ArticleId, articleModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articles/5
        [Authorize(Roles = "Administrator, Editor")]
        [HttpDelete]
        [Route("api/Articles/DeleteArticle")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                GetService.GetArticleService().Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
