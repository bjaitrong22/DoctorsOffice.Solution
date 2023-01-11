using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

 namespace DoctorsOffice.Controllers
 {   
  public class PatientsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
        return View(patient);
      }
      else
      {
        _db.Patients.Add(patient);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
  } 
 }