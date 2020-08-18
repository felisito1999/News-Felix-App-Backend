using NewsApp.Library.Contracts;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public class UserService : IDataService<UserModel>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> Get()
        {
            try
            {
                var parameters = new
                {

                };

                var users = GetService.GetDataAccessService().LoadData<UserModel, dynamic>("GetAllUsers", parameters, "DefaultConnection");

                return users; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public void UpdateUserRoles(string userId, string roleId)
        {
            try
            {
                var parameters = new
                {
                    Id = userId,
                    RoleId = roleId
                };

                GetService.GetDataAccessService().LoadData<UserModel, dynamic>("UpdateUserRole", parameters, "DefaultConnection");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel GetUserById(string id)
        {
            try
            {
                var parameters = new
                {
                    Id = id
                };

                var user = GetService.GetDataAccessService().LoadData<UserModel, dynamic>("GetUsersById", parameters, "DefaultConnection").FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserModel modelObject)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UserModel modelObject)
        {
            throw new NotImplementedException();
        }
    }
}
