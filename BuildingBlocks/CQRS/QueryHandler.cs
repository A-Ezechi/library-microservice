using MediatR;

namespace library_MicroService.BuildingBlocks.CQRS
{
    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, Unit>
        where TQuery : IQuery, IRequest<Unit>
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : notnull
    {
    }
}