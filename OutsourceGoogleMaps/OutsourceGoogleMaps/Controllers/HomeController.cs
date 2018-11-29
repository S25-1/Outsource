using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OutsourceGoogleMaps.Models;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Xml.Linq;

namespace OutsourceGoogleMaps.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Maps()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Maps(AdressViewModel avm)
        {
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false&key=AIzaSyBlP8u8bXlEVooKQSz6P1fLvQMEFpoNPCc", Uri.EscapeDataString(avm.Address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");

            AdressViewModel.Lat = (string) lat;
            //avm.Long = Convert.ToDecimal(lng);

            return View();
        }
    }
}