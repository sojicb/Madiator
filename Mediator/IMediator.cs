using Mediator.Publisher;
using Mediator.Sender;

namespace Mediator
{
    public interface IMediator : ISender, IPublisher
    {
        void RegisterHandler<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse;
    }
}
