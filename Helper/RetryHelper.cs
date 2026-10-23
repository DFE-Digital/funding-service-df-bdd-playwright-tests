
namespace PlaywrightBDD.Helpers
{
    public static class RetryHelper
    {
        public static async Task RetryAsync(Func<Task> action, int maxRetries = 3, int delayMilliseconds = 1000)
        {
            int attempt = 0;
            while (attempt < maxRetries)
            {
                try
                {
                    await action();
                    return;
                }
                catch (Exception ex)
                {
                    attempt++;
                    if (attempt >= maxRetries)
                        throw new Exception($"Operation failed after {maxRetries} attempts.", ex);

                    await Task.Delay(delayMilliseconds);
                }
            }
        }
    }
}