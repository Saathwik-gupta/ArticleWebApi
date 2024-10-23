using System.Collections.Generic;
using ArticleWebApi.DTO;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public interface IArticleServiceDAL
    {
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(int articleId);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        void UpdateArticleFields(int articleId, ArticleDTO articleDto);
        void DeleteArticle(int articleId);
    }
}
