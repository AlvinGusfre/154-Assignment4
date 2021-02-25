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

        // GET: Movies (Search-function)
        //[HttpGet]
        //[ValidateAntiForgeryToken] // Only if logged in
        public async Task<IActionResult> Index(string numberOfBeds, string roomSize, string roomQuality)
        {
            var allRooms = from m in _db.Rooms
                        select m;

            if (numberOfBeds != null && roomSize != null && roomQuality != null)
            {
                return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Equals(numberOfBeds) &&
                                                      s.RoomSize.ToString().Equals(roomSize) &&
                                                      s.RoomQuality.ToString().Equals(roomQuality)).ToListAsync());
            }
            else if (numberOfBeds != null && roomSize == null && roomQuality == null)
            {
                return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Equals(numberOfBeds)).ToListAsync());
            } else if (numberOfBeds == null && roomSize != null && roomQuality == null)
            {
                return View(await allRooms.Where(s => s.RoomSize.ToString().Equals(roomSize)).ToListAsync());
            } else if (numberOfBeds == null && roomSize == null && roomQuality != null)
            {
                return View(await allRooms.Where(s => s.RoomQuality.ToString().Equals(roomQuality)).ToListAsync());
            } else if (numberOfBeds != null && roomSize != null && roomQuality == null)
            {
                return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Equals(numberOfBeds) &&
                                                      s.RoomSize.ToString().Equals(roomSize)).ToListAsync());
            } else if (numberOfBeds != null && roomSize == null && roomQuality != null)
            {
                return View(await allRooms.Where(s => s.NumberOfBeds.ToString().Equals(numberOfBeds) &&
                                                      s.RoomQuality.ToString().Equals(roomQuality)).ToListAsync());
            } else if (numberOfBeds == null && roomSize != null && roomQuality != null)
            {
                return View(await allRooms.Where(s => s.RoomSize.ToString().Equals(roomSize) &&
                                                      s.RoomQuality.ToString().Equals(roomQuality)).ToListAsync());
            }

            return View(await allRooms.ToListAsync());
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ReserveRoom(int? id)
        {
            var obj = _db.Rooms.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Rooms.Find(id).Available = false;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
