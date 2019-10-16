using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using PrimeMusicStore.Service;

namespace PrimeMusicStore.Server.Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5051");
            var client = new AlbumService.AlbumServiceClient(channel);

            using (var call = client.GetAll(new EmptyRequest()))
            {
                while (await call.ResponseStream.MoveNext(default))
                {
                    var album = call.ResponseStream.Current;
                    Console.WriteLine(album.Title);
                }
            }

            //Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
