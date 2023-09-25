using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assesment.Models;

namespace Assesment.Controllers
{
    public class AppointmentTablesController : Controller
    {
        private readonly DoctorContext _context;

        public AppointmentTablesController(DoctorContext context)
        {
            _context = context;
        }

        // GET: AppointmentTables
        public async Task<IActionResult> Index()
        {
            var doctorContext = _context.AppointmentTables.Include(a => a.MedicalIssueNavigation);
            return View(await doctorContext.ToListAsync());
        }

        // GET: AppointmentTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppointmentTables == null)
            {
                return NotFound();
            }

            var appointmentTable = await _context.AppointmentTables
                .Include(a => a.MedicalIssueNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentTable == null)
            {
                return NotFound();
            }

            return View(appointmentTable);
        }

        // GET: AppointmentTables/Create
        public IActionResult Create()
        {
            ViewData["MedicalIssue"] = new SelectList(_context.Diseases, "DiseasesName", "DiseasesName");
            return View();
        }

        // POST: AppointmentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,PatientName,MedicalIssue,DoctorToVisit,DoctorAvailableTime,AppointmentTime")] AppointmentTable appointmentTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalIssue"] = new SelectList(_context.Diseases, "DiseasesName", "DiseasesName", appointmentTable.MedicalIssue);
            return View(appointmentTable);
        }

        // GET: AppointmentTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppointmentTables == null)
            {
                return NotFound();
            }

            var appointmentTable = await _context.AppointmentTables.FindAsync(id);
            if (appointmentTable == null)
            {
                return NotFound();
            }
            ViewData["MedicalIssue"] = new SelectList(_context.Diseases, "DiseasesName", "DiseasesName", appointmentTable.MedicalIssue);
            return View(appointmentTable);
        }

        // POST: AppointmentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,PatientName,MedicalIssue,DoctorToVisit,DoctorAvailableTime,AppointmentTime")] AppointmentTable appointmentTable)
        {
            if (id != appointmentTable.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentTableExists(appointmentTable.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalIssue"] = new SelectList(_context.Diseases, "DiseasesName", "DiseasesName", appointmentTable.MedicalIssue);
            return View(appointmentTable);
        }

        // GET: AppointmentTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppointmentTables == null)
            {
                return NotFound();
            }

            var appointmentTable = await _context.AppointmentTables
                .Include(a => a.MedicalIssueNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentTable == null)
            {
                return NotFound();
            }

            return View(appointmentTable);
        }

        // POST: AppointmentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppointmentTables == null)
            {
                return Problem("Entity set 'DoctorContext.AppointmentTables'  is null.");
            }
            var appointmentTable = await _context.AppointmentTables.FindAsync(id);
            if (appointmentTable != null)
            {
                _context.AppointmentTables.Remove(appointmentTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentTableExists(int id)
        {
          return (_context.AppointmentTables?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
        [HttpPost]
        public IActionResult GetData(IFormCollection data)



        {
            string disease = data["disease"];
            int doctorId = Convert.ToInt32(_context.Diseases.FirstOrDefault(d => d.DiseasesName.Equals(disease)).SuitableDoctor);
            DoctorDetail doctor = _context.DoctorDetails.FirstOrDefault(d => d.DoctorId.Equals(doctorId));
            return Json(new { doctorName = doctor.Name, availableTime = doctor.StartTime + " " + "to" + " " + doctor.EndTime });
        }
    }
}
