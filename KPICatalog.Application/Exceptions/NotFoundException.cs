namespace KPICatalog.Application;

public class NotFoundException : Exception
{
    private const string BaseMessage = "Object wasn't found. ";

    public NotFoundException(string message) 
        : base(BaseMessage + message)
    { }

    public NotFoundException()
    : base(BaseMessage)
    { }
}
