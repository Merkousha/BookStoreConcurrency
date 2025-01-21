using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreConcurrency
{
    public static class AsyncOperations
    {
        public static async Task FetchBookDetailsAsync()
        {
            string bookApiUrl = "https://jsonplaceholder.typicode.com/posts/1"; // شبیه‌سازی یک API

            Console.WriteLine($"Fetching book details from API on Thread {Thread.CurrentThread.ManagedThreadId}");
            var httpClient = new HttpClient();

            string response = await httpClient.GetStringAsync(bookApiUrl);

            Console.WriteLine($"Book details received: {response.Substring(0, 50)}..."); // نمایش قسمتی از پاسخ
        }
    }
}
