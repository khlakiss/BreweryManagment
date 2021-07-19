using AutoMapper;
using BreweryManagment.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Features.Beer.Commands.CreateBeer
{
    public class CreateBeerCommandHandler : IRequestHandler<CreateBeerCommand, CreateBeerCommandResponse>
    {
        private readonly IBeerRepository _repository;
        private readonly IMapper _mapper;

        public CreateBeerCommandHandler(IMapper mapper, IBeerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CreateBeerCommandResponse> Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateBeerCommandResponse();

            var validator = new CreateBeerCommandValidator();
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
                var entity = _mapper.Map<Domain.Entities.Beer>(request.Beer);
                await _repository.AddAsync(entity);
                response.Beer.Name = entity.Name;
                response.Beer.Price = entity.Price.Value;
                response.Beer.AlcoholPercentage = entity.AlcoholPercentage.Value;
                response.Beer.BreweryId = entity.BreweryId;
                response.Beer.Id = entity.Id;
            }

            return response;
        }
    }
}
