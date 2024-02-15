using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListMVC.Models;

namespace TodoListMVC.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options){

        }

        public DbSet<Tarefa> Tarefas {get; set;}
    }
}