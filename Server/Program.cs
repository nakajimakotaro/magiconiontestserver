using System;
using Game.Shared.Service;
using UnityEngine;
using MagicOnion;
using MagicOnion.Server;
using Grpc.Core;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());
        var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);
        var server = new global::Grpc.Core.Server
        {
            Services = { service},
            Ports = {new ServerPort("localhost", 12345, ServerCredentials.Insecure)}
        };
        server.Start();
        Console.ReadLine();
    }
}
public class ChatService : ServiceBase<IChatService>, IChatService
{
    public async UnaryResult<(Vector3, string)> OnMessage(Data data)
    {
        await Task.CompletedTask;
        return (data.Pos, data.Message);
    }
}
