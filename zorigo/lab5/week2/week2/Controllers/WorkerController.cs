using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using week2.Models;

namespace week2.Controllers
{
    public class WorkerController : Controller
    {
        private readonly EmployeeCtx _context;
        public WorkerController(EmployeeCtx context) { _context = context; }

        // LIST
        public async Task<IActionResult> Index()
            => View(await _context.workers.Include(w => w.branch).ToListAsync());

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.branchID = new SelectList(_context.branches, "branchID", "bname");
            return View();
        }

        // CREATE POST
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.branchID = new SelectList(_context.branches, "branchID", "bname");
            return View(worker);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var worker = await _context.workers.FindAsync(id);
            if (worker == null) return NotFound();
            ViewBag.branchID = new SelectList(_context.branches, "branchID", "bname", worker.branchID);
            return View(worker);
        }

        // EDIT POST
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Worker worker)
        {
            if (id != worker.ID) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.branchID = new SelectList(_context.branches, "branchID", "bname");
            return View(worker);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var worker = await _context.workers
                .Include(w => w.branch)
                .FirstOrDefaultAsync(w => w.ID == id);
            if (worker == null) return NotFound();
            return View(worker);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.workers.FindAsync(id);
            if (worker != null) _context.workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}