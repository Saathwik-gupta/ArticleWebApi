using System.Collections.Generic;
using System.Linq;
using ArticleWebApi.Data;
using ArticleWebApi.Models;

namespace ArticleWebApi.DAL
{
    public class StateServiceDAL : IStateServiceDAL
    {
        private readonly ArticleContext _context;

        public StateServiceDAL(ArticleContext context)
        {
            _context = context;
        }

        public IEnumerable<State> GetAllStates()
        {
            return _context.States.ToList();
        }

        public State GetStateById(int stateId)
        {
            return _context.States.Find(stateId);
        }

        public void AddState(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }

        public void UpdateState(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
        }

        public void DeleteState(int stateId)
        {
            var state = _context.States.Find(stateId);
            if (state != null)
            {
                _context.States.Remove(state);
                _context.SaveChanges();
            }
        }
    }
}
