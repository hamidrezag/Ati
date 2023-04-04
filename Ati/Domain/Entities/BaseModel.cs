using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseModel:IBaseModel
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
