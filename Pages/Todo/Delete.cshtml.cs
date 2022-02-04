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
    public class DeleteModel : PageModel
    {
        private readonly TodoApplication.Data.ApplicationDbContext _context;

        public DeleteModel(TodoApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskTodo TaskTodo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskTodo = await _context.TaskTodos.FirstOrDefaultAsync(m => m.TaskTodoId == id);

            if (TaskTodo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskTodo = await _context.TaskTodos.FindAsync(id);

            if (TaskTodo != null)
            {
                _context.TaskTodos.Remove(TaskTodo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
