namespace Felicity.Domain.Infrastructure.Classes;

public class OperationResult<T>
{
    public bool Success
    {
        get
        {
            return !this.Messages.Any();
        }
    }

    public IEnumerable<string> Messages { get; set; } = [];
    public T? ResultObject { get; set; }
}
