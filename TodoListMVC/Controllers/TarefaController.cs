using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoListMVC.Context;

namespace TodoListMVC.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TodoContext _context;

        public TarefaController(TodoContext context){
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NovaTarefa()
        {
            return View();
        }


    }
}