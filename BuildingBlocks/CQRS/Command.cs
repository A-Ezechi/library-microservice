using MediatR;

namespace library_MicroService.BuildingBlocks.CQRS
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}