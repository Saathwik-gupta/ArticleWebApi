using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.DTO;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public class ArticleServiceBL : IArticleServiceBL
    {
        private readonly IArticleServiceDAL _articleDAL;

        public ArticleServiceBL(IArticleServiceDAL articleDAL)
        {
            _articleDAL = articleDAL;
        }

        public IEnumerable<Article> GetAllArticles()
        {
            // Fetch all articles that are not marked as deleted
            return _articleDAL.GetAllArticles();
        }

        public Article GetArticleById(int articleId)
        {
            // Retrieve article by ID
            return _articleDAL.GetArticleById(articleId);
        }

        public void AddArticle(Article article)
        {
            // Add a new article
            _articleDAL.AddArticle(article);
        }

        // Method 1: Update the entire article entity
        public void UpdateArticle(Article article)
        {
            // Update the entire article entity
            _articleDAL.UpdateArticle(article);
        }

        // Method 2: Update only title and content
        public void UpdateArticleFields(int articleId, ArticleDTO articleDTO)
        {
            // Update only the title and content fields
            _articleDAL.UpdateArticleFields(articleId, articleDTO);
        }

        public void DeleteArticle(int articleId)
        {
            //Soft Delete --> Setting the IsActive property as false
            _articleDAL.DeleteArticle(articleId);
        }
    }
}
