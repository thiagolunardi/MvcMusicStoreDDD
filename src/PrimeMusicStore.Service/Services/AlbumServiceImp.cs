using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using PrimeMusicStore.Application.Interfaces;

namespace PrimeMusicStore.Service
{
    public class AlbumServiceImp : AlbumService.AlbumServiceBase
    {
        private readonly IAlbumAppService _albumAppService;
        private readonly ILogger _logger;

        public AlbumServiceImp(
            IAlbumAppService albumAppService,
            ILogger<AlbumServiceImp> logger)
        {
            _albumAppService = albumAppService;
            _logger = logger;
        }

        public override async Task GetAll(EmptyRequest request, IServerStreamWriter<AlbumReply> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("Getting all albums.");

            await foreach (var album in _albumAppService.AllAsync())
            {
                await responseStream.WriteAsync(new AlbumReply 
                {
                    Title = album.Title
                });
            }            
        }
    }
}
