using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation.Domain.Models;
using QuadraticEquation.Domain.Commands;
using QuadraticEquation.Domain.Queries;

namespace QuadraticEquation.WPF.Stores
{
    public class QuadraticEquationsStore
    {
        private readonly IGetAllQuadraticEquationsQuery _getAllQuadraticEquationsQuery;
        private readonly ICreateQuadraticEquationCommand _createQuadraticEquationCommand;
        private readonly IUpdateQuadraticEquationCommand _updateQuadraticEquationCommand;
        private readonly IDeleteQuadraticEquationCommand _deleteQuadraticEquationCommand;

        private readonly List<Domain.Models.QuadraticEquation> _quadraticEquations;
        public IEnumerable<Domain.Models.QuadraticEquation> QuadraticEquations => _quadraticEquations;
        public QuadraticEquationsStore(
                IGetAllQuadraticEquationsQuery getAllQuadraticEquationsQuery, 
                ICreateQuadraticEquationCommand createQuadraticEquationCommand, 
                IUpdateQuadraticEquationCommand updateQuadraticEquationCommand, 
                IDeleteQuadraticEquationCommand deleteQuadraticEquationCommand)
        {
            _getAllQuadraticEquationsQuery = getAllQuadraticEquationsQuery;
            _createQuadraticEquationCommand = createQuadraticEquationCommand;
            _updateQuadraticEquationCommand = updateQuadraticEquationCommand;
            _deleteQuadraticEquationCommand = deleteQuadraticEquationCommand;

            _quadraticEquations = new List<Domain.Models.QuadraticEquation>();
        }

        public event Action QuadraticEquationLoaded;
        public event Action<Domain.Models.QuadraticEquation> QuadraticEquationAdded;
        public event Action<Domain.Models.QuadraticEquation> QuadraticEquationUpdated;
        public event Action<Guid> QuadraticEquationDeleted;

        public async Task Load()
        {
            IEnumerable<Domain.Models.QuadraticEquation> quadraticEquations = await _getAllQuadraticEquationsQuery.Execute();
            _quadraticEquations.Clear();
            _quadraticEquations.AddRange(quadraticEquations);
            QuadraticEquationLoaded?.Invoke();
        }
        public async Task Add(Domain.Models.QuadraticEquation quadraticEquation)
        {
            await _createQuadraticEquationCommand.Execute(quadraticEquation);
            _quadraticEquations.Add(quadraticEquation);
            QuadraticEquationAdded?.Invoke(quadraticEquation);
        }
        public async Task Update(Domain.Models.QuadraticEquation quadraticEquation)
        {
            await _updateQuadraticEquationCommand.Execute(quadraticEquation);

            int currentIndex = _quadraticEquations.FindIndex(y => y.Id == quadraticEquation.Id);
            if (currentIndex != -1)
            {
                _quadraticEquations[currentIndex] = quadraticEquation;
            }
            else
            {
                _quadraticEquations.Add(quadraticEquation);
            }

            QuadraticEquationUpdated?.Invoke(quadraticEquation);
        }
        public async Task Delete(Guid id)
        {
            await _deleteQuadraticEquationCommand.Execute(id);
            _quadraticEquations.RemoveAll(y => y.Id == id);
            QuadraticEquationDeleted?.Invoke(id);
        }
    }
}
