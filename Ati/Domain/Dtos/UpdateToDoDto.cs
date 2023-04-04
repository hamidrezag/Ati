using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UpdateToDoDto:AddToDoDto
    {
        public int Id { get; set; }
    }
}
