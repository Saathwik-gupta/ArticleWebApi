using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleWebApi.DTO;
using ArticleWebApi.Models ;


namespace ArticleWebApi.Services
{
    public interface IArticleServiceBL
    {
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(int articleId);
        void AddArticle(Article article);

        void UpdateArticle (Article article);
        void UpdateArticleFields(int articleId, ArticleDTO articleDTO);
        void DeleteArticle(int articleId);
    }
}
