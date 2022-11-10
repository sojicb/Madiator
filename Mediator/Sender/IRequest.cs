namespace Mediator.Sender
{
    public interface IRequest<TResponse>
        where TResponse : IResponse
    { }
}
