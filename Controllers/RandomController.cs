using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace YourNamespace.Controllers
{
    public class RandomController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if(count == null ){
                count = 0;
            }
            count += 1;
            Random rand = new Random();
            string characters = "0123456789ABCDEFGHIGJKLMNOPQUSTUVWXYZ";
            string passcode = "";
            for (int i = 0; i < 14; i++){
                passcode = passcode + characters[rand.Next(0, characters.Length)];
            }
            ViewBag.passcode = passcode;
            ViewBag.count = count;
            HttpContext.Session.SetInt32("count", (int)count);
            return View("Index");
        }
    }
}