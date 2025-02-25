using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class EventHubFunction
{
    private readonly ILogger<EventHubFunction> _logger;

    public EventHubFunction(ILogger<EventHubFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Function.EventHubFunction))]
    [FixedDelayRetry(5, "00:00:10")]
    [EventHubOutput("functions-csharp-dest", Connection = "EventHubConnection")]
    public string EventHubFunctionHandler(
        [EventHubTrigger("functions-csharp-src", Connection = "EventHubConnection")] string[] input,
        FunctionContext context)
    {
        _logger.LogInformation("First Event Hubs triggered message: {msg}", input[0]);

        var message = $"Output message created at {DateTime.Now}";
        return message;
    }
    
}