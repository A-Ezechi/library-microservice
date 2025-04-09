using MediatR;

namespace library_MicroService.BuildingBlocks.CQRS
{
    public interface IQuery : IRequest<Unit>
    {
    }

    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}