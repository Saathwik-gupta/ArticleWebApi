using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;
using System.Linq;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleGroupsController : ControllerBase
    {
        // Use the interface IArticleGroupServiceBL instead of the concrete class
        private readonly IArticleGroupServiceBL _articleGroupService;

        // Inject the service using the interface
        public ArticleGroupsController(IArticleGroupServiceBL articleGroupService)
        {
            _articleGroupService = articleGroupService;
        }

        // GET: api/articlegroups
        [HttpGet]
        public IActionResult GetArticleGroups()
        {
            // Retrieve all article groups with their associated ArticleIds
            var articleGroups = _articleGroupService.GetAllArticleGroups();
            return Ok(articleGroups);
        }

        // GET: api/articlegroups/5
        [HttpGet("{id}")]
        public IActionResult GetArticleGroup(int id)
        {
            var articleGroup = _articleGroupService.GetArticleGroupById(id);
            if (articleGroup == null)
            {
                return NotFound();
            }
            // Return the specific article group along with associated ArticleIds
            return Ok(new
            {
                ArticleGroupId = articleGroup.ArticleGroupId,
                GroupName = articleGroup.GroupName,
                ArticleIds = articleGroup.Article_ArticleGroups.Select(a => a.ArticleId) // Select only ArticleIds
            });
        }

        // POST: api/articlegroups
        [HttpPost]
        public IActionResult PostArticleGroup([FromBody] ArticleGroup articleGroup)
        {
            if (articleGroup == null)
            {
                return BadRequest();
            }

            _articleGroupService.AddArticleGroup(articleGroup);
            return CreatedAtAction(nameof(GetArticleGroup), new { id = articleGroup.ArticleGroupId }, articleGroup);
        }

        // PUT: api/articlegroups/5
        [HttpPut("{id}")]
        public IActionResult PutArticleGroup(int id, [FromBody] ArticleGroup articleGroup)
        {
            if (id != articleGroup.ArticleGroupId || articleGroup == null)
            {
                return BadRequest();
            }

            _articleGroupService.UpdateArticleGroup(articleGroup);
            return NoContent();
        }

        // DELETE: api/articlegroups/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArticleGroup(int id)
        {
            var existingGroup = _articleGroupService.GetArticleGroupById(id);
            if (existingGroup == null)
            {
                return NotFound();
            }

            _articleGroupService.DeleteArticleGroup(id);
            return NoContent();
        }
    }
}
