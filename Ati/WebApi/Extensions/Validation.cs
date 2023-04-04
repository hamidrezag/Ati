using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Validation;

namespace WebApi.Extensions
{
    public static class Validation
    {
        public static void RegisterValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AddToDoDtoValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteReqDtoValidation>();
            services.AddValidatorsFromAssemblyContaining<GetOneReqDtoValidation>();
            services.AddValidatorsFromAssemblyContaining<PaginationReqDtoValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateToDoDtoValidation>();
            services.AddFluentValidationAutoValidation();
        }
    }
}
