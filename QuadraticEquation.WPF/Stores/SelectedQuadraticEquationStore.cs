using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation.Domain.Models;

namespace QuadraticEquation.WPF.Stores
{
    public class SelectedQuadraticEquationStore
    {
        private Domain.Models.QuadraticEquation _selectedQuadraticEquation;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;


        public Domain.Models.QuadraticEquation SelectedQuadraticEquation
        {
            get
            {
                return _selectedQuadraticEquation;
            }
            set
            {
                _selectedQuadraticEquation = value;
                SelectedQuadraticEquationChanged?.Invoke();
            }
        }

        public event Action SelectedQuadraticEquationChanged;
        public SelectedQuadraticEquationStore(QuadraticEquationsStore quadraticEquationsStore)
        {
            _quadraticEquationsStore = quadraticEquationsStore;
            _quadraticEquationsStore.QuadraticEquationUpdated += QuadraticEquationsStore_QuadraticEquationUpdated;
        }

        private void QuadraticEquationsStore_QuadraticEquationUpdated(Domain.Models.QuadraticEquation quadraticEquation)
        {
            if (quadraticEquation.Id == SelectedQuadraticEquation?.Id)
            {
                SelectedQuadraticEquation = quadraticEquation;
            }
        }
    }
}
