using Mediator;
using Mediator.Sender;
using SomeLogicLayer;

var mediator = new Mediator.Mediator();
mediator.RegisterHandler(new SaveToDbHandler());
var a = mediator.Send(new SaveToDbCommand());
TestApp TestApp = new TestApp();
TestApp.Test();

public class TestApp
{
    public void Test()
    {
        Mediator.Mediator mediator = new Mediator.Mediator();

        mediator.RegisterHandler(new HandlerTestOne());

        var test = mediator.Send(new RequestTestOne());
    }
}

public class HandlerTestOne : IRequestHandler<RequestTestOne, ResponseTestOne>
{
    public ResponseTestOne Handle(RequestTestOne request)
    {
        return new ResponseTestOne()
        {
            Test = request.Test
        };
    }
}

public class RequestTestOne : IRequest<ResponseTestOne>
{
    public int Test { get; set; } = 3;
}

public class ResponseTestOne : IResponse
{
    public int Test { get; set; } = 5;
}
