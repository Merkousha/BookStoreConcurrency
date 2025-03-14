using System;
using System.Collections.Concurrent;
using System.Threading;

namespace BookStoreConcurrency
{
    public static class OrderProcessor
    {
        //استفاده از ConcurrentQueue برای جلوگیری از ThreadSafe بودن و جلوگیری از race Condition

        // ایجاد یک ConcurrentQueue برای ذخیره سفارشات
        private static ConcurrentQueue<int> orderQueue = new();
        public static void ProcessOrdersWithThreads()
        {
            for (int i = 1; i <= 10; i++)
                orderQueue.Enqueue(i);
            Thread thread1 = new Thread(() => ProcessOrder());
            Thread thread2 = new Thread(() => ProcessOrder());
            Thread thread3 = new Thread(() => ProcessOrder());
            Thread thread4 = new Thread(() => ProcessOrder());

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            Console.WriteLine("All orders have benn Processed");
        }

        private static void ProcessOrder()
        {
            while (orderQueue.TryDequeue(out int orderId)) // دریافت سفارش از صف به‌صورت Thread-Safe
            {
                Console.WriteLine($"Order {orderId} is being processed on Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000); // شبیه‌سازی پردازش زمان‌بر
                Console.WriteLine($"Order {orderId} completed!");
            }
        }
    }
}
