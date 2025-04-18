using MediatR;

namespace library_MicroService.BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand, IRequest<Unit>
    {
    }

    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : notnull
    {
    }
}