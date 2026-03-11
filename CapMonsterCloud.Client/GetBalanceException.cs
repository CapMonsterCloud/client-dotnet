namespace Zennolab.CapMonsterCloud;

/// <summary>
/// Exception on getting balance
/// </summary>
public class GetBalanceException(ErrorType error)
    : CapmonsterCloudClientException($"Cannot get balance. Error was {error}")
{
    /// <summary>
    /// Gets occured error
    /// </summary>
    public ErrorType Error { get; } = error;
}
