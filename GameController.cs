using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowGroupCST247.Models;

namespace YellowGroupCST247.Controllers
{
    public class GameController : Controller
    {
        
        public ActionResult Index()
        {
            var gb = new GameBoard(10, 10, 5);
            return View();
        }
    }
}