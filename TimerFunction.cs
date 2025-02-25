using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class TimerFunction
{
    private readonly ILogger<TimerFunction> _logger;

    public TimerFunction(ILogger<TimerFunction> logger)
    {
        _logger = logger;
    }

    //<docsnippet_fixed_delay_retry_example>
    [Function(nameof(TimerFunction))]
    [FixedDelayRetry(5, "00:00:10")]
    public void TimerFunctionHandler([TimerTrigger("0 */1 * * * *")] TimerInfo timerInfo,
        FunctionContext context)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
}