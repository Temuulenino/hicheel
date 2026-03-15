using CompanyMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;

namespace CompanyMVC.Controllers
{
    public class SalbarController : Controller
    {
        private readonly string _connStr;

        public SalbarController(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }

        // INDEX - Жагсаалт
        public IActionResult Index()
        {
            var list = new List<Salbar>();
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM Salbar ORDER BY salbarid", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Salbar
                {
                    SalbarId = reader.GetInt32(0),
                    Ner = reader.GetString(1),
                    Hayg = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Utasny_dugaar = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Burtgesen_ognoo = reader.GetDateTime(4)
                });
            }
            return View(list);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Salbar salbar)
        {
            if (!ModelState.IsValid) return View(salbar);
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO Salbar (Ner, Hayg, Utasny_dugaar) " +
                "VALUES (@Ner, @Hayg, @Utasny)", conn);
            cmd.Parameters.AddWithValue("@Ner", salbar.Ner);
            cmd.Parameters.AddWithValue("@Hayg", (object?)salbar.Hayg ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Utasny", (object?)salbar.Utasny_dugaar ?? DBNull.Value);
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM Salbar WHERE salbarid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return NotFound();
            var salbar = new Salbar
            {
                SalbarId = r.GetInt32(0),
                Ner = r.GetString(1),
                Hayg = r.IsDBNull(2) ? null : r.GetString(2),
                Utasny_dugaar = r.IsDBNull(3) ? null : r.GetString(3)
            };
            return View(salbar);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Salbar salbar)
        {
            if (!ModelState.IsValid) return View(salbar);
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "UPDATE Salbar SET Ner=@Ner, Hayg=@Hayg, " +
                "Utasny_dugaar=@Utasny WHERE salbarid=@Id", conn);
            cmd.Parameters.AddWithValue("@Ner", salbar.Ner);
            cmd.Parameters.AddWithValue("@Hayg", (object?)salbar.Hayg ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Utasny", (object?)salbar.Utasny_dugaar ?? DBNull.Value);
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
                "SELECT * FROM Salbar WHERE salbarid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return NotFound();
            var salbar = new Salbar
            {
                SalbarId = r.GetInt32(0),
                Ner = r.GetString(1)
            };
            return View(salbar);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using var conn = new NpgsqlConnection(_connStr);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "DELETE FROM Salbar WHERE salbarid=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction(nameof(Index));
        }
    }
}