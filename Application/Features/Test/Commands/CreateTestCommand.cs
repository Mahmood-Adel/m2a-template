using Application.Dtos.Test;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Test.Commands;

public class CreateTestCommand: IRequest<Result<TestSimpleDto>>
{
    public string Name { get; set; }
}