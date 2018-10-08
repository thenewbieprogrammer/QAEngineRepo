using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using QAEngine.Application.Customers.Command;

namespace QAEngine.Application.Customers.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Title).MaximumLength(6).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(60).NotEmpty();
            RuleFor(x => x.City).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Region).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Country).MaximumLength(20).NotEmpty();
            RuleFor(x => x.PostalCode).MaximumLength(10).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(20).NotEmpty();
        }
    }
}
