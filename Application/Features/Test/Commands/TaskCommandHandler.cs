using Application.Common.Interfaces;
using Application.Dtos.Test;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Test.Commands;

public class TaskCommandHandler: IRequestHandler<CreateTestCommand, Result<TestSimpleDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public TaskCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<Result<TestSimpleDto>> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}