using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IjaEkri.Models;

namespace IjaEkri.Controllers
{
    public class CreateAccountController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
select *
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

        public String post(createAccount crealog)
        {
            try
            {

                string query = @"INSERT INTO dbo.Account (fullname, email,gender, phone,role,password) VALUES ('" + crealog.fullname + "','" + crealog.email + "','" + crealog.gender + "','" + crealog.phone + "','" + crealog.role + "','" + crealog.password + "')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["IjaEkri"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "added successful !!";
            }
            catch (Exception)
            {
                return "failed to add !!";
            }
        }

        [Route("api/add_account/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                var originalFileName = Path.GetFileName(postedFile.FileName);
                var physicalPath = HttpContext.Current.Server.MapPath("~/photo" + originalFileName);

                postedFile.SaveAs(physicalPath);

                return originalFileName;
            }
            catch (Exception)
            {
                return "D:/projet PFA/backend/WebApi/WebApi/partieback/photo/ano.png";
            }
        }

    }
}