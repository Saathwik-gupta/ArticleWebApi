using System.Collections.Generic;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public interface IStateServiceBL
    {
        IEnumerable<State> GetAllStates();
        State GetStateById(int stateId);
        void AddState(State state);
        void UpdateState(State state);
        void DeleteState(int stateId);
    }
}
