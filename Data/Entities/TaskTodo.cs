using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data.Enums;

namespace TodoApplication.Data.Entities
{
    public class TaskTodo
    {
        public Guid TaskTodoId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
