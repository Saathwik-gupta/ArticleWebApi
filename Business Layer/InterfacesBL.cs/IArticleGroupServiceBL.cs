using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public interface IArticleGroupServiceBL
{
    IEnumerable<object> GetAllArticleGroups();
    ArticleGroup GetArticleGroupById(int id);
    void AddArticleGroup(ArticleGroup articleGroup);
    void UpdateArticleGroup(ArticleGroup articleGroup);
    void DeleteArticleGroup(int id);
}

}
