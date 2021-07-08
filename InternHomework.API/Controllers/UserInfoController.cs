using InternHomework.Model.Model.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InternHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        public UserInfoDTO Login(string Email, string Password)
        {
            var query = $"select * from dbo.UserInfo where Email='{Email}' and {Password}='b'";
            var connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbUserCopy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new SqlConnection(connectionStr);
            var command = new SqlCommand(query, connection);
            var adpEx = new SqlDataAdapter(command);
            var dtSet = new DataSet();
            adpEx.Fill(dtSet);
            if (dtSet.Tables[0].Rows.Count==1)
            {
                return new UserInfoDTO{
                     ID = (int)dtSet.Tables[0].Rows[0]["ID"],
                     Name = dtSet.Tables[0].Rows[0]["Name"].ToString(),
                     Email = dtSet.Tables[0].Rows[0]["Email"].ToString(),
                };

                
                
            }
            else
            {
                return new UserInfoDTO
                {
                    ID = 0
                };
            }

        }
    }
}
