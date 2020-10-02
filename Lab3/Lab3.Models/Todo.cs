using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Completed { get; set; }

        public static IEnumerable<Todo> Create() {
            return new List<Todo> {
                new Todo{ Task = "Hire roofers", Completed=true},
                new Todo{ Task = "Buy headphones", Completed=true},
                new Todo{ Task = "Buy better noise cancelling headphones", Completed=false},
            };
        }
    }
}
