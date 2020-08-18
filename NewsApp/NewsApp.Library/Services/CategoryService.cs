using NewsApp.Library.Contracts;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public class CategoryService : IDataService<CategoryModel>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> Get()
        {
            var parameters = new
            {

            };
            var categories = GetService.GetDataAccessService().LoadData<CategoryModel, dynamic>("GetAllCategories", parameters, "DataConnection");

            return categories;
        }

        public CategoryModel GetPublishedArticlesById(int id)
        {
            var parameters = new
            {
                CategoryId = id
            };
            var category = GetService.GetDataAccessService().LoadData<CategoryModel, dynamic>("GetCategoriesById", parameters, "DataConnection");
            return category.FirstOrDefault();
        }

        public void Insert(CategoryModel modelObject)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CategoryModel modelObject)
        {
            throw new NotImplementedException();
        }
        public List<CategoryModel> GetArticleCategoriesbyArticleId(int id)
        {
            try
            {
                var parameters = new
                {
                    ArticleId = id
                };

                var categories = GetService.GetDataAccessService().LoadData<CategoryModel, dynamic>("GetArticleCategoriesById", parameters, "DataConnection");

                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
