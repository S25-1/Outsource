﻿using System;
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
            // Hier maak je de uri aan waar je een request naar wil sturen.
            // VERGEET NIET JE KEY IN TE VULLEN ONDER "YOURKEY"
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false&key=YOURKEY", Uri.EscapeDataString(avm.Address));

            // Hier doen we de request en vangen we een json object terug

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());


            // hiermee halen we de coordinaten terug uit het json object
            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");

            //hiermee wilde ik de coordinaten teruggeven alleen dit ging niet helemaal goed
            AdressViewModel.Lat = (string) lat;
            AdressViewModel.Long = (string) lng;

            return View();
        }
    }
}