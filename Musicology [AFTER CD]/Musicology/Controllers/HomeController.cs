using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//TODO: Change the namespace here to match your project's name
namespace Musicology.Controllers
{
    public enum Genre { Pop, Alternative, Dance, Country, HipHopRap, Holiday, Rock, JPop, Classical, Soundtrack, ProgressiveTrance, Comedy, ChildrensMusic, SingerSongwriter, NuMetal, Reggae, House}

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}