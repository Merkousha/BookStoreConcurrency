using System;
using System.Threading;

namespace BookStoreConcurrency
{
    public static class OrderProcessor
    {
        public static void ProcessOrdersWithThreads()
        {
            Thread thread1 = new Thread(() => ProcessOrder(1));
            Thread thread2 = new Thread(() => ProcessOrder(2));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private static void ProcessOrder(int orderId)
        {
            Console.WriteLine($"Order {orderId} is being processed on Thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000); // شبیه‌سازی پردازش زمان‌بر
            Console.WriteLine($"Order {orderId} completed!");
        }
    }
}
