using System.Collections.Generic;
using ArticleWebApi.DAL;
using ArticleWebApi.Models;

namespace ArticleWebApi.Services
{
    public class StateServiceBL : IStateServiceBL
    {
        private readonly IStateServiceDAL _stateServiceDAL;

        public StateServiceBL(IStateServiceDAL stateServiceDAL)
        {
            _stateServiceDAL = stateServiceDAL;
        }

        public IEnumerable<State> GetAllStates()
        {
            return _stateServiceDAL.GetAllStates();
        }

        public State GetStateById(int stateId)
        {
            return _stateServiceDAL.GetStateById(stateId);
        }

        public void AddState(State state)
        {
            _stateServiceDAL.AddState(state);
        }

        public void UpdateState(State state)
        {
            _stateServiceDAL.UpdateState(state);
        }

        public void DeleteState(int stateId)
        {
            _stateServiceDAL.DeleteState(stateId);
        }
    }
}
