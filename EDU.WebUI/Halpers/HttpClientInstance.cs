namespace EDU.WebUI.Halpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7234/api/");
            return client;
        }
        
    }
}

