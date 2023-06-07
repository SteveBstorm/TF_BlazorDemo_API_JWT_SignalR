using Microsoft.AspNetCore.SignalR;

namespace Demo_API_JWT_SignalR.Hubs
{
    public class ArticleHub : Hub
    {
        public async Task NewArticle()
        {
            await Clients.All.SendAsync("GetArticle");
        }
    }
}
