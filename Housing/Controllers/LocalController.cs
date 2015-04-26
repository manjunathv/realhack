using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Housing.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace Housing.Controllers
{
    public class LocalController : ApiController
    {
        [HttpGet]
        public IEnumerable<MyLocality> Get(int Id)
        {
            string constr = ConfigurationManager.AppSettings["ConnectString"].ToString();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                string query = "SELECT LocalityId, LocalityName FROM `Locality` WHERE CityId = " + Id;

                var localities = con.Query<MyLocality>(query);
                return localities;
            }
           
        }

        
    }
}
