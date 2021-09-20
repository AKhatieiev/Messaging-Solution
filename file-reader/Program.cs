using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace QueueServiceRead
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            QueueClient queue = new QueueClient(connectionString, "text-lines");

            var lines = File.ReadLines(Path.Combine("D:", "TMP", "FileBefore.txt"));
            foreach (var line in lines)
            {
                await InsertMessageAsync(queue, line);
                Console.WriteLine($"Sent: {line}");
            }
        }

        static async Task InsertMessageAsync(QueueClient theQueue, string newMessage)
        {
            if (null != await theQueue.CreateIfNotExistsAsync())
            {
                Console.WriteLine("The queue was created.");
            }

            await theQueue.SendMessageAsync(newMessage);
        }
    }
}
