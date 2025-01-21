using System;
using System.Threading.Tasks;

namespace BookStoreConcurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to BookStore Concurrency!");

            // مثال Thread
            Console.WriteLine("\n--- Example: Thread ---");
            OrderProcessor.ProcessOrdersWithThreads();

            // مثال Task
            Console.WriteLine("\n--- Example: Task ---");
            InventoryManager.ManageInventoryWithTasks();

            // مثال Async/Await
            Console.WriteLine("\n--- Example: Async/Await ---");
            await AsyncOperations.FetchBookDetailsAsync();

            Console.WriteLine("\nAll operations completed!");
        }
    }
}
