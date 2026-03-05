using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.Models;

namespace Company.Controllers
{
    public class BranchesController : Controller
    {
        private readonly CompanyDbContext _context;

        public BranchesController(CompanyDbContext context)
        {
            _context = context;
        }

        // 1. Салбаруудын жагсаалт
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branches.ToListAsync());
        }

        // 2. Шинэ салбар нэмэх (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. Шинэ салбар нэмэх (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Branchid,Branchname")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // 4. Засах (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // 5. Засах (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Branchid,Branchname")] Branch branch)
        {
            if (id != branch.Branchid) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // 6. Устгах (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.Branches.FirstOrDefaultAsync(m => m.Branchid == id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // 7. Устгах (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}