using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public class ArticleGroupServiceBL : IArticleGroupServiceBL
    {
        private readonly IArticleGroupServiceDAL _articleGroupDAL;

        public ArticleGroupServiceBL(IArticleGroupServiceDAL articleGroupDAL)
        {
            _articleGroupDAL = articleGroupDAL;
        }

        public IEnumerable<object> GetAllArticleGroups()
        {
            return _articleGroupDAL.GetAllArticleGroups(); 
        }

        public ArticleGroup GetArticleGroupById(int articleGroupId)
        {
            return _articleGroupDAL.GetArticleGroupById(articleGroupId);
        }

        public void AddArticleGroup(ArticleGroup articleGroup)
        {
            _articleGroupDAL.AddArticleGroup(articleGroup);
        }

        public void UpdateArticleGroup(ArticleGroup articleGroup)
        {
            _articleGroupDAL.UpdateArticleGroup(articleGroup);
        }

        public void DeleteArticleGroup(int articleGroupId)
        {
            _articleGroupDAL.DeleteArticleGroup(articleGroupId);
        }
    }
}
