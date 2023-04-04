using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validation
{
    public class PaginationReqDtoValidation: AbstractValidator<PaginationReqDto>
    {
        public PaginationReqDtoValidation()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .NotNull()
                .GreaterThan(0);

        }
    }
}
