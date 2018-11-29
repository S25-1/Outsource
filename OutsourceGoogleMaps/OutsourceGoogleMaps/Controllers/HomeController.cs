using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OutsourceGoogleMaps.Models;

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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
/*@model OutsourceGoogleMaps.Models.AdressViewModel

@{
    ViewBag.Title = "Maps";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Maps</h2><!DOCTYPE html>

<div><p>Adress: </p>@Html.EditorFor(model => model.Adress, new { htmlAttributes = new { @class = "form-control" } })</div>

<div><p></p></div>

<div><button>Search!</button></div>

<div><p></p></div>

<div id="googleMap" style="width:100%;height:400px;"></div>

<script>
    var lat = 51.450851;
    var long = 5.480200;
    var CompanyName = "Hello World!";
    function myMap() {
        var mapProp = {
            center: new google.maps.LatLng(lat, long),
            zoom: 5,
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(lat, long),
        });
        marker.setMap(map);

        var infowindow = new google.maps.InfoWindow({
            content:CompanyName
        });

        google.maps.event.addListener(marker, 'click', function () {
            var pos = map.getZoom();
            map.setZoom(9);
            map.setCenter(marker.getPosition());
            window.setTimeout(function () { map.setZoom(pos); }, 3000);
            infowindow.open(map, marker);
        });
    }
</script>

<script async src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBlP8u8bXlEVooKQSz6P1fLvQMEFpoNPCc
&amp;callback=myMap"></script>*/
