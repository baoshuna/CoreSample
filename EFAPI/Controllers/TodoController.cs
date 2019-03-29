using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAPI.Data;
using EFAPI.Model;
using EFAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly MyDbContext context;
        public TodoController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet(Name ="GetAll")]
        public IEnumerable<TodoItem> GetAll()
        {
            Enumerable.Empty<>
            return context.TodoItems.ToList();
        }
        
        [HttpGet("{id}",Name ="GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = context.TodoItems.FirstOrDefault(it => it.Id.Equals(id));

            if (item == null)
            {
                return BadRequest("400 bad!!!");
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("模型不准确");
            }

            context.TodoItems.Add(item);
            await context.SaveChangesAsync();

            //跳转到GetTodo
            return CreatedAtRoute("GetTodo", new { Id = item.Id }, item);
        }
    }
}