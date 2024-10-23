using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public class ArticleGroupServiceDAL : IArticleGroupServiceDAL
    {
        private readonly ArticleContext _context;

        public ArticleGroupServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetAllArticleGroups()
        {
            // Returning a projection that includes ArticleGroupId, GroupName, and associated ArticleIds
            return _context.ArticleGroups.Select(ag => new
            {
                ArticleGroupId = ag.ArticleGroupId,
                GroupName = ag.GroupName,
                ArticleIds = ag.Article_ArticleGroups.Select(aag => aag.ArticleId).ToList() // Get only ArticleIds
            }).ToList();
        }

        public ArticleGroup GetArticleGroupById(int articleGroupId)
        {
            return _context.ArticleGroups.Find(articleGroupId);
        }

        public void AddArticleGroup(ArticleGroup articleGroup)
        {
            _context.ArticleGroups.Add(articleGroup);
            _context.SaveChanges();
        }

        public void UpdateArticleGroup(ArticleGroup articleGroup)
        {
            _context.ArticleGroups.Update(articleGroup);
            _context.SaveChanges();
        }

        public void DeleteArticleGroup(int articleGroupId)
        {
            var articleGroup = _context.ArticleGroups.Find(articleGroupId);
            if (articleGroup != null)
            {
                _context.ArticleGroups.Remove(articleGroup);
                _context.SaveChanges();
            }
        }
    }
}
