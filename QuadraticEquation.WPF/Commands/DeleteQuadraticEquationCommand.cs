using QuadraticEquation.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation.WPF.ViewModels;

namespace QuadraticEquation.WPF.Commands
{
    public class DeleteQuadraticEquationCommand : AsyncCommandBase
    {
        private readonly QuadraticEquationsStore _quadraticEquationsStore;
        private readonly QuadraticEquationListingItemViewModel _quadraticEquationListingItemViewModel;

        public DeleteQuadraticEquationCommand(QuadraticEquationListingItemViewModel quadraticEquationListingItemViewModel, QuadraticEquationsStore quadraticEquationsStore)
        {
            _quadraticEquationsStore = quadraticEquationsStore;
            _quadraticEquationListingItemViewModel = quadraticEquationListingItemViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _quadraticEquationListingItemViewModel.IsDeleting= true;
            _quadraticEquationListingItemViewModel.ErrorMessage = null;
            Domain.Models.QuadraticEquation quadraticEquation = _quadraticEquationListingItemViewModel.QuadraticEquation;
            try
            {
                await _quadraticEquationsStore.Delete(quadraticEquation.Id);
            }
            catch(Exception)
            {
                _quadraticEquationListingItemViewModel.ErrorMessage = "Failed to delete Quadratic Equation. Please try again later.";
            }
            finally
            {
                _quadraticEquationListingItemViewModel.IsDeleting = false;
            }
        }
    }
}
