using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validation
{
    public class DeleteReqDtoValidation: AbstractValidator<DeleteReqDto>
    {
        public DeleteReqDtoValidation()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
