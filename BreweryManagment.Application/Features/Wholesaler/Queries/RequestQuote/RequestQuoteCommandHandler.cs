using AutoMapper;
using BreweryManagment.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote
{
    public class RequestQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, RequestQuoteCommandResponse>
    {
        private readonly IWholesalerRepository _repository;
        private readonly IMapper _mapper;

        public RequestQuoteCommandHandler(IMapper mapper, IWholesalerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<RequestQuoteCommandResponse> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
        {
            var response = new RequestQuoteCommandResponse();

            try
            {
                var validator = new RequestQuoteCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        response.ValidationErrors.Add(error.ErrorMessage);
                    }
                }

                if (response.Success)
                {
                    //Check if the order has duplicates
                    var duplicates = await _repository.CheckDuplicateOrder(request.Quote.QuoteDetails);
                    if (duplicates)
                    {
                        response.Success = false;
                        response.ValidationErrors = new List<string>();
                        response.ValidationErrors.Add("Order submited contains dupplicates");
                        return response;
                    }

                    response.QuoteResponse = await _repository.RequestQuote(request.Quote);
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
