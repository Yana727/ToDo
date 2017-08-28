using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;



namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly toDoContext _context;

        public HomeController(toDoContext context)
        {
            this._context = context; // added this 
        }
        public IActionResult Index()
        {

            return View(_context.ToDoModel.ToList());
        }
        [HttpPost] // talks to html 
        public IActionResult Index(string Name)
        {
            var currentToDo = new ToDoModel
            {
                TaskName = Name
            };
            _context.Add(currentToDo); //adds to the database 
            _context.SaveChanges(); //adds to the database 
            return View(_context.ToDoModel.ToList());
        }
        [HttpPost]
        public IActionResult Complete(int ID)
        {
            var fin = _context.ToDoModel.FirstOrDefault(m => m.ID == ID);
            fin.Finished();
            _context.SaveChanges();
            return Redirect("Index");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
