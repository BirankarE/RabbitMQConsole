using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.HostName = "localhost";

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("MyQueue", false, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("MyQueue", false, consumer);
    consumer.Received += (sender, e) =>
    {
        //e.Body : Kuyruktaki mesajı verir.
        Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
    };
}
Console.Read();
