using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validation
{
    public class GetOneReqDtoValidation: AbstractValidator<GetOneReqDto>
    {
        public GetOneReqDtoValidation()
        {
            RuleFor(x=>x.Id).NotNull();
        }
    }
}
