using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka
{
    class Program
    {
        private const string BootstrapServer = "localhost:9092";
        private const string TopicName = "topic.name";

        private static async Task Main()
        {
            Console.WriteLine("Enter processor code \n1 - Producer\n2 - Consumer");
            var selected = Console.ReadKey(false).KeyChar;
            Console.WriteLine("\n");
            switch (selected)
            {
                case '1':
                    var producer = new Producer(BootstrapServer);
                    await producer.StartSendingMessages(TopicName);
                    break;
                case '2':
                    var consumer = new Consumer(BootstrapServer);
                    consumer.StartReceivingMessages(TopicName);
                    break;
            }

            Console.WriteLine("Closing application");
            Console.ReadKey();
        }
    }
}
