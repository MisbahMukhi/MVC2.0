using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Musicology.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace Musicology.Controllers
{
    public class SearchController : Controller
    {

        List<Song> SelectedSongs = new List<Song>();
        List<Artist> SelectedArtists = new List<Artist>();
        List<Album> SelectedAlbums = new List<Album>();
        List<Song> SelectedAllSongs = new List<Song>();

        AppDbContext Db = new AppDbContext();
        // GET: Search
        public ActionResult Index(string SearchString, string SelectedTypes)
        {
          

           
            if(SelectedTypes == "Song")
            {
                 var query1 = from c in Db.Songs
                            select c;
                query1 = query1.Where(c => c.SongTitle.Contains(SearchString));
                SelectedSongs = query1.ToList();
                return View("Index", SelectedSongs);

            }
            else if(SelectedTypes == "Artist")
            {
                var query2 = from c in Db.Artists
                             select c;
                query2 = query2.Where(c => c.ArtistName.Contains(SearchString));
                SelectedArtists = query2.ToList();
                return View("ArtistSearch", SelectedArtists);
            }
            else if (SelectedTypes == "Album")
            {
                var query3 = from c in Db.Albums
                             select c;
                query3= query3.Where(c => c.AlbumName.Contains(SearchString));
                SelectedAlbums = query3.ToList();
                return View("AlbumSearch", SelectedAlbums);
            }
            else
            {
                var query4 = from c in Db.Songs
                             select c;
                query4 = query4.Where(c => c.SongTitle.Contains(SearchString));
                SelectedAllSongs = query4.ToList();
               

            }
            return View("Index", SelectedAllSongs);



        }

        public ActionResult SearchResults(string SearchString)
        {
            var query = from c in Db.Songs
                        select c;
            query = query.Where(c => c.SongTitle.Contains(SearchString));
            SelectedSongs = query.ToList();
            return View("Index", SelectedSongs);
        }
    }

}