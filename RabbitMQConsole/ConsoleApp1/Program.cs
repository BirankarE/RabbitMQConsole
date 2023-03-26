using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
//factory.Uri = new Uri("amqp://hkhjerrt:hcqiavAqll6-co4abXnSqUBh_hHifz-Z@hornet.rmq.cloudamqp.com/hkhjerrt");
factory.HostName = "localhost";


using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("MyQueue",false,false,true);
    byte[] byteMessage = Encoding.UTF8.GetBytes("bu benim ilk mesajım");
    channel.BasicPublish(exchange: "", routingKey: "MyQueue", body: byteMessage);

}
