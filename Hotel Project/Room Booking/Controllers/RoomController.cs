using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Room_Booking.Data;
using Room_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Room_Booking.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoomController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Movies
        //public async Task<IActionResult> Index(string movieGenre, string searchString)
        //{
        //    // Use LINQ to get list of genres. //Bytte ut med Enum for Roomquality ???
        //    IQueryable<string> genreQuery = from m in _db.Movie
        //                                    orderby m.Genre
        //                                    select m.Genre;

        //    var movies = from m in _db.Movie
        //                 select m;

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    if (!string.IsNullOrEmpty(movieGenre))
        //    {
        //        movies = movies.Where(x => x.Genre == movieGenre);
        //    }

        //    var movieGenreVM = new MovieGenreViewModel
        //    {
        //        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //        Movies = await movies.ToListAsync()
        //    };

        //    return View(movieGenreVM);
        //}


        // GET: Movies
        public async Task<IActionResult> Index(string numberOfBeds, string roomSize, string roomQuality)
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> genreQuery = from m in _db.Rooms
            //                                orderby ("u", "j")
            //                                select m.Genre;

            //Enum.GetValues(typeof(Room.Quality)).Cast<Room.Quality>();


            var allRooms = from m in _db.Rooms
                        select m;
            var roomsNumberOfBeds = allRooms.Where(s => s.NumberOfBeds.ToString().Contains(numberOfBeds));
            var roomsRoomSize = allRooms.Where(s => s.RoomSize.ToString().Contains(roomSize));
            var roomsRoomQuality = allRooms.Where(s => s.RoomQuality.ToString().Contains(roomQuality));

            if (numberOfBeds != null && roomSize != null && roomQuality != null)
            {

                return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Contains(numberOfBeds) &&
                                                      s.RoomSize.ToString().Contains(roomSize)).ToListAsync());
                //return View(await allRooms.Where((s => s.NumberOfBeds.ToString().Contains(numberOfBeds).ToString().ToLis
                //&&
                //s.RoomSize.ToString().Contains(roomSize)) &&
                //s.RoomQuality.ToString().Contains(roomQuality)).ToListAsync());


            }

            //if (numberOfBeds == null && roomsRoomSize == null && roomQuality == null)
            //{
            //    return View(await allRooms.ToListAsync());
            //}
            //else if (numberOfBeds != null && roomsRoomSize == null && roomQuality == null)
            //{
            //    return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Contains(numberOfBeds)).ToListAsync());
            //}
            //else if (numberOfBeds == null && roomsRoomSize != null && roomQuality == null)
            //{
            //    return View(await allRooms.Where(s => s.RoomSize.ToString().Contains(roomSize)).ToListAsync());
            //}
            //else if (numberOfBeds == null && roomsRoomSize == null && roomQuality != null)
            //{
            //    return View(await allRooms.Where(s => s.RoomQuality.ToString().Contains(roomQuality)).ToListAsync());
            //} else
            //{
            //    return View(await allRooms.ToListAsync());
            //}


        }






        public IActionResult SearchResult()
        {
            IEnumerable<Room> objList = _db.Rooms;
            return View(objList);
        }


        // GET-Create
        public IActionResult Search()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Only if logged in
        public IActionResult Search(Room obj)
        {

            //IEnumerable<Room> matchingRooms = null;
            //List<Room> matchingRooms = null;
            //foreach (Room room in _db.Rooms)
            //{
            //    if (room.NumberOfBeds == nOfBeds)
            //    {
            //        matchingRooms.Add(room);
            //    }
            //}

            if (ModelState.IsValid)
            {
                //_db.Expenses.Add(obj);
                //_db.SaveChanges();
                return RedirectToAction("SearchResult");
            }
            return View(obj);

        }



        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Rooms.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            //_db.Rooms.Remove(obj);
            //_db.SaveChanges();
            return RedirectToAction("Search");

        }



        //[HttpGet]
        //public async Task<IActionResult> Search(String id) //SearchString
        //{
        //    ViewData["GetAvailableRooms"] = id;

        //    var roomQuery = from x in _db.Rooms select x;

        //    if (!String.IsNullOrEmpty(id.ToString()))
        //    {
        //        roomQuery = roomQuery.Where(s => s.NumberOfBeds.ToString().Contains(id)); // SEARCH FOR MORE
        //    }
        //    return View(await roomQuery.AsNoTracking().ToListAsync());

        //}





    }
}
