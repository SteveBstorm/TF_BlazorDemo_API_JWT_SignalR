using Demo_API_JWT_SignalR.Models;

namespace Demo_API_JWT_SignalR.Services
{
    public class ArticleService
    {
        private List<Article> ArticleList { get; set; }

        public ArticleService()
        {
            ArticleList = new List<Article>();
            ArticleList.Add(new Article
            {
                Id = 1,
                Label = "Lu",
                Price = 10,
                Description = "Approuvé"
            });
        }

        public List<Article> GetAll()
        {
            return ArticleList;
        }

        public Article GetById(int id)
        {
            return ArticleList.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Article a)
        {
            ArticleList.Add(a);
        }
    }
}
