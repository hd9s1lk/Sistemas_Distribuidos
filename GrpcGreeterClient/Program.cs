using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

class Program
{
    static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("http://localhost:5136");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "GrpcGreeterClient" });
        var reply2 = await client.MandarIDAsync(new wavyID { ID = "1" });

        Console.WriteLine("Greeting: " + reply.Message);
        Console.WriteLine(reply2.IDrecebida);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
