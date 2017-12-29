using iAttend.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iAttend.Controllers
{

    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Event
        [Authorize]
        public ActionResult Index()
        {
            var userId = new Guid(User.Identity.GetUserId());

            var men = _context.Attendees.Where(m => m.EventId == 1).Where(m => m.Attended == 1);
            var mencount = men.Count();

            var tob = _context.Attendees.Where(m => m.EventId == 2).Where(m => m.Attended == 1);
            var tobcount = tob.Count();

            var nec = _context.Attendees.Where(m => m.EventId == 3).Where(m => m.Attended == 1);
            var neccount = nec.Count();

            var o2 = _context.Attendees.Where(m => m.EventId == 4).Where(m => m.Attended == 1);
            var o2count = o2.Count();

            @ViewBag.mencount = mencount;
            @ViewBag.tobcount = tobcount;
            @ViewBag.neccount = neccount;
            @ViewBag.o2count = o2count;

            return View(_context.Attendees.Where(x => x.userId == userId).ToList());
        }

    }
}