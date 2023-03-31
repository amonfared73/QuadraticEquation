using QuadraticEquation.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation.WPF.ViewModels;

namespace QuadraticEquation.WPF.Commands
{
    public class AddQuadraticEquationCommand : AsyncCommandBase
    {
        private readonly AddQuadraticEquationViewModel _addQuadraticEquationViewModel;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddQuadraticEquationCommand(AddQuadraticEquationViewModel addQuadraticEquationViewModel, QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            _addQuadraticEquationViewModel = addQuadraticEquationViewModel;
            _quadraticEquationsStore = quadraticEquationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            QuadraticEquationDetailsFormViewModel viewModel = _addQuadraticEquationViewModel.QuadraticEquationDetailsFormViewModel;
            Domain.Models.QuadraticEquation quadraticEquation = new Domain.Models.QuadraticEquation(Guid.NewGuid(), viewModel.A, viewModel.B, viewModel.C);
            viewModel.ErrorMessage = null;
            viewModel.IsSubmitting = true;
            await quadraticEquation.Solve();
            try
            {
                await _quadraticEquationsStore.Add(quadraticEquation);
                
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                viewModel.ErrorMessage = "Failed to add Quadratic Equation. Please try again later.";
            }
            finally
            {
                viewModel.IsSubmitting = false;
            }
        }
    }
}
