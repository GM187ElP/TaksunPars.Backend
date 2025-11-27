using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResources.Application.Handlers.Commands.City;

public class AddCityAsyncCommandHandler : IRequestHandler<AddCityAsyncCommand, ResultStatus>
{
    public Task<ResultStatus> Handle(AddCityAsyncCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
