using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.DTO;
using ArticleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleWebApi.DAL
{
    public class ArticleServiceDAL : IArticleServiceDAL
    {
        private readonly ArticleContext _context;

        public ArticleServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAllArticles()
        {
            // Return only articles that are not marked as deleted
            return _context.Articles.Where(a => !a.IsActive).ToList();
        }

        public Article GetArticleById(int articleId)
        {
            // Fetch the article by ID, taking into account soft deletion
            return _context.Articles.FirstOrDefault(a => a.ArticleId == articleId);
        }

        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void UpdateArticleFields(int articleId, ArticleDTO articleDto)
        {
            var article = _context.Articles.Find(articleId);
            if (article != null)
            {
                // Update only the Title and Content using the DTO
                article.Title = articleDto.Title;
                article.Content = articleDto.Content;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Article not found.");
            }
        }


        public void DeleteArticle(int articleId)
        {
            var article = _context.Articles.Find(articleId);
            if (article != null)
            {
                
                article.IsActive = false; 

                _context.Articles.Update(article); 
                _context.SaveChanges(); 
            }
        }
    }
}