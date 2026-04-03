using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using CinestarApp.Models;

namespace CinestarApp.Controllers
{
    public class CineStarController : Controller
    {
        private readonly MySqlConnection _db;

        public CineStarController(MySqlConnection db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Cines()
        {
            var lista = _db.Query<Entidades.Cine>("call sp_getCines()").ToList();
            return View(lista);
        }

        public IActionResult Cine(int id)
        {
            
            dynamic model = new System.Dynamic.ExpandoObject();

            model.Cine = _db.QueryFirstOrDefault<Entidades.Cine>("call sp_getCine(@_id)", new { _id = id });

            model.Tarifas = _db.Query<Entidades.CineTarifa>("call sp_getCineTarifas(@_id)", new { _id = id }).ToList();

            model.Peliculas = _db.Query<dynamic>("call sp_getCinePeliculas(@_idCine)", new { _idCine = id }).ToList();

            return View(model);
        }

        public IActionResult Peliculas(int id = 1)
        {
            
            var lista = _db.Query<Entidades.Pelicula>("call sp_getPeliculas(@_id)", new { _id = id }).ToList();

            return View(lista);
        }

        public IActionResult Pelicula(int id)
        {
        
            var peli = _db.QueryFirstOrDefault<Entidades.Pelicula>("call sp_getPelicula(@_id)", new { _id = id });

            if (peli == null) return NotFound();

            return View(peli);
        }
    }
}