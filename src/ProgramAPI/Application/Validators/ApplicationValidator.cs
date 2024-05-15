using Application.Dtos.ApplicationDtos;
using Application.Dtos.PersonalInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ApplicationValidator : AbstractValidator<CreateApplicationDto>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.PersonalInformation.FirstName).NotNull().NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.PersonalInformation.LastName).NotNull().NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.PersonalInformation.Email).EmailAddress().NotNull().NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.PersonalInformation.Phone).NotNull().NotEmpty().WithMessage("Phone Number is required");
            
            
        }
    }
}
