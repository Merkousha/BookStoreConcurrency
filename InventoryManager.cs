using System;
using System.Threading.Tasks;

namespace BookStoreConcurrency
{
    public static class InventoryManager
    {
        public static void ManageInventoryWithTasks()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => UpdateInventory("Book A", 10));
            tasks[1] = Task.Run(() => UpdateInventory("Book B", 5));
            tasks[2] = Task.Run(() => UpdateInventory("Book C", 20));

            Task.WaitAll(tasks);
        }

        private static void UpdateInventory(string bookName, int quantity)
        {
            Console.WriteLine($"Updating inventory for {bookName} on Thread {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(1000).Wait(); // شبیه‌سازی عملیات زمان‌بر
            Console.WriteLine($"Inventory updated for {bookName}: {quantity} items.");
        }
    }
}
