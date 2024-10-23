using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;
using System.Collections.Generic;
using ArticleWebApi.DTO;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServiceBL _articleService;

        public ArticleController(IArticleServiceBL articleService)
        {
            _articleService = articleService;
        }

        // GET: api/Article
        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetAllArticles()
        {
            var articles = _articleService.GetAllArticles();
            return Ok(articles);
        }

        // GET: api/Article/{id}
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticleById(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound("Article not found");
            }

            return Ok(article);
        }

        // POST: api/Article
        [HttpPost]
        public ActionResult AddArticle([FromBody] Article article)
        {
            if (ModelState.IsValid)
            {
                _articleService.AddArticle(article);
                return Ok("Article added successfully");
            }

            return BadRequest("Invalid data");
        }

        
    // PUT: api/Article/{id} - Update entire article
    [HttpPut("{id}")]
    public ActionResult UpdateArticle(int id, [FromBody] Article updatedArticle)
    {
        var existingArticle = _articleService.GetArticleById(id);
        if (existingArticle == null)
        {
            return NotFound("Article not found");
        }

        if (ModelState.IsValid)
        {
            // Ensure the ArticleId is set correctly
            updatedArticle.ArticleId = id;

            // Update the article
            _articleService.UpdateArticle(updatedArticle);
            return Ok("Article updated successfully");
        }

        return BadRequest("Invalid data");
    }


    // PUT: api/Article/{id} - Update only title and content
    [HttpPatch("{id}")]
    public ActionResult UpdateArticleFields(int id, [FromBody] ArticleDTO articleDto)
    {
        var existingArticle = _articleService.GetArticleById(id);
        if (existingArticle == null)
        {
            return NotFound("Article not found");
        }

        if (ModelState.IsValid)
        {
            // Update the Title and Content fields
            _articleService.UpdateArticleFields(id, articleDto);
            return Ok("Article updated successfully");
        }

        return BadRequest("Invalid data");
    }


        // DELETE: api/Article/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound("Article not found");
            }

            _articleService.DeleteArticle(id);
            return Ok("Article deleted successfully (soft delete)");
        }
    }
}
