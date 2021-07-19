using AutoMapper;
using BreweryManagment.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Features.Beer.Commands.DeleteBeer
{
    public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand, DeleteBeerCommandResponse>
    {
        private readonly IBeerRepository _repository;
        private readonly IMapper _mapper;

        public DeleteBeerCommandHandler(IMapper mapper, IBeerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DeleteBeerCommandResponse> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteBeerCommandResponse();

            try
            {
                var validator = new DeleteBeerCommandValidator();
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
                    await _repository.DeleteAsync(request.Id);
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
