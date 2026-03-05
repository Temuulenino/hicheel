using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Models;

namespace Company.Controllers
{
    public class WorkersController : Controller
    {
        private readonly CompanyDbContext _context;

        public WorkersController(CompanyDbContext context)
        {
            _context = context;
        }

        // 1. Жагсаалт харах (Index)
        public async Task<IActionResult> Index()
        {
            var workers = _context.Workers.Include(w => w.Branch);
            return View(await workers.ToListAsync());
        }

        // 2. Шинээр нэмэх хуудас (Create - GET)
        // GET: Workers/Create
        public IActionResult Create()
        {
            // Салбаруудын жагсаалтыг ViewBag-т оноож өгөх (Branchid, Branchname нэрийг анхаар)
            ViewBag.Branchid = new SelectList(_context.Branches, "Branchid", "Branchname");
            return View();
        }

        // 3. Шинээр нэмэх үйлдэл (Create - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Workerid,Fullname,Position,Branchid")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Алдаа гарсан тохиолдолд унждаг цэсийг дахин утгаар бөглөх (NullReference-ээс сэргийлнэ)
            ViewBag.Branchid = new SelectList(_context.Branches, "Branchid", "Branchname", worker.Branchid);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null) return NotFound();
            ViewData["Branchid"] = new SelectList(_context.Branches, "Branchid", "Branchname", worker.Branchid);
            return View(worker);
        }

        // POST: Workers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Workerid,Fullname,Position,Branchid")] Worker worker)
        {
            if (id != worker.Workerid) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var worker = await _context.Workers.Include(w => w.Branch).FirstOrDefaultAsync(m => m.Workerid == id);
            if (worker == null) return NotFound();
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Бусад Edit, Delete үйлдлүүдийг Index ажилласны дараа нэмж болно.
    }
}