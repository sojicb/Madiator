using Mediator.Sender;

namespace Mediator
{
    public interface ISender
    {
        TResponse Send<TResponse>(IRequest<TResponse> response)
            where TResponse : IResponse;
    }
}
