using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public interface IStateServiceDAL
    {
        IEnumerable<State> GetAllStates();
        State GetStateById(int stateId);
        void AddState(State state);
        void UpdateState(State state);
        void DeleteState(int stateId);
    }
}
