using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTP61.Models;

namespace ASPTP61.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            try
            {
                using (var db = new LibroEntities())
                {
                    //Envio la Lista a la vista para que la muestre
                    return View(db.libro.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Agregar()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Agregar(libro lib)

            { //Verifica el dato qe venga bien del lado servidor
                if (!ModelState.IsValid)

                    return View();
                try
                {
                    //para que abra y cierre la coneccion
                    using (var db = new LibroEntities())
                    {
                        db.libro.Add(lib);
                        db.SaveChanges();
                        return RedirectToAction("index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al agregar el libro " + ex.Message);
                    return View();
                }



            }

            public ActionResult Editar(int Id)

            { //Verifica el dato qe venga bien del lado servidor
                if (!ModelState.IsValid)

                    return View();
                try
                {
                    //para que abra y cierre la coneccion
                    using (var db = new LibroEntities())
                    {
                        //where lo uso en cualquier caso
                        //libro libro = db.libro.Where(libro => libro.Id == Id).FirstOrDefault();
                        //uso el find si solo tengo una clave primaria. no me sirve con clave compuesta
                        libro libro = db.libro.Find(Id);
                        return View(libro);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al agregar el libro" + ex.Message);
                    return View();
                }



            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Editar(libro lib)
            {
                try
                {
                    using (var db = new LibroEntities())
                    {
                        libro alu = db.libro.Find(lib.Id);
                        lib.Titulo = lib.Titulo;
                        lib.Autor = lib.Autor;
                        lib.ISBN = lib.ISBN;
                        lib.Paginas = lib.Paginas;
                        lib.Edicion = lib.Edicion;
                        lib.Editorial = lib.Editorial;
                        lib.CiudadyPais = lib.CiudadyPais;
                        lib.FechaDeEdicion = lib.FechaDeEdicion;
                        db.SaveChanges();

                        return RedirectToAction("index");
                    }


                }
                catch (Exception)
                {

                    throw;
                }

            }

            public ActionResult Detalles(int id)
            {
                using (var db = new LibroEntities())
                {

                    libro libro = db.libro.Find(id);
                    return View(libro);
                }

            }

            public ActionResult Eliminar(int Id)
            {
                using (var db = new LibroEntities())
                {

                    libro lib = db.libro.Find(Id);
                    db.libro.Remove(lib);
                    db.SaveChanges();

                    return RedirectToAction("index");
                }

            }
        }
    }
