using AutoMapper;
using BreweryManagment.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity
{
    public class UpdateStockQuantityCommandHandler : IRequestHandler<UpdateStockQuantityCommand, UpdateStockQuantityCommandResponse>
    {
        private readonly IWholesalerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStockQuantityCommandHandler(IMapper mapper, IWholesalerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UpdateStockQuantityCommandResponse> Handle(UpdateStockQuantityCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStockQuantityCommandResponse();

            var validator = new UpdateStockQuantityCommandValidator();
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
                var entity = _mapper.Map<Domain.Entities.WholesalerBeer>(request.WholesaleBeer);
                await _repository.UpdateAsync(entity);
                response.WholesaleBeer.BeerId = entity.BeerId;
                response.WholesaleBeer.WholesalerId = entity.WholesalerId;
                response.WholesaleBeer.Quantity = entity.StockQuantity.Value;
                response.WholesaleBeer.Id = entity.Id;
            }

            return response;
        }
    }
}
