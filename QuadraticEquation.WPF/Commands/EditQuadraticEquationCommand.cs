using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.WPF.Commands
{
    public class EditQuadraticEquationCommand : AsyncCommandBase
    {
        private readonly EditQuadraticEquationViewModel _editQuadraticEquationViewModel;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditQuadraticEquationCommand(EditQuadraticEquationViewModel editQuadraticEquationViewModel, QuadraticEquationsStore quadraticEquationsStore, ModalNavigationStore modalNavigationStore)
        {
            _editQuadraticEquationViewModel = editQuadraticEquationViewModel;
            _quadraticEquationsStore = quadraticEquationsStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            QuadraticEquationDetailsFormViewModel formViewModel = _editQuadraticEquationViewModel.QuadraticEquationDetailsFormViewModel;
            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;
            Domain.Models.QuadraticEquation quadraticEquation = new Domain.Models.QuadraticEquation(_editQuadraticEquationViewModel.QuadraticEquationId, formViewModel.A, formViewModel.B, formViewModel.C);
            await quadraticEquation.Solve();
            try
            {
                await _quadraticEquationsStore.Update(quadraticEquation);
                
                _modalNavigationStore.Close();

            }
            catch (Exception ex)
            {
                formViewModel.ErrorMessage = "Failed to update Quadratic Equation. Please try again later.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}
