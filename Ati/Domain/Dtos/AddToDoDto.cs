using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AddToDoDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(Priorities))]
        [Required]
        public Priorities Priority { get; set; }
    }
}
