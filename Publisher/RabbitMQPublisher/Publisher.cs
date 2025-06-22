using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,  //declarar o que mandar na queue = "hello"
    arguments: null);

Console.WriteLine("Da lista de compras o que deseja comprar? (1 - Iogurtes) / (2 - Queijo) / (3 - Proteína)");
string string1 = Console.ReadLine();
if(string1 == "1")
{
    const string message = "Iogurtes";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body); //declarar o que mandar na routingKey = "hello"
    Console.WriteLine($" [x] Sent {message}");
} else if(string1 == "2")
{
    const string message = "Queijo";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
    Console.WriteLine($" [x] Sent {message}");
} else if(string1 == "3")
{
    const string message = "Proteína";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
    Console.WriteLine($" [x] Sent {message}");
} else
{
    Console.WriteLine("erro");
}


    Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();