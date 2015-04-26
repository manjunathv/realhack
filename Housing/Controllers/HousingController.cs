using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Housing.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace Housing.Controllers
{
    public class HousingController : Controller
    {
        private ankurEntities db = new ankurEntities();

        public string LocalityId = string.Empty;
        public string Type = string.Empty; 

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Result(string cityId,string localityId,string type)
        {
            int CityId = Convert.ToInt32(cityId);
            LocalityId = localityId;
            Type = type;
            string cityName = db.City.Where(i => i.Id == CityId).SingleOrDefault().Name.ToString();
            ViewData["CityName"] = cityName;

            return View(GetTrending(cityId));
        }

        public IEnumerable<House> GetHouses(string localityId,string type)
        {
            string constr = ConfigurationManager.AppSettings["ConnectString"].ToString();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();                
                string query = @"SELECT a.*,b.LocalityName FROM " + type + " a INNER JOIN Locality  b ON a.LocailtyId = b.LocalityId " + "WHERE LocalityId = " + localityId; 
                var houses = con.Query<House>(query);
                return houses;
            }
        }

        public IEnumerable<MyTrending> GetTrending(string cityId)
        {
            string constr = ConfigurationManager.AppSettings["ConnectString"].ToString();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();                
                string query = @"SELECT a.*,b.LocalityName FROM Trending a INNER JOIN Locality  b ON a.LocalityId = b.LocalityId " + "WHERE a.CityId = " + cityId; 
                var trending = con.Query<MyTrending>(query);
                return trending;
            }
        }
              
    }
}
