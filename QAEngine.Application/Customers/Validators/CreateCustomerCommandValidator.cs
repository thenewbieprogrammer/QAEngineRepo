using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using QAEngine.Application.Customers.Command;

namespace QAEngine.Application.Customers.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .MaximumLength(8).WithMessage("Customer Id has maximum length of 8 characters")
                .NotEmpty().WithMessage("Customer Id is required!");

            RuleFor(x => x.Title).MaximumLength(5);
            RuleFor(x => x.FirstName).MaximumLength(10);
            RuleFor(x => x.LastName).MaximumLength(10);
            RuleFor(x => x.Address).MaximumLength(45);
            RuleFor(x => x.City).MaximumLength(15);
            RuleFor(x => x.Region).MaximumLength(20);
            RuleFor(x => x.Country).MaximumLength(15);
            RuleFor(x => x.PostalCode).MaximumLength(6);
            RuleFor(x => x.Phone).MaximumLength(15);
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of Birth is required!");
        }
    }
}
