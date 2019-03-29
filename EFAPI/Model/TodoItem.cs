using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFAPI.Model
{
    public class TodoItem
    {
        public string Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CompleteDate { get; set; }
    }
}
