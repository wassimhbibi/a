using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using IjaEkri.Models;

namespace IjaEkri.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
select email,password,role
from dbo.Account";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["IjaEkri"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public Boolean post(login log)
        {

            string query = @"select email,password from dbo.Account where email='" + log.email + "' and password= '" + log.password + "'";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["IjaEkri"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }

            if (table.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
