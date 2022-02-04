using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Data.Entities;

namespace TodoApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoApplication.Data.ApplicationDbContext _context;

        public IndexModel(TodoApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskTodo> TaskTodo { get;set; }

        public async Task OnGetAsync()
        {
            TaskTodo = await _context.TaskTodos.ToListAsync();
        }
    }
}
