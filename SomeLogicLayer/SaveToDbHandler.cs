using Mediator;
using Mediator.Sender;

namespace SomeLogicLayer
{
    public class SaveToDbHandler : IRequestHandler<SaveToDbCommand, SaveToDbResponse>
    {
        public SaveToDbResponse Handle(SaveToDbCommand request)
        {
            return new SaveToDbResponse();
        }
    }

    public class SaveToDbCommand : IRequest<SaveToDbResponse>
    {

    }

    public class SaveToDbResponse : IResponse
    {

    }
}
