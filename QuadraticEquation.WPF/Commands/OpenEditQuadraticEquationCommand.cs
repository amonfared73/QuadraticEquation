using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.WPF.Commands
{
    public class OpenEditQuadraticEquationCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly QuadraticEquationListingItemViewModel _quadraticEquationListingItemViewModel;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;

        public OpenEditQuadraticEquationCommand(QuadraticEquationListingItemViewModel quadraticEquationListingItemViewModel, QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            _quadraticEquationListingItemViewModel = quadraticEquationListingItemViewModel;
            _quadraticEquationsStore = quadraticEquationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            Domain.Models.QuadraticEquation quadraticEquation = _quadraticEquationListingItemViewModel.QuadraticEquation;
            EditQuadraticEquationViewModel editQuadraticEquationView = new EditQuadraticEquationViewModel(quadraticEquation,_quadraticEquationsStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editQuadraticEquationView;
        }
    }
}
