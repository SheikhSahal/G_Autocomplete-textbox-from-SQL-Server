using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Textbox_autocomplete.Models;


namespace Textbox_autocomplete.Controllers
{
    public class HomeController : Controller
    {
        db dblayer = new db();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRecord(string prefix)
        {
            DataSet ds = dblayer.GetName(prefix);
            List<search> searchlist = new List<search>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                searchlist.Add(new search
                {
                     country_id = dr["country_id"].ToString(),
                     country_Name = dr["country_Name"].ToString()
                });

            }

            return Json(searchlist, JsonRequestBehavior.AllowGet);
        }
    }
}