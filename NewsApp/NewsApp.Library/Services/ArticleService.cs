using Dapper;
using NewsApp.Library.Contracts;
using NewsApp.Library.Data;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public class ArticleService : IDataService<ArticleModel>
    {
        public void Delete(int id)
        {
            try
            {
                var parameters = new
                {
                    ArticleId = id
                };

                GetService.GetDataAccessService().SaveData<dynamic>("DeleteArticle", parameters, "DataConnection");
            }
            catch (Exception ex)
            {
                throw ex;               
            }
        }

        public List<ArticleModel> Get()
        {
            try
            {
                var parameters = new
                {

                };

                var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetAllArticles", parameters, "DataConnection");

                foreach (var article in articles)
                {
                    var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                    article.Categories = categories;
                }

                return articles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void PublishArticle(string userId, int articleId)
        {
            var parameters = new
            {
                ArticleId = articleId,
                UserId = userId
            };

            GetService.GetDataAccessService().SaveData<dynamic>("PublishArticle", parameters, "DataConnection"); 
        }
        public void UnpublishArticle(int articleId)
        {
            var parameters = new
            {
                ArticleId = articleId,
            };

            GetService.GetDataAccessService().SaveData<dynamic>("UnpublishArticle", parameters, "DataConnection");
        }
        public List<ArticleModel> GetPublishedArticles()
        {
            var parameters = new
            {

            };
            var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetAllPublishedArticles", parameters, "DataConnection");

            foreach (var article in articles)
            {
                var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                article.Categories = categories;
            }

            return articles;
        }

        public ArticleModel GetPublishedArticlesById(int id)
        {
            try
            {
                var parameters = new
                {
                    ArticleId = id
                };
                var article = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetPublishedArticlesById", parameters, "DataConnection").FirstOrDefault();

                article.Categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);

                return article;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ArticleModel> GetPublishedArticlesByTitle(string title)
        {
            var parameters = new
            {
                Title = title
            };
            var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetPublishedArticlesByTitle", parameters, "DataConnection");

            foreach (var article in articles)
            {
                var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                article.Categories = categories;
            }

            return articles;
        }
        public ArticleModel GetAllArticlesById(int id)
        {
            try
            {
                var parameters = new
                {
                    ArticleId = id
                };

                var article = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetAllArticlesById", parameters, "DataConnection").FirstOrDefault();

                    var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(id);
                    article.Categories = categories;


                return article;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ArticleModel> GetPublishedArticlesByCategory(int categoryId)
        {
            var parameters = new
            {
                CategoryId = categoryId
            };

            var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetPublishedArticlesByCategory", parameters, "DataConnection");

            foreach(var article in articles)
            {
                var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                article.Categories = categories;
            }

            return articles;
        }
        public List<ArticleModel> GetUnpublishedArticles()
        {
            var parameters = new
            {

            };

            var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetAllUnpublishedArticles", parameters, "DataConnection");

            foreach (var article in articles)
            {
                var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                article.Categories = categories;
            }

            return articles;
        }
        public List<ArticleModel> GetPublishedArticlesByCategoryAndTitle(int categoryId, string title)
        {
            var parameters = new
            {
                CategoryId = categoryId,
                Title = title
            };

            var articles = GetService.GetDataAccessService().LoadData<ArticleModel, dynamic>("GetPublishedArticlesByCategoryAndTitle", parameters, "DataConnection");

            foreach(var article in articles)
            {
                var categories = GetService.GetCategoryService().GetArticleCategoriesbyArticleId(article.ArticleId);
                article.Categories = categories;
            }

            return articles;
        }
        public void Insert(ArticleModel articleModel)
        {
            //List<dynamic> categories = new List<dynamic>();

            //foreach(var originalCategory in articleModel.Categories)
            //{
            //    var category = new
            //    {
            //        CategoryId = originalCategory.CategoryId,
            //        Name = originalCategory.Name
            //    };
            //    categories.Add(category);
            //};
            //var parameters = new DynamicParameters();
            //parameters.Add("@UserId", registrationModel.UserId);
            //parameters.Add("@Username", registrationModel.UserId);
            //parameters.Add("@Username", registrationModel.Username);
            //parameters.Add("@Password", registrationModel.Password);
            //parameters.Add("@FirstName", registrationModel.FirstName);
            //parameters.Add("@LastName", registrationModel.LastName);
            //parameters.Add("@Email", registrationModel.Email);
            //parameters.Add("@TelephoneNumber", registrationModel.TelephoneNumber.);
            //parameters.Add("@Categories", articleModel.Categories.AsTableValuedParameter);
            //parameters.Add("@Message", dbType: SqlDbType.Udt, direction: ParameterDirection.Output, size: 1000);
            //parameters.Add("UsernameAlreadyExists", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var categoriesTable = new DataTable();
            categoriesTable.Columns.Add("CategoryId", typeof(Int32));

            foreach(var originalCategory in articleModel.Categories)
            {
                categoriesTable.Rows.Add(originalCategory.CategoryId);
            }

            var parameters = new
            {
                Title = articleModel.Title,
                Summary = articleModel.Summary,
                MainImage = articleModel.MainImage,
                Body = articleModel.Body,
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Categories = categoriesTable.AsTableValuedParameter("[dbo].[ArticleCategoriesAdding]"),
                UserId = articleModel.UploadedUserId
            };
            GetService.GetDataAccessService().SaveData<dynamic>("AddArticle", parameters, "DataConnection");
        }

        public void Update(int id, ArticleModel articleModel)
        {

            var categoriesTable = new DataTable();
            categoriesTable.Columns.Add("CategoryId", typeof(Int32));

            foreach (var originalCategory in articleModel.Categories)
            {
                categoriesTable.Rows.Add(originalCategory.CategoryId);
            }

            var parameters = new
            {
                ArticleId = id,
                Title = articleModel.Title,
                Summary = articleModel.Summary,
                MainImage = articleModel.MainImage,
                Body = articleModel.Body,
                IsDeleted = false,
                Categories = categoriesTable.AsTableValuedParameter("[dbo].[ArticleCategoriesAdding]")
            };

            GetService.GetDataAccessService().SaveData<dynamic>("UpdateArticle", parameters, "DataConnection"); 
        }

        public ArticleModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
