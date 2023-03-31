using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadraticEquation.WPF.Stores;
using QuadraticEquation.WPF.ViewModels;

namespace QuadraticEquation.WPF.Commands
{
    public class LoadQuadraticEquationsCommand : AsyncCommandBase
    {
        private readonly QuadraticEquationViewModel _quadraticEquationViewModel;
        private readonly QuadraticEquationsStore _quadraticEquationsStore;

        public LoadQuadraticEquationsCommand(QuadraticEquationViewModel quadraticEquationViewModel, QuadraticEquationsStore quadraticEquationsStore)
        {
            _quadraticEquationViewModel = quadraticEquationViewModel;
            _quadraticEquationsStore = quadraticEquationsStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _quadraticEquationViewModel.ErrorMessage = null;
            _quadraticEquationViewModel.IsLoading = true;
            try
            {
                await _quadraticEquationsStore.Load();
            }
            catch (Exception)
            {
                _quadraticEquationViewModel.ErrorMessage = "Failed to load Quadratic Equations. Please restart the application.";
            }
            finally
            {
                _quadraticEquationViewModel.IsLoading = false;
            }
        }
    }
}
