namespace WebJob1Test
{
    //
    public static class Config
    {
        public static string GetConnectionString()
        {
            var hash = "gFIBE/TksQEIyOxCCi/6fnzN4PKnRvvAWbQIKL4MZ7MO77Z7Q+vZPDWqmon7B48spiG0hBhEQWd3eiFzpZDMnA==";
            var accountName = "domar";

            return $"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={hash};EndpointSuffix=core.windows.net;";
        }
    }
}
