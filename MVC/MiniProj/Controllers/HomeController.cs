using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniProj.Models;
using BLL;
using BOL;
namespace MiniProj.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        StudentService ss = new StudentService();
        List<Student> ls = ss.GetAllStudents();
        ViewData["Students"] = ls;
        return View();
    }

    public IActionResult Insert()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Insert(int idd, string name, string qual)
    {
        StudentService ss = new StudentService();
        ss.InsertStudent(idd, name, qual);
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Delete(string name)
    {
        StudentService ss = new StudentService();
        ss.DeleteStudent(name);
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(string name, string nname)
    {
        StudentService ss = new StudentService();
        ss.UpdateStudent(name, nname);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
