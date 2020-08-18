using NewsApp.Library.Contracts;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public class RoleService : IDataService<RoleModel>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoleModel> Get()
        {
            try
            {
                var parameters = new
                {

                };
                var roles = GetService.GetDataAccessService().LoadData<RoleModel, dynamic>("GetAllRoles", parameters, "DefaultConnection");

                return roles;
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public List<RoleModel> GetRolesNotInUser(string userId)
        {
            try
            {
                var parameters = new
                {
                    UserId = userId
                };

                var roles = GetService.GetDataAccessService().LoadData<RoleModel, dynamic>("GetRolesNotInUser", parameters, "DefaultConnection");

                return roles; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public RoleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RoleModel modelObject)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, RoleModel modelObject)
        {
            throw new NotImplementedException();
        }
    }
}
