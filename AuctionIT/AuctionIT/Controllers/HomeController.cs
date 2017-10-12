using AuctionIT.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionIT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ItemView()
        {
            return View();
        }
        public ActionResult Reports()
        {
            return View();
        }
        public ActionResult MasterTable()
        {
            List<AuctionItem>  auctionItems = new List<AuctionItem>();
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM auctionitems";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            auctionItems.Add(new AuctionItem
                            {
                                autoID = Convert.ToInt32(sdr["AutoID"]),
                                itemID = Convert.ToInt32(sdr["ItemId"]),
                                description = sdr["Description"].ToString(),
                                currentWinningBid = Convert.ToDouble(sdr["CurrentWinningBid"]),
                                currentWinningBidder = Convert.ToInt32(sdr["CurrentWinningBidder"]),
                                donatedBy = sdr["Donated By"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return View(auctionItems);
        }
        public ActionResult MasterTableAjaxHandler(jQueryDataTableParamModel param)
        {
                return Json(new
            {
                sEcho = param.sEcho,
                //iTotalRecords = allCompanies.Count(),
                //iTotalDisplayRecords = allCompanies.Count(),
                //aaData = result
            },
                            JsonRequestBehavior.AllowGet);
        }
    }
}