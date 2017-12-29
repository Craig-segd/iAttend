using iAttend.Models;
using iAttend.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace iAttend.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendeeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.userId = GetCurrentUserId();
            var viewModel = new AttendeeFormModel()
            {
                Events = _context.Events.ToList()

            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendeeFormModel viewModel, Event _event)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Events = _context.Events.ToList();
                return View("Create", viewModel);
            }

            var attendee = new Attendee
            {
                userId = new Guid(User.Identity.GetUserId()),
                _Name = viewModel.Name,
                DateOfBirth = viewModel.GetDateTime().ToShortDateString(),
                EventId = viewModel.Event,
                JobTitle = viewModel.JobTitle,
                Company = viewModel.Company,
                Attended = viewModel.Attended,

            };

            _context.Attendees.Add(attendee);
            _context.SaveChanges();
            return RedirectToAction("Edit", "Attendee");
        }

        public ActionResult Edit(AttendeeFormModel viewModel, Event _event)
        {

            var userId = GetCurrentUserId();
            return View(_context.Attendees.Where(x => x.userId == userId).ToList());
        }

        [Authorize]
        public ActionResult EditAttendee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendee attendee = _context.Attendees.Find(id);

            if (attendee == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = GetCurrentUserId();
            return View(attendee);
        }

        // POST: Employees/Edit/5 //ISSUEEE
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditAttendee([Bind(Include = "Id,userId,_Name,DateOfBirth,JobTitle,Company,DateOfBirth,EventId,Attended")] Attendee attendee)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(attendee).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Edit");
            }
            ViewBag.userId = GetCurrentUserId();

            return View(attendee);
        }

        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendee attendee = _context.Attendees.Find(id);
            //if (attendee == null || !EnsureIsUserEmployee(attendee))
            //{
            //   return HttpNotFound();
            //}
            return View(attendee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendee attendee = _context.Attendees.Find(id);
            if (!EnsureIsUserEmployee(attendee))
            {
                return HttpNotFound();
            }
            if (attendee != null) _context.Attendees.Remove(attendee);
            _context.SaveChanges();
            return RedirectToAction("Edit");
        }

        public Guid GetCurrentUserId()
        {
            return new Guid(User.Identity.GetUserId());
        }

        private bool EnsureIsUserEmployee(Attendee attendee)
        {
            return attendee.userId == GetCurrentUserId();
        }
    }
}