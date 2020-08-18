using NewsApp.Library.Data;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public static class GetService
    {
        public static DataAccess GetDataAccessService()
        {
            return new DataAccess();
        }
        public static ArticleService GetArticleService()
        {
            return new ArticleService();
        }
        public static UserService GetUserService()
        {
            return new UserService();
        }
        public static RoleService GetRoleService()
        {
            return new RoleService();
        }
        public static CategoryService GetCategoryService()
        {
            return new CategoryService();
        }
        public static RegistrationService GetRegistrationService()
        {
            return new RegistrationService();
        }
    }
}
