using Mediator.Sender;
using System.Reflection;

namespace Mediator
{
    public class Mediator : IMediator
    {
        private IDictionary<Type, IHandler> _handlers = new Dictionary<Type, IHandler>();

        public void RegisterHandler<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse =>
            _handlers.Add(typeof(TRequest), handler);

        public TResponse Send<TResponse>(IRequest<TResponse> request)
            where TResponse : IResponse =>
            (TResponse)typeof(Mediator)
                .GetMethod(nameof(SendWrapper), BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(request.GetType(), typeof(TResponse))
                .Invoke(this, new object[] { request });

        private TResponse SendWrapper<TRequest, TResponse>(TRequest request)
            where TResponse : IResponse
            where TRequest : IRequest<TResponse> =>
            _handlers.TryGetValue(request.GetType(), out IHandler handler)
            ? ((IRequestHandler<TRequest, TResponse>)handler).Handle(request)
            : throw new ArgumentException("Handler not found, please register your handlers.");
    }
}
