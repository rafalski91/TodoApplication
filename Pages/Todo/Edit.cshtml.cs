using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Data.Entities;

namespace TodoApplication.Pages
{
    public class EditModel : PageModel
    {
        private readonly TodoApplication.Data.ApplicationDbContext _context;

        public EditModel(TodoApplication.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaskTodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTodoExists(TaskTodo.TaskTodoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaskTodoExists(Guid id)
        {
            return _context.TaskTodos.Any(e => e.TaskTodoId == id);
        }
    }
}
