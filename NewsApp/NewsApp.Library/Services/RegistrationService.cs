using Dapper;
using NewsApp.Library.Contracts;
using NewsApp.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Services
{
    public class RegistrationService : IDataService<RegistrationModel>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RegistrationModel> Get()
        {
            throw new NotImplementedException();
        }

        public RegistrationModel GetPublishedArticlesById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RegistrationModel registrationModel)
        {
            //TODO: Add output parameters to the stored procedure, then add validation logic into React App 


        }

        public void Update(int id, RegistrationModel modelObject)
        {
            throw new NotImplementedException();
        }
        
        public dynamic Register(RegistrationModel registrationModel)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", registrationModel.UserId);
            parameters.Add("@Username", registrationModel.UserId);
            parameters.Add("@Username", registrationModel.Username);
            parameters.Add("@Password", registrationModel.Password);
            parameters.Add("@FirstName", registrationModel.FirstName);
            parameters.Add("@LastName", registrationModel.LastName);
            parameters.Add("@Email", registrationModel.Email);
            parameters.Add("@TelephoneNumber", registrationModel.TelephoneNumber);
            parameters.Add("@CellphoneNumber", registrationModel.CellphoneNumber);
            parameters.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
            parameters.Add("UsernameAlreadyExists", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            GetService.GetDataAccessService().SaveData<DynamicParameters>("AddUser", parameters, "DataConnection");

            var message = parameters.Get<string>("@Message");
            var usernameAlreadyExists = parameters.Get<bool>("@UsernameAlreadyExists");

            return new { message, usernameAlreadyExists };
        }

        public RegistrationModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
