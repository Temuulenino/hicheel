using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using week2.Models;

namespace week2.Controllers
{
    public class BranchController : Controller
    {
        private readonly EmployeeCtx _context;
        public BranchController(EmployeeCtx context) { _context = context; }

        // LIST
        public async Task<IActionResult> Index()
            => View(await _context.branches.ToListAsync());

        // CREATE GET
        public IActionResult Create() => View();

        // CREATE POST
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // EDIT POST
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Branch branch)
        {
            if (id != branch.branchID) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var branch = await _context.branches.FindAsync(id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.branches.FindAsync(id);
            if (branch != null) _context.branches.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}