using CompanyMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;

namespace CompanyMVC.Controllers
{
    public class AjiltanController : Controller
    {
        private readonly string _connStr;

        public AjiltanController(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }

        // INDEX - Жагсаалт
        public IActionResult Index()
        {
            var list = new List<Ajiltan>();
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT a.ajiltanid, a.ovog, a.ner, a.aimag_kod,
                       a.turul, a.tsalin, a.salbarid, s.ner AS salbarner
                FROM Ajiltan a
                INNER JOIN Salbar s ON a.salbarid = s.salbarid
                ORDER BY a.ajiltanid", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Ajiltan
                {
                    AjiltanId = r.GetInt32(0),
                    Ovog = r.GetString(1),
                    Ner = r.GetString(2),
                    Aimag_kod = r.IsDBNull(3) ? null : r.GetString(3),
                    Turul = r.IsDBNull(4) ? null : r.GetString(4),
                    Tsalin = r.GetDecimal(5),
                    SalbarId = r.GetInt32(6),
                    Salbar = new Salbar { Ner = r.GetString(7) }
                });
            }
            return View(list);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            SalbarListViewBag();
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ajiltan ajiltan)
        {
            if (!ModelState.IsValid)
            {
                SalbarListViewBag();
                return View(ajiltan);
            }
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO Ajiltan (Ovog, Ner, Aimag_kod, Turul, Tsalin, SalbarId) " +
                "VALUES (@Ovog, @Ner, @Aimag, @Turul, @Tsalin, @SalbarId)", conn);
            cmd.Parameters.AddWithValue("@Ovog", ajiltan.Ovog);
            cmd.Parameters.AddWithValue("@Ner", ajiltan.Ner);
            cmd.Parameters.AddWithValue("@Aimag", (object?)ajiltan.Aimag_kod ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Turul", (object?)ajiltan.Turul ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Tsalin", ajiltan.Tsalin);
            cmd.Parameters.AddWithValue("@SalbarId", ajiltan.SalbarId);
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM Ajiltan WHERE ajiltanid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return NotFound();
            var ajiltan = new Ajiltan
            {
                AjiltanId = r.GetInt32(0),
                Ovog = r.GetString(1),
                Ner = r.GetString(2),
                Aimag_kod = r.IsDBNull(3) ? null : r.GetString(3),
                Turul = r.IsDBNull(4) ? null : r.GetString(4),
                Tsalin = r.GetDecimal(5),
                SalbarId = r.GetInt32(6)
            };
            SalbarListViewBag();
            return View(ajiltan);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ajiltan ajiltan)
        {
            if (!ModelState.IsValid)
            {
                SalbarListViewBag();
                return View(ajiltan);
            }
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "UPDATE Ajiltan SET Ovog=@Ovog, Ner=@Ner, Aimag_kod=@Aimag, " +
                "Turul=@Turul, Tsalin=@Tsalin, SalbarId=@SalbarId " +
                "WHERE ajiltanid=@Id", conn);
            cmd.Parameters.AddWithValue("@Ovog", ajiltan.Ovog);
            cmd.Parameters.AddWithValue("@Ner", ajiltan.Ner);
            cmd.Parameters.AddWithValue("@Aimag", (object?)ajiltan.Aimag_kod ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Turul", (object?)ajiltan.Turul ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Tsalin", ajiltan.Tsalin);
            cmd.Parameters.AddWithValue("@SalbarId", ajiltan.SalbarId);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }

        // DELETE - GET
        public IActionResult Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM Ajiltan WHERE ajiltanid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return NotFound();
            var ajiltan = new Ajiltan
            {
                AjiltanId = r.GetInt32(0),
                Ovog = r.GetString(1),
                Ner = r.GetString(2)
            };
            return View(ajiltan);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "DELETE FROM Ajiltan WHERE ajiltanid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }

        // Салбарын жагсаалтыг ViewBag-д хийх
        private void SalbarListViewBag()
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT salbarid, ner FROM Salbar ORDER BY salbarid", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<SelectListItem>();
            while (r.Read())
            {
                list.Add(new SelectListItem
                {
                    Value = r.GetInt32(0).ToString(),
                    Text = r.GetString(1)
                });
            }
            ViewBag.SalbarList = list;
        }
    }
}