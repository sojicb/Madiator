using Mediator.Sender;

namespace Mediator
{
    public interface IHandler { }

    public interface IRequestHandler<TRequest, TResponse> : IHandler
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
    {
        TResponse Handle(TRequest request);
    }
}
