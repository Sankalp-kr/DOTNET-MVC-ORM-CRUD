using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HUB.Models;
using SAL;
using BOL;
using System.Collections.Generic;

namespace HUB.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Service ser = new Service();
        List<Student> slist = ser.GetAll();
        ViewData["slist"] = slist;
        return View();
    }

    public IActionResult New()
    {
        return View();
    }
    [HttpPost]
    public IActionResult New(int Id, string Name, string Class)
    {
        Service ser = new Service();
        Student add = new Student(Id,Name,Class);
        bool status = ser.Add(add);
        /* add this in view 'successful' */
        if(status) ViewData["true"] = "true";
        return View();
    }

    public IActionResult Remove(int rmthi)
    {
        Service ser = new Service();
        // below does not work
        // int rmthis = ViewBag["which"];
        Console.WriteLine(rmthi);
        int rmthis=rmthi;
        bool status = ser.Remove(rmthis);
        /* add this in view 'successful' */
        if(status) {ViewData["true"] = "true"; return RedirectToAction("Index","Student");}
        return View();
    }

    public IActionResult Edit(int edthis)
    {
        Service ser = new Service();
        
        Student status = ser.Edit(edthis);
        /* add this in view 'successful' */
        ViewData["id"]=status.Id;
        ViewData["name"]=status.Name;
        ViewData["class"]=status.Class;
        return View();
    }

    [HttpPost]
    public IActionResult Edit(int Id,string Name, string Class)
    {
        Service ser = new Service();
        Student update = new Student(){Id=Id,Name=Name,Class=Class};
        bool status = ser.Update(update);
        if(status) ViewData["true"]="true";
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
