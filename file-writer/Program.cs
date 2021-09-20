using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace QueueServiceWrite
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            QueueClient queue = new QueueClient(connectionString, "text-lines");

            if (await queue.ExistsAsync())
            {
                QueueProperties properties = await queue.GetPropertiesAsync();
                if (properties.ApproximateMessagesCount > 0)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine("D:", "TMP", "WriteLines.txt"), true))
                    {
                        for (int i = 0; i < properties.ApproximateMessagesCount; i++)
                        {
                            string value = await RetrieveNextMessageAsync(queue);
                            outputFile.WriteLine(value);
                            Console.WriteLine($"Received: {value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The queue is empty.");
                }
            }
            else
            {
                Console.WriteLine("The queue does not exist. Add a message to the command line to create the queue and store the message.");
            }
        }
        static async Task<string> RetrieveNextMessageAsync(QueueClient theQueue)
        {
            QueueMessage[] retrievedMessage = await theQueue.ReceiveMessagesAsync(1);
            string theMessage = retrievedMessage[0].Body.ToString();
            await theQueue.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            return theMessage;
        }
    }
}