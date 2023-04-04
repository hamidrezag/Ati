using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validation
{
    public class UpdateToDoDtoValidation: AbstractValidator<UpdateToDoDto>
    {
        public UpdateToDoDtoValidation()
        {
            RuleFor(x=>x.Id).NotNull().GreaterThan(0);

            RuleFor(x => x.Title)
                .NotNull()
                .MaximumLength(100)
                .Matches(@"^[A-Za-z\s]*$");

            RuleFor(x => x.Description).MaximumLength(500);
            
            RuleFor(x => x.Priority).NotNull();
        }
    }
}
