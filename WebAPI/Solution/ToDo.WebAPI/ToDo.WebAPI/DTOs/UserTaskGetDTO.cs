using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebAPI.DTOs
{
    public class UserTaskGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedOn { get; set; }
        public bool IsComplete { get; set; }
    }
}
