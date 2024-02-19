using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoListMVC.Context;
using TodoListMVC.Models;

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
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult NovaTarefa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovaTarefa(Tarefa tarefa)
        {
            if(ModelState.IsValid){
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult EditarTarefa (int id){
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null){
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);    
        }

        [HttpPost]
        public IActionResult EditarTarefa(Tarefa tarefa){
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DetalharTarefa(int id){

            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null){
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa); 
        }

    }
}