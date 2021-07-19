using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote
{
    public class RequestQuoteCommandValidator : AbstractValidator<RequestQuoteCommand>
    {
        public RequestQuoteCommandValidator()
        {
            RuleFor(p => p.Quote.WholesalerId)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull();

            RuleFor(p => p.Quote.QuoteDetails)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
