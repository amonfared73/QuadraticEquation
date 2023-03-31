using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.WPF.Commands
{
    public class OpenAddQuadraticEquationCommand : CommandBase
    {
        private readonly QuadraticEquationsStore _quadraticEquationsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddQuadraticEquationCommand(QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            _quadraticEquationsStore = quadraticEquationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddQuadraticEquationViewModel addQuadraticEquationView = new AddQuadraticEquationViewModel(_quadraticEquationsStore,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addQuadraticEquationView;
        }
    }
}
