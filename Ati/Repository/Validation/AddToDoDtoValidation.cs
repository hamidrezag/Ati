using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Validation
{
    public class AddToDoDtoValidation : AbstractValidator<AddToDoDto>
    {
        public AddToDoDtoValidation()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Title is required.")
                .MaximumLength(100)
                .Matches(@"^[A-Za-z\s]*$");
            
            RuleFor(x => x.Description).MaximumLength(500);

            RuleFor(x => x.Priority).NotNull();

        }
    }
}
